using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CustomModels
{
    public class mdlReturnData
    {
        public enmMessageType messageType { get; set; }
        public string message { get; set; }
        public dynamic ReturnId { get; set; }
    }
}
