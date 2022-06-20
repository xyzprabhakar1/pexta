using Common.Database;
using Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HRMS.classes;

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
        public int  Id{ get; set; }
        [ForeignKey("tblEmpDepartment")] // Foreign Key here        
        public int? EmpDepId { get; set; }
        public tblEmpDepartment tblEmpDepartment { get; set; }        
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


    public class tblEmpLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpLocationId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        public int? CompanyId { get; set; }
        public int? ZoneId { get; set; }
        public int? LocationId { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string ZoneName { get; set; }
        [NotMapped]
        public string LocationName { get; set; }
        public bool IsActive { get; set; }
        public DateTime EffectiveDt { get; set; } = DateTime.Now;
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class tblEmpLocation_log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tblEmpLocation")] // Foreign Key here        
        public int? EmpLocationId { get; set; }
        public tblEmpLocation tblEmpLocation { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmployeeMaster_log")] // Foreign Key here        
        public int? EmpLogId { get; set; }
        public tblEmployeeMaster_log tblEmployeeMaster_log { get; set; }
        public int? CompanyId { get; set; }
        public int? ZoneId { get; set; }
        public int? LocationId { get; set; }
        public int? SubLocationId { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string ZoneName { get; set; }
        [NotMapped]
        public string LocationName { get; set; }
        [NotMapped]
        public string SubLocationName { get; set; }
        public bool IsActive { get; set; }
        public DateTime EffectiveDt { get; set; } = DateTime.Now;
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


    public class tblEmpDesignation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpDesId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblDesignation")] // Foreign Key here        
        public int? DesId { get; set; }
        public tblDesignation tblDesignation { get; set; }
        [ForeignKey("tblGrade")] // Foreign Key here        
        public int? GradeId { get; set; }
        public tblGrade tblGrade { get; set; }

        public bool IsActive { get; set; }
        public DateTime EffectiveDt { get; set; } = DateTime.Now;
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class tblEmpDesignation_log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tblEmpDesignation")] // Foreign Key here        
        public int? EmpDesId { get; set; }
        public tblEmpDesignation tblEmpDesignation { get; set; }        
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblDesignation")] // Foreign Key here        
        public int? DesId { get; set; }
        public tblDesignation tblDesignation { get; set; }
        [ForeignKey("tblGrade")] // Foreign Key here        
        public int? GradeId { get; set; }
        public tblGrade tblGrade { get; set; }
        [ForeignKey("tblEmployeeMaster_log")] // Foreign Key here                
        public int? EmpLogId { get; set; }
        public tblEmployeeMaster_log tblEmployeeMaster_log { get; set; }
        public bool IsActive { get; set; }
        public DateTime EffectiveDt { get; set; } = DateTime.Now;
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

    public class tblEmpManager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmployeeMaster_Mgr")] // Foreign Key here        
        public int? ManagerId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster_Mgr { get; set; }
        public bool IsActive { get; set; }
        public DateTime EffectiveDt { get; set; } = DateTime.Now;
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class tblEmpManager_log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmployeeMaster_Mgr")] // Foreign Key here        
        public int? ManagerId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster_Mgr { get; set; }
        [ForeignKey("tblEmployeeMaster_log")] // Foreign Key here                
        public int? EmpLogId { get; set; }
        public tblEmployeeMaster_log tblEmployeeMaster_log { get; set; }
        public bool IsActive { get; set; }
        public DateTime EffectiveDt { get; set; } = DateTime.Now;
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


    public class tblEmpOfficialDetails : OfficialDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int OfficialDetailId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        [MaxLength(32)]
        public string CardNo { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }                        
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }
    public class tblEmpOfficialDetails_Log : OfficialDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmployeeMaster_log")] // Foreign Key here                
        public int? EmpLogId { get; set; }
        public tblEmployeeMaster_log tblEmployeeMaster_log { get; set; }
        [ForeignKey("tblEmpOfficialDetails")] // Foreign Key here        
        public new int? OfficialDetailId { get; set; }
        public tblEmpOfficialDetails tblEmpOfficialDetails { get; set; }
        [MaxLength(32)]
        public string CardNo { get; set; }
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


    public class tblEmpPersonalDetails : PersonalDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int PersonalDetailId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;

    }
    public class tblEmpPersonalDetails_Log : PersonalDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmployeeMaster_log")] // Foreign Key here                
        public int? EmpLogId { get; set; }
        public tblEmployeeMaster_log tblEmployeeMaster_log { get; set; }
        [ForeignKey("tblEmpPersonalDetails")] // Foreign Key here        
        public new int? PersonalDetailId { get; set; }
        public tblEmpPersonalDetails tblEmpPersonalDetails { get; set; }
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

    public class tblEmpDocument : DocumentDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int DocumentDetailId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class tblEmpDocument_Log : DocumentDetails
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
        [ForeignKey("tblEmpDocument")] // Foreign Key here        
        public new int? DocumentDetailId { get; set; }
        public tblEmpDocument tblEmpDocument { get; set; }
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

    public class tblEmpBankDetails :BankDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int BankDetailId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmpDocument")] // Foreign Key here        
        public int? DocumentId { get; set; }
        public tblEmpDocument tblEmpDocument { get; set; }        
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class tblEmpBankDetails_Log : BankDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmpDocument")] // Foreign Key here        
        public int? DocumentId { get; set; }
        public tblEmpDocument tblEmpDocument { get; set; }

        [ForeignKey("tblEmployeeMaster_log")] // Foreign Key here        
        public int? EmpLogId { get; set; }
        public tblEmployeeMaster_log tblEmployeeMaster_log { get; set; }
        [ForeignKey("tblEmpDocument_Log")] // Foreign Key here        
        public int? DocumentLogId { get; set; }
        public tblEmpDocument_Log tblEmpDocument_Log { get; set; }

        [ForeignKey("tblEmpBankDetails")] // Foreign Key here        
        public new int? BankDetailId { get; set; }
        public tblEmpBankDetails tblEmpBankDetails { get; set; }

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

    //public class TaxationDetails : IActive, ICreatedBy, IModifiedBy
    //{
    //    public int TaxationDetailId { get; set; }
    //    public int? PartyId { get; set; }
    //    public string TaxationNumber { get; set; }
    //    public string TaxationName { get; set; }
    //    public int? RegistrationStateId { get; set; }
    //    public int? RegistrationCountryId { get; set; }
    //    public bool IsActive { get; set; }
    //    public int CreatedBy { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //    public int ModifiedBy { get; set; }
    //    public DateTime ModifiedDate { get; set; }
    //}

    //public class ProfilePic : IActive, ICreatedBy, IModifiedBy
    //{
    //    public int TaxationDetailId { get; set; }
    //    public int? PartyId { get; set; }
    //    public Guid DocId { get; set; }
    //    public string Path { get; set; }
    //    public bool IsActive { get; set; }
    //    public int CreatedBy { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //    public int ModifiedBy { get; set; }
    //    public DateTime ModifiedDate { get; set; }
    //}

    public class tblEmpFamilyDetails: FamilyDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FamilyDetailId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;

    }

    public class tblEmpFamilyDetails_log : FamilyDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tblEmployeeMaster")] 
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmpFamilyDetails")] 
        public int? FamilyDetailId { get; set; }
        public tblEmpFamilyDetails tblEmpFamilyDetails { get; set; }
        [ForeignKey("tblEmployeeMaster_log")] 
        public int? EmpLogId { get; set; }
        public tblEmployeeMaster_log tblEmployeeMaster_log { get; set; }
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

    public class tblEmpQualification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QualificationId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        public enmQualification QualificationType { get; set; }
        [MaxLength(32)]
        public string CourseTitle { get; set; }
        [MaxLength(32)]
        public string Specialization { get; set; }
        [MaxLength(128)]
        public string University { get; set; }//University or Board
        [MaxLength(128)]
        public string College { get; set; }
        public enmMonth DurationStartMonth { get; set; }
        public Int16 DurationStartYear { get; set; }
        public enmMonth DurationEndMonth { get; set; }
        public Int16 DurationEndYear { get; set; }
        public enmCourseType CourseType { get; set; }
        public double Percentage { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class tblEmpQualification_log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QualificationId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmployeeMaster_log")] // Foreign Key here        
        public int? EmpLogId { get; set; }
        public tblEmployeeMaster_log tblEmployeeMaster_log { get; set; }
        public enmQualification QualificationType { get; set; }
        [MaxLength(32)]
        public string CourseTitle { get; set; }
        [MaxLength(32)]
        public string Specialization { get; set; }
        [MaxLength(128)]
        public string University { get; set; }//University or Board
        [MaxLength(128)]
        public string College { get; set; }
        public enmMonth DurationStartMonth { get; set; }
        public Int16 DurationStartYear { get; set; }
        public enmMonth DurationEndMonth { get; set; }
        public Int16 DurationEndYear { get; set; }
        public enmCourseType CourseType { get; set; }
        public double Percentage { get; set; }
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


    public class tblEmpWorkExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkExperienceId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [MaxLength(256)]
        public string CompanyName { get; set; }
        [MaxLength(256)]
        public string Address { get; set; }
        [MaxLength(32)]
        public string Designation { get; set; }
        public  DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [MaxLength(32)]
        public string EmployeeCode{ get; set; }
        public double AnnualSalary { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class tblEmpWorkExperience_Log
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
        [ForeignKey("tblEmpWorkExperience")] // Foreign Key here        
        public int? WorkExperienceId { get; set; }
        public tblEmpWorkExperience tblEmpWorkExperience { get; set; }
        [MaxLength(256)]
        public string CompanyName { get; set; }
        [MaxLength(256)]
        public string Address { get; set; }
        [MaxLength(32)]
        public string Designation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [MaxLength(32)]
        public string EmployeeCode { get; set; }
        public double AnnualSalary { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
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
