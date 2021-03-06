using Common.CustomModels;
using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projMasters.Models
{
    public class mdlLoginRequest
    {
        public uint userId { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string orgCode { get; set; }
        public uint orgId { get; set; }
        [Required]
        public string captchaId { get; set; }
        public string captchaValue { get; set; }
        public int height{ get; set; }
        public int width { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
    public class mdlLoginResponse
    {
        private uint _userId;
        private string _userIdHex;
        public string userIdHex { get { return _userIdHex; } set { _userIdHex = value; _userId = uint.Parse(_userIdHex, System.Globalization.NumberStyles.HexNumber); } }
        public uint userId { get { return _userId; } set { _userId = value; _userIdHex= string.Format("{0:X4}", _userId);  } }
        public uint orgId { get; set; }
        public enmMessageType messageType { get; set; }
        public string token { get; set; }
        public string normalizedName { get; set; }
        public int failCount { get; set; }        
        public Error error { get; set; }
        //public int default_company { get; set; }
        //public int?[] company_list { get; set; }        
        //public string company_name { get; set; }
        //public string company_logo { get; set; }
        public string captchaId { get; set; } = "";        
        public byte [] captchaImages { get; set; }
        public enmUserType userType { get; set; }
    }


    #region  **************** Model ****************
    public class mdlUserRolesWraper
    {
        public mdlUserMaster userMaster { get; set; }
        public List<mdlUserRoles> userRoles { get; set; }
        public List<mdlRoleDocument> userClaim { get; set; }
    }
    public class mdlUserRoles
    {
        public mdlRoleMaster roleMaster { get; set; }
        public bool isActive { get; set; }
        public DateTime modifyDt { get; set; }
    }
    public class mdlRoleMaster
    {
        public uint roleId { get; set; }
        public string roleName { get; set; }
        public bool isActive { get; set; }
        public List<mdlRoleDocument> roleDocument { get; set; }
    }
    public class mdlUserMaster
    {
        public uint userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string normalizedName { get; set; }

    }
    public class mdlRoleDocument
    {
        public enmDocumentMaster documentId { get; set; }
        public enmDocumentType permissionType { get; set; }
        public enmAdditionalClaim additionalClaim { get; set; }
    }

    #endregion

}
