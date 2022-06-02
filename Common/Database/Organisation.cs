using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{

    public abstract class _tblOrganisation : d_Contact_With_Address
    {
        public int OrgId { get; set; }
        [MaxLength(16)]
        [RegularExpression(@"^[^<>]+$", ErrorMessage = "Character < > are not allowed")]
        public string Code { get; set; } = String.Empty;
        [MaxLength(254)]
        [RegularExpression(@"^[^<>]+$", ErrorMessage = "Character < > are not allowed")]
        public string Name { get; set; } = String.Empty;
        public string Logo { get; set; } = String.Empty;
        public bool IsActive { get; set; }
        [NotMapped]
        public string LogoImage { get; set; }//base 64
        [NotMapped]
        public string LogoImageType { get; set; }
    }

    public class tblOrganisation : _tblOrganisation, IModified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int OrgId { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class tblOrganisation_Log : _tblOrganisation,IRequested,IApproval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tblOrganisation")] // Foreign Key here        
        public new int? OrgId { get; set; }
        public tblOrganisation tblOrganisation { get; set; }
        public DateTime RequestedDt { get; set; }
        public int RequestedBy { get; set; }
        [MaxLength(256)]
        public string RequestedRemarks { get; set; } = string.Empty;
        public DateTime? ApprovalDt { get; set; }
        public int? ApprovalBy { get; set; }
        [MaxLength(256)]
        public string ApprovalRemarks { get; set; } = string.Empty;
        public enmApprovalStatus ApprovalStatus { get; set; }
        public enmEntityType EntityType { get; set; } = enmEntityType.Create;

    }


    public abstract class _tblCompanyMaster
    {
        public int CompanyId { get; set; }
        [MaxLength(16)]
        [RegularExpression(@"^[^<>]+$", ErrorMessage = "Character < > are not allowed")]
        public string Code { get; set; } = String.Empty;
        [MaxLength(254)]
        [RegularExpression(@"^[^<>]+$", ErrorMessage = "Character < > are not allowed")]
        public string Name { get; set; } = String.Empty;
        public string Logo { get; set; } = String.Empty;
        public bool IsActive { get; set; }
        [NotMapped]
        public string LogoImage { get; set; }//base 64
        [NotMapped]
        public string LogoImageType { get; set; }
        [NotMapped]
        public string OrgName { get; set; }
        [ForeignKey("tblOrganisation")] // Foreign Key here
        public int? OrgId { get; set; }
        public tblOrganisation tblOrganisation { get; set; }
        
    }

    public class tblCompanyMaster : _tblCompanyMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int CompanyId { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;     
    }

    public class tblCompanyMaster_Log : _tblCompanyMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tblCompanyMaster")] // Foreign Key here
        public new int? CompanyId { get; set; }
        public tblCompanyMaster tblCompanyMaster { get; set; }
        public DateTime RequestedDt { get; set; }
        public int RequestedBy { get; set; }
        [MaxLength(256)]
        public string RequestedRemarks { get; set; } = string.Empty;
        public DateTime? ApprovalDt { get; set; }
        public int? ApprovalBy { get; set; }
        [MaxLength(256)]
        public string ApprovalRemarks { get; set; } = string.Empty;
        public enmApprovalStatus ApprovalStatus { get; set; }
        public enmEntityType EntityType { get; set; } = enmEntityType.Create;
    }



    public abstract class _tblZoneMaster : d_Contact_With_Address
    {
        public int ZoneId { get; set; }
        [MaxLength(254)]
        [RegularExpression(@"^[^<>]+$", ErrorMessage = "Character < > are not allowed")]
        public string Name { get; set; } = String.Empty;
        public bool IsActive { get; set; }
        [NotMapped]
        public string CompanyName { get; set; } = String.Empty;
        [ForeignKey("tblCompanyMaster")] // Foreign Key here
        public int? CompanyId { get; set; }
        public tblCompanyMaster tblCompanyMaster { get; set; }
        [ForeignKey("tblOrganisation")] // Foreign Key here
        public int? OrgId { get; set; }
        public tblOrganisation tblOrganisation { get; set; }
    }

    public class tblZoneMaster : _tblZoneMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ZoneId { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;

    }

    public class tblZoneMaster_Log : _tblZoneMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tblZoneMaster")] // Foreign Key here
        public new int? ZoneId { get; set; }
        public tblZoneMaster tblZoneMaster { get; set; }
        public DateTime RequestedDt { get; set; }
        public int RequestedBy { get; set; }
        [MaxLength(256)]
        public string RequestedRemarks { get; set; } = string.Empty;
        public DateTime? ApprovalDt { get; set; }
        public int? ApprovalBy { get; set; }
        [MaxLength(256)]
        public string ApprovalRemarks { get; set; } = string.Empty;
        public enmApprovalStatus ApprovalStatus { get; set; }
        public enmEntityType EntityType { get; set; } = enmEntityType.Create;
    }

    public class _tblLocationMaster : d_Contact_With_Address
    {
        public int LocationId { get; set; }
        [MaxLength(254)]
        public string Name { get; set; }
        public enmLocationType LocationType { get; set; } = enmLocationType.None;
        public bool IsActive { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string ZoneName { get; set; }
        [ForeignKey("tblZoneMaster")] // Foreign Key here
        public int? ZoneId { get; set; }
        public tblZoneMaster tblZoneMaster { get; set; }
        [NotMapped]
        public int? CompanyId { get; set; }
        [ForeignKey("tblOrganisation")] // Foreign Key here
        public int? OrgId { get; set; }
        public tblOrganisation tblOrganisation { get; set; }
    }

    public class tblLocationMaster :_tblLocationMaster 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int LocationId { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }
    public class tblLocationMaster_Log : _tblLocationMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        [ForeignKey("tblLocationMaster")] // Foreign Key here
        public new int? LocationId { get; set; }
        public tblLocationMaster tblLocationMaster { get; set; }
        public DateTime RequestedDt { get; set; }
        public int RequestedBy { get; set; }
        [MaxLength(256)]
        public string RequestedRemarks { get; set; } = string.Empty;
        public DateTime? ApprovalDt { get; set; }
        public int? ApprovalBy { get; set; }
        [MaxLength(256)]
        public string ApprovalRemarks { get; set; } = string.Empty;
        public enmApprovalStatus ApprovalStatus { get; set; }
        public enmEntityType EntityType { get; set; } = enmEntityType.Create;
    }
}
