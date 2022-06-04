﻿using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    public class tblUsersMaster : d_Modified 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong UserId { get; set; }  // primary key  must be public!    
        [MaxLength(256)]
        public string NormalizedName { get; set; }
        [MaxLength(64)]
        public string UserName { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        [MaxLength(16)]
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        [MaxLength(512)]
        public string Password { get; set; }
        public enmUserType UserType { get; set; }
        public bool IsActive { get; set; }// this can be Block by admin so the user not able to log in the system
        public byte LoginFailCount { get; set; }
        public DateTime LoginFailCountdt { get; set; } = DateTime.Now;
        public byte is_logged_blocked { get; set; } = 0;//block log in due to wrong attemp
        public DateTime logged_blocked_dt { get; set; }
        public DateTime logged_blocked_Enddt { get; set; }        
        [ForeignKey("tblOrganisation")] // Foreign Key here
        public int? OrgId { get; set; }
        public tblOrganisation tblOrganisation { get; set; }
        public bool RequiredChangePassword { get; set; } = false;
    }

    public class tblRoleMaster : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }  // primary key  must be public!   
        [MaxLength(64)]
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
    }

    public class tblRoleClaim : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleClaimId { get; set; }  // primary key  must be public!   
        [ForeignKey("tblRoleMaster")] // Foreign Key here
        public int? RoleId { get; set; }
        public tblRoleMaster tblRoleMaster { get; set; }
        public enmDocumentMaster DocumentMaster { get; set; }
        public enmDocumentType PermissionType { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class tblUserClaim : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleClaimId { get; set; }  // primary key  must be public!   
        [ForeignKey("tblUsersMaster")] // Foreign Key here
        public ulong? UserId { get; set; }
        public tblUsersMaster tblUsersMaster { get; set; }
        public enmDocumentMaster DocumentMaster { get; set; }
        public enmDocumentType PermissionType { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class tblUserRole : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRoleId { get; set; }  // primary key  must be public!   
        [ForeignKey("tblUsersMaster")] // Foreign Key here
        public ulong? UserId { get; set; }
        public tblUsersMaster tblUsersMaster { get; set; }
        [ForeignKey("tblRoleMaster")] // Foreign Key here
        public int? RoleId { get; set; }
        public tblRoleMaster tblRoleMaster { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class tblUserAllClaim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleClaimId { get; set; }  // primary key  must be public!   
        [ForeignKey("tblUsersMaster")] // Foreign Key here
        public ulong? UserId { get; set; }
        public tblUsersMaster tblUsersMaster { get; set; }
        public enmDocumentMaster DocumentMaster { get; set; }
        public enmDocumentType PermissionType { get; set; }
        public string PermissionType { get; set; }
    }

    public class tblUserOTP
    {
        [Key]
        [MaxLength(256)]
        public string SecurityStamp { get; set; }
        public string DescId { get; set; }
        [ForeignKey("tblUsersMaster")] // Foreign Key here
        public ulong? UserId { get; set; }
        public tblUsersMaster tblUsersMaster { get; set; }
        [MaxLength(256)]
        public string TempUserId { get; set; }
        public string OTP { get; set; }
        public DateTime EffectiveFromDt { get; set; } = DateTime.Now;
        public DateTime EffectiveToDt { get; set; } = DateTime.Now.AddMinutes(30);
    }
    public class tblUserLoginLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Sno { get; set; }  // primary key  must be public!    
        [ForeignKey("tblUsersMaster")] // Foreign Key here
        public ulong? UserId { get; set; }
        public tblUsersMaster tblUsersMaster { get; set; }
        [MaxLength(256)]
        public string IPAddress { get; set; }
        [MaxLength(256)]
        public string DeviceDetails { get; set; }
        [MaxLength(128)]
        public bool LoginStatus { get; set; }
        [MaxLength(128)]
        public string FromLocation { get; set; }
        [MaxLength(128)]
        public string Longitude { get; set; }
        [MaxLength(128)]
        public string Latitude { get; set; }
        public DateTime LoginDateTime { get; set; }
    }

    public class tblUserOrganisationPermission : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Sno { get; set; }  // primary key  must be public!    
        [ForeignKey("tblUsersMaster")] // Foreign Key here
        public ulong? UserId { get; set; }
        public tblUsersMaster tblUsersMaster { get; set; }
        [ForeignKey("tblOrganisation")] // Foreign Key here
        public int? OrgId { get; set; }
        public tblOrganisation tblOrganisation { get; set; }
        public bool HaveAllCompanyAccess { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class tblUserCompanyPermission : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Sno { get; set; }  // primary key  must be public!    
        [ForeignKey("tblUsersMaster")] // Foreign Key here
        public ulong? UserId { get; set; }
        public tblUsersMaster tblUsersMaster { get; set; }
        [ForeignKey("tblCompanyMaster")] // Foreign Key here
        public int? CompanyId { get; set; }
        public tblCompanyMaster tblCompanyMaster { get; set; }
        public bool HaveAllZoneAccess { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class tblUserZonePermission : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Sno { get; set; }  // primary key  must be public!    
        [ForeignKey("tblUsersMaster")] // Foreign Key here
        public ulong? UserId { get; set; }
        public tblUsersMaster tblUsersMaster { get; set; }
        [ForeignKey("tblZoneMaster")] // Foreign Key here
        public int? ZoneId { get; set; }
        public tblZoneMaster tblZoneMaster { get; set; }
        public bool HaveAllLocationAccess { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class tblUserLocationPermission : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Sno { get; set; }  // primary key  must be public!    
        [ForeignKey("tblUsersMaster")] // Foreign Key here
        public ulong? UserId { get; set; }
        public tblUsersMaster tblUsersMaster { get; set; }
        [ForeignKey("tblLocationMaster")] // Foreign Key here
        public int? LocationId { get; set; }
        public tblLocationMaster tblLocationMaster { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class tblUserAllLocationPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Sno { get; set; }  // primary key  must be public!    
        [ForeignKey("tblUsersMaster")] // Foreign Key here
        public ulong? UserId { get; set; }
        public tblUsersMaster tblUsersMaster { get; set; }
        [ForeignKey("tblLocationMaster")] // Foreign Key here
        public int? LocationId { get; set; }
        public tblLocationMaster tblLocationMaster { get; set; }

    }

}
