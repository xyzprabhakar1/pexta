using Common.CustomModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Enums;
using projMasters.Models;

namespace pextaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly projMasters.IAuth _auth;
        private readonly projMasters.IMasters _master;
        private readonly Common.ISettings _Settings;
        private readonly IConfiguration _config;

        public UserController(ILogger<UserController> logger, projMasters.IAuth auth, projMasters.IMasters master,
            IConfiguration config, Common.ISettings settings)
        {
            _logger = logger;
            _auth = auth;
            _master = master;
            _config = config;
            _Settings = settings;
        }

        private mdlReturnData GenrateCaptcha(uint UserId, int Width, int Height)
        {
            mdlReturnData mdl = new mdlReturnData() { messageType = enmMessageType.None };
            var tempData = _Settings.GenrateOTP(UserId, "LoginCaptchaExpiryTime", "Login");
            mdl.message = tempData.securityStamp;
            if (tempData.messageType == enmMessageType.Success)
            {
                mdl.ReturnId = _Settings.GenerateImage(Width, Height, tempData.otp);
                mdl.messageType = enmMessageType.Success;
            }
            else
            {
                mdl.messageType = enmMessageType.Error;
                mdl.error = new Error() { ErrorId = enmError.UndefinedException };
            }
            return mdl;
        }

        [HttpGet]
        [Route("GetCaptcha/{UserId}/{Width}/{Height}")]
        public IActionResult GetCaptcha(uint UserId,int Width,int Height)
        {
            return Ok( GenrateCaptcha(UserId, Width, Height));
        }
        [HttpPost]
        [Route("login")]
        public IActionResult login(mdlLoginRequest mdl)
        {
            mdlLoginResponse res = new mdlLoginResponse();
            if (!ModelState.IsValid)
            {
                res.messageType = enmMessageType.Error;
                res.error = new Error() { ErrorId = enmError.InvalidData };
                res.error.Message = res.error.Message+" "+ string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return Ok(res);
            }
            res.orgId=_master.GetOrgId(mdl.orgCode);
            if (res.orgId == 0)
            {
                res.messageType = enmMessageType.Error;
                res.error = new Error() { ErrorId = enmError.InvalidOrganization };                
                return Ok(res);
            }

            var IsValid=_Settings.ValidateCaptcha(mdl.userId, mdl.captchaValue, mdl.captchaId);
            if (IsValid.messageType!=enmMessageType.Success)
            {
                res.messageType = enmMessageType.Error;
                res.error = new Error() { ErrorId=enmError.InvalidCaptcha };
                return Ok(res);
            }
            res = _auth.Login(mdl);
            _auth.SaveLoginLog(mdl.userId,_Settings.GetClientIPAddress(),string.Concat(_Settings.GetDeviceDetail(), " - ", _Settings.GetBrowserDetail()), res.messageType==enmMessageType.Success,"",mdl.longitude,mdl.latitude);
            if (res.messageType == enmMessageType.Error)
            {
                //Regenrate the captha
                var tempcaptcha=GenrateCaptcha(mdl.userId,mdl.width,mdl.height);
                res.captchaId = tempcaptcha.message;
                res.captchaImages = tempcaptcha.ReturnId;
                return Ok(res);
            }
            //Genrate captcha
            var token=_auth.GenerateJSONWebToken(_config["Jwt:Key"], _config["Jwt:Issuer"], res.userId, 0, 0, 0, 0, res.userType, Convert.ToInt32(res.orgId));
            res.token= token;
            return Ok( res);
        }


        [HttpPost]
        [Route("UserOrgPermission")]
        public IActionResult UserOrgPermission()
        {   
            return Ok("");
        }
    }
}
