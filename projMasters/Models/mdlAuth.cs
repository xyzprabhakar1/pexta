using Common.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projMasters.Models
{
    public class mdlLoginRequest
    {   
        public string userName { get; set; }
        public string password { get; set; }
        public string orgCode { get; set; }
        public uint orgId { get; set; }
    }
    public class mdlLoginResponse
    {
        public bool isSuccess { get; set; }
        public string token { get; set; }
        public string normalizedName { get; set; }
        public int failCount { get; set; }        
        public Error error { get; set; }
    }
    
}
