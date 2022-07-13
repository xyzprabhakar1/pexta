using Common.CustomModels;
using Common.Enums;
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
        private int _userId;
        private string _userIdHex;
        public string userIdHex { get { return _userIdHex; } set { _userIdHex = value; _userId = int.Parse(_userIdHex, System.Globalization.NumberStyles.HexNumber); } }
        public int userId { get { return _userId; } set { _userId = value; _userIdHex= Convert.ToString(_userId,16); } }
        public enmMessageType messageType { get; set; }
        public string token { get; set; }
        public string normalizedName { get; set; }
        public int failCount { get; set; }        
        public Error error { get; set; }
    }
    
}
