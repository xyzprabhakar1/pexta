using Common.Enums;
using Microsoft.AspNetCore.Http;
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

    public class mdlCommonReturn
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class mdlFile
    {
        public IFormFile LogoImageFile { get; set; }
        public string NewFileName { get; set; }

    }

    public class mdlCommonReturnWithParentID : mdlCommonReturn
    {
        public int ParentId { get; set; }
    }
    public class mdlCommonReturnuintWithParentID : mdlCommonReturn
    {
        public new uint Id { get; set; }
        public  uint ParentId { get; set; }
    }
    public class mdlCommonReturnUlong
    {
        public ulong Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
    public class mdlDeleteData
    {
        public int Id { get; set; }
        public string Remarks { get; set; }
    }

}
