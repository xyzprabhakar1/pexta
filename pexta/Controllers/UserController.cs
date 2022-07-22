using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pexta.Models;

namespace pexta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        [Route("login1")]
        //[ValidateAntiForgeryToken]
        public mdlLoginResponse login(mdlLoginRequest mdl)
        {
            mdlLoginResponse res = new mdlLoginResponse()
            {
                error = new Common.CustomModels.Error(),
                IsSuccess=false,
                token= String.Empty
            };
            if (mdl.userName == "prabhakar" && mdl.password == "123456")
            {
                res.IsSuccess = true;
            }
            return res;
        }
        [Route("login")]
        public mdlLoginResponse login()
        {
            mdlLoginResponse res = new mdlLoginResponse()
            {
                error = new Common.CustomModels.Error(),
                IsSuccess = false,
                token = String.Empty
            };
            return res;
        }

        

    }
}
