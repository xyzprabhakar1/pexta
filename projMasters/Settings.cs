using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using projMasters.Database;
using Microsoft.Extensions.Configuration;
using Common.Database;
using Common.Enums;
using Common;
using Common.CustomModels;
using Microsoft.AspNetCore.Http;
using UAParser;

namespace projMasters
{
    

    public class Settings : ISettings
    {
        private readonly MasterContext _mastercontext;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _accessor;
        public Settings(MasterContext context, IConfiguration config, IHttpContextAccessor accessor)
        {
            _mastercontext = context;
            _config = config;
            _accessor = accessor;
        }

        public string GetClientIPAddress()
        {
            return Convert.ToString(_accessor.HttpContext?.Connection?.RemoteIpAddress) ;
        }

        private ClientInfo GetUserAgent()
        {
            
            var userAgent = _accessor.HttpContext?.Request?.Headers?["User-Agent"];
            if (string.IsNullOrEmpty(userAgent))
            {
                return null;

            }
            var uaParser = Parser.GetDefault();
            ClientInfo c = uaParser.Parse(userAgent);
            return c;
        }

        public string GetBrowserDetail()
        {
            var ua = GetUserAgent();
            if (ua == null)
            {
                return "";
            }
            return ua.UA.Family;
        }
        public string GetDeviceDetail()
        {
            var ua = GetUserAgent();
            if (ua == null)
            {
                return "";
            }
            return String.Concat( ua.Device.Family," - "+ (ua.OS?.Family??""));
        }

        public string GetSettings(string SettingGroup, string SettingName)
        {
            string SettingValue = string.Empty;
            var DbSetting = _mastercontext.tbl_app_setting.Where(p => p.GroupName == SettingGroup && p.AppSettingKey == SettingName && p.IsActive).FirstOrDefault();
            if (DbSetting == null)
            {
                try
                {
                    SettingValue = _config[string.Concat("OrganisationSetting:", SettingGroup, ":", SettingName)];
                    _mastercontext.tbl_app_setting.Add(new tbl_app_setting()
                    {
                        AppSettingKey = SettingName,
                        AppSettingValue = SettingValue,
                        IsActive = true,
                        ModifiedDt = DateTime.Now,
                        GroupName = SettingGroup,
                        ModifiedBy = 1,
                        ModifiedRemarks = String.Empty

                    });
                    _mastercontext.SaveChanges();
                }
                catch { }
            }
            else
            {
                SettingValue = DbSetting.AppSettingValue;
            }
            return SettingValue;
        }

        public string GenrateCharcter(bool IsAlphanumeric, int NumberOfCharcter)
        {
            const string AlphanumericLetters = "2346789ABCDEFGHJKLMNPRTUVWXYZ";
            const string Letters = "ABCDEFGHJKLMNPRTUVWXYZ";
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            if (!IsAlphanumeric)
            {
                int maxRand = Letters.Length - 1;
                for (int i = 0; i < NumberOfCharcter; i++)
                {
                    int index = rand.Next(maxRand);
                    sb.Append(Letters[index]);
                }
            }
            else
            {
                int maxRand = AlphanumericLetters.Length - 1;
                for (int i = 0; i < NumberOfCharcter; i++)
                {
                    int index = rand.Next(maxRand);
                    sb.Append(AlphanumericLetters[index]);
                }
            }
            return sb.ToString();
        }


        public OTP GenrateOTP(uint UserId, string LoginCaptchaExpiryTime, string description)
        {
            OTP ReturnData = new OTP() { messageType = enmMessageType.None };
            int LoginCaptchaExpiry = 30;
            int.TryParse(GetSettings("Captcha", LoginCaptchaExpiryTime), out LoginCaptchaExpiry);
            tblUserOTP mdl = new tblUserOTP()
            {
                UserId = UserId,
                EffectiveFromDt = DateTime.Now,
                EffectiveToDt = DateTime.Now.AddMinutes(LoginCaptchaExpiry),
                SecurityStamp = Convert.ToString(Guid.NewGuid()).Replace("-", ""),
                OTP = GenrateCharcter(true, 4),
                DescId = description
            };
            _mastercontext.tblUserOTP.Add(mdl);
            _mastercontext.SaveChanges();
            ReturnData.messageType = enmMessageType.Success;
            ReturnData.expiryTime = mdl.EffectiveToDt;
            ReturnData.securityStamp = mdl.SecurityStamp;
            ReturnData.otp = mdl.OTP;
            return ReturnData;
        }

        public mdlReturnData ValidateCaptcha(uint userId, string Otp, string SecurityStamp)
        {
            mdlReturnData ReturnData = new mdlReturnData() { messageType = enmMessageType.None };
            var tempResult = _mastercontext.tblUserOTP.Where(p => p.UserId == userId && p.SecurityStamp == SecurityStamp && p.OTP == Otp && p.EffectiveToDt > DateTime.Now).FirstOrDefault();
            if (tempResult == null)
            {
                ReturnData.messageType = enmMessageType.Error;
                ReturnData.message = "Invalid Token";
            }
            else
            {
                _mastercontext.tblUserOTP.Remove(tempResult);
                _mastercontext.SaveChanges();
                ReturnData.messageType = enmMessageType.Success;
                ReturnData.ReturnId = tempResult.UserId;
            }
            return ReturnData;
        }

        public byte[] GenerateImage(int width, int height, string captchaCode)
        {
            using (Bitmap baseMap = new Bitmap(width, height))
            using (Graphics graph = Graphics.FromImage(baseMap))
            {
                Random rand = new Random();

                graph.Clear(GetRandomLightColor());

                DrawCaptchaCode();
                // DrawDisorderLine();
                // AdjustRippleEffect();

                MemoryStream ms = new MemoryStream();
                baseMap.Save(ms, ImageFormat.Png);
                return ms.ToArray();

                int GetFontSize(int imageWidth, int captchCodeCount)
                {
                    var averageSize = imageWidth / captchCodeCount;
                    return Convert.ToInt32(averageSize);
                }

                Color GetRandomDeepColor()
                {
                    int redlow = 160, greenLow = 100, blueLow = 160;
                    return Color.FromArgb(rand.Next(redlow), rand.Next(greenLow), rand.Next(blueLow));
                }

                Color GetRandomLightColor()
                {
                    int low = 180, high = 255;

                    int nRend = rand.Next(high) % (high - low) + low;
                    int nGreen = rand.Next(high) % (high - low) + low;
                    int nBlue = rand.Next(high) % (high - low) + low;

                    return Color.FromArgb(nRend, nGreen, nBlue);
                }

                void DrawCaptchaCode()
                {
                    SolidBrush fontBrush = new SolidBrush(Color.Black);
                    int fontSize = GetFontSize(width, captchaCode.Length);
                    Font font = new Font(FontFamily.GenericSerif, fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
                    for (int i = 0; i < captchaCode.Length; i++)
                    {
                        fontBrush.Color = GetRandomDeepColor();

                        int shiftPx = fontSize / 6;

                        float x = i * fontSize + rand.Next(-shiftPx, shiftPx) + rand.Next(-shiftPx, shiftPx);
                        int maxY = height - fontSize;
                        if (maxY < 0) maxY = 0;
                        float y = rand.Next(0, maxY);

                        graph.DrawString(captchaCode[i].ToString(), font, fontBrush, x, y);
                    }
                }


            }
        }

    }
}
