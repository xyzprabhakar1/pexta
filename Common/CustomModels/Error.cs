using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Common.CustomModels
{
    public class Error
    {
        public enmError ErrorId { get; set; }
        public string Message { get; set; }
    }
}
