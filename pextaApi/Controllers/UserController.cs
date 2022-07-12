using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pextaApi.Models;

namespace pextaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("login")]        
        public mdlLoginResponse login(mdlLoginRequest mdl)
        {
            mdlLoginResponse res = new mdlLoginResponse()
            {
                error = new Common.CustomModels.Error(),
                IsSuccess = false,
                token = String.Empty
            };
            if (mdl.userName == "prabhakar" && mdl.password == "123456")
            {
                res.IsSuccess = true;
            }
            else
            {
                res.error.Message = "Invalid Username or password";
            }

            return res;
        }
    }
}
