using Common.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface ISettings
    {
        byte[] GenerateImage(int width, int height, string captchaCode);
        string GenrateCharcter(bool IsAlphanumeric, int NumberOfCharcter);
        OTP GenrateOTP(ulong UserId, string LoginCaptchaExpiryTime, string description);
        string GetSettings(string SettingGroup, string SettingName);
        mdlReturnData ValidateCaptcha(ulong userId, string Otp, string SecurityStamp);
    }
}
