using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CustomModels
{
    public class OTP
    {
        public enmMessageType messageType { get; set; }
        public DateTime expiryTime { get; set; }
        public string securityStamp { get; set; }
        public string otp { get; set; }
        public string desc { get; set; }
    }
}
