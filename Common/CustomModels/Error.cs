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
        private enmError _ErrorId;
        private string _ErrorMessage;
        public enmError ErrorId { get { return _ErrorId; } set { _ErrorId = value; _ErrorMessage = _ErrorId.GetDescription(); } }
        public string Message { get { return _ErrorMessage; } set { _ErrorMessage = value; } }
    }
}
