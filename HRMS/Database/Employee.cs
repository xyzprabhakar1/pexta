using Common.Database;
using Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database
{
    
    public class tblEmployeeMaster : d_BasicDetails, IModified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class tblEmployeeMaster_log : d_BasicDetails, IRequested,IApproval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public  int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
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

    public class tblEmpAddress : d_Address, IModified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int AddressId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class tblEmpAddress_Log : d_Address, IRequested, IApproval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmployeeMaster_log")] // Foreign Key here        
        public int? EmpLogId { get; set; }
        public tblEmployeeMaster_log tblEmployeeMaster_log { get; set; }
        [ForeignKey("tblEmpAddress")] // Foreign Key here        
        public new int? AddressId { get; set; }
        public tblEmpAddress tblEmpAddress { get; set; }
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

    public class tblEmpContacts : d_ContactDetails, IModified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ContactId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class tblEmpContacts_Log : d_ContactDetails, IRequested, IApproval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmployeeMaster_log")] // Foreign Key here        
        public int? EmpLogId { get; set; }
        public tblEmployeeMaster_log tblEmployeeMaster_log { get; set; }
        [ForeignKey("tblEmpContacts")] // Foreign Key here        
        public new int? ContactId { get; set; }
        public tblEmpContacts tblEmpContacts { get; set; }
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

    public class tblEmpDepartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpDepId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblDepartment")] // Foreign Key here        
        public int? DepId { get; set; }
        public tblDepartment tblDepartment { get; set; }
        [ForeignKey("tblDepartWorkingRole")] // Foreign Key here        
        public int? DepWorkingRoleId { get; set; }
        public tblDepartWorkingRole tblDepartWorkingRole { get; set; }
        public bool IsActive { get; set; }
        public DateTime EffectiveDt { get; set; }=DateTime.Now;
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }


    public class tblEmpDepartment_log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpDepId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmployeeMaster_log")] // Foreign Key here        
        public int? EmpLogId { get; set; }
        public tblEmployeeMaster_log tblEmployeeMaster_log { get; set; }
        [ForeignKey("tblDepartment")] // Foreign Key here        
        public int? DepId { get; set; }
        public tblDepartment tblDepartment { get; set; }
        [ForeignKey("tblDepartWorkingRole")] // Foreign Key here        
        public int? DepWorkingRoleId { get; set; }
        public tblDepartWorkingRole tblDepartWorkingRole { get; set; }
        public bool IsActive { get; set; }
        public DateTime EffectiveDt { get; set; } = DateTime.Now;
        
    }

    public class OfficialDetails : IActive, ICreatedBy, IModifiedBy
    {
        public int OfficialDetailId { get; set; }
        public int? PartyId { get; set; }
        public int? CompanyId { get; set; }
        public int? ZoneId { get; set; }
        public int? LocationId { get; set; }
        public int? SubLocationId { get; set; }
        public int? DepartmentId { get; set; }
        public int? SubDepartmentId { get; set; }
        public DateTime JoiningDt { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class PersonalDetails : IActive, ICreatedBy, IModifiedBy
    {
        public int PersonalDetailId { get; set; }
        public int? PartyId { get; set; }
        public enmReligion Religion { get; set; }
        [MaxLength(90)]
        public string MotherName { get; set; }
        public enmMaritalStatus MaritalStatus { get; set; }
        public DateTime AnniversaryDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class BankDetails : IActive, ICreatedBy, IModifiedBy
    {
        public int BankDetailId { get; set; }
        public int? PartyId { get; set; }
        public int? BankId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class TaxationDetails : IActive, ICreatedBy, IModifiedBy
    {
        public int TaxationDetailId { get; set; }
        public int? PartyId { get; set; }
        public string TaxationNumber { get; set; }
        public string TaxationName { get; set; }
        public int? RegistrationStateId { get; set; }
        public int? RegistrationCountryId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class ProfilePic : IActive, ICreatedBy, IModifiedBy
    {
        public int TaxationDetailId { get; set; }
        public int? PartyId { get; set; }
        public Guid DocId { get; set; }
        public string Path { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class FamilyDetails : IActive, ICreatedBy, IModifiedBy
    {
        public int FamilyDetailId { get; set; }
        public int? PartyId { get; set; }
        public enmFamily enmFamily { get; set; }
        public string RelationName { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class PartyDocumentDetails : IActive, ICreatedBy, IModifiedBy
    {
        public int DocumentDetailId { get; set; }
        public int? PartyId { get; set; }
        public int? DocumentTypeId { get; set; }
        public string DocumentNo { get; set; }
        public string DocumentDetails { get; set; }
        public enmDocumentExtension DocumentExtension { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
