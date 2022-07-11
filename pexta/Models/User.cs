using Common.CustomModels;

namespace pexta.Models
{
    public class mdlLoginRequest
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
    public class mdlLoginResponse
    {
        public bool IsSuccess { get; set; }
        public string token { get; set; }
        public Error error { get; set; }
    }
}
