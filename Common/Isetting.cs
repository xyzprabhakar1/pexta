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
        string GetClientIPAddress();
        string GetBrowserDetail();
        string GetDeviceDetail();
        byte[] GenerateImage(int width, int height, string captchaCode);
        string GenrateCharcter(bool IsAlphanumeric, int NumberOfCharcter);
        OTP GenrateOTP(uint UserId, string LoginCaptchaExpiryTime, string description);
        string GetSettings(string SettingGroup, string SettingName);
        mdlReturnData ValidateCaptcha(uint userId, string Otp, string SecurityStamp);
    }
}
