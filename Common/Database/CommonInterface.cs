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
    public interface ICreated
    {
        public DateTime CreatedDt { get; set; }
        public int CreatedBy { get; set; }
    }
    public interface IModified
    {
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        public string ModifiedRemarks { get; set; }
    }
    public interface IRequested
    {
        public DateTime RequestedDt { get; set; }
        public int RequestedBy { get; set; }
        public string RequestedRemarks { get; set; }
    }
    public interface IApproval 
    {
        public DateTime? ApprovalDt { get; set; }
        public int? ApprovalBy { get; set; }
        public string ApprovalRemarks { get; set; }
        public enmApprovalStatus ApprovalStatus { get; set; }
    }
    public class d_Modified : IModified
    {
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class d_CreatedModified: ICreated, IModified
    {
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]        
        public string ModifiedRemarks { get; set; } = string.Empty;
        public DateTime CreatedDt { get; set; }
        public int CreatedBy { get; set; }
    }

    

    public class d_Approval : IRequested, IApproval
    {
        public DateTime RequestedDt { get; set; }
        public int RequestedBy { get; set; }
        [MaxLength(256)]        
        public string RequestedRemarks { get; set; } = string.Empty;
        public DateTime? ApprovalDt { get; set; }
        public int? ApprovalBy { get; set; }
        [MaxLength(256)]        
        public string ApprovalRemarks { get; set; }= string.Empty;
        public enmApprovalStatus ApprovalStatus { get; set; }
    }

    public class d_Contact_With_Address
    {

        [RegularExpression(@"^[^<>]+$", ErrorMessage = "Character < > are not allowed")]
        [MaxLength(254)]
        public string OfficeAddress { get; set; }=String.Empty;
        [MaxLength(254)]
        [RegularExpression(@"^[^<>]+$", ErrorMessage = "Character < > are not allowed")]
        public string Locality { get; set; } = String.Empty;
        [MaxLength(254)]
        [RegularExpression(@"^[^<>]+$", ErrorMessage = "Character < > are not allowed")]
        public string City { get; set; } = String.Empty;
        [MaxLength(32)]
        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^[^<>]+$", ErrorMessage = "Character < > are not allowed")]
        public string Pincode { get; set; } = String.Empty;
        public int StateId { get; set; }
        public int CountryId { get; set; }
        [NotMapped]
        public string StateName { get; set; } = String.Empty;
        [NotMapped]
        public string CountryName { get; set; } = String.Empty;
        [MaxLength(254)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = String.Empty;
        [MaxLength(254)]
        [DataType(DataType.EmailAddress)]
        public string AlternateEmail { get; set; } = String.Empty;
        [MaxLength(16)]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; } = String.Empty;
        [MaxLength(16)]
        [DataType(DataType.PhoneNumber)]
        public string AlternateContactNo { get; set; } = String.Empty;        
    }


    public class d_Address
    {
        
        public int AddressId { get; set; }
        public enmContactType ContactType { get; set; }
        [RegularExpression(@"^[^<>]+$", ErrorMessage = "Character < > are not allowed")]
        [MaxLength(254)]
        public string Address1 { get; set; } = String.Empty;
        [MaxLength(254)]
        [RegularExpression(@"^[^<>]+$", ErrorMessage = "Character < > are not allowed")]
        public string Address2 { get; set; } = String.Empty;
        [MaxLength(254)]
        [RegularExpression(@"^[^<>]+$", ErrorMessage = "Character < > are not allowed")]
        public string City { get; set; } = String.Empty;
        [MaxLength(32)]
        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^[^<>]+$", ErrorMessage = "Character < > are not allowed")]
        public string Pincode { get; set; } = String.Empty;
        public int StateId { get; set; }
        public int CountryId { get; set; }
        [NotMapped]
        public string StateName { get; set; } = String.Empty;
        [NotMapped]
        public string CountryName { get; set; } = String.Empty;
    }

    public class d_ContactDetails
    { 
        public int ContactId { get; set; }
        public enmContactType ContactType { get; set; }
        [MaxLength(254)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }      
        [MaxLength(16)]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; } 
    }
    public class d_BasicDetails
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Code { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string MiddleName { get; set; }
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }
        public enmGender Gender { get; set; }
        [MaxLength(90)]
        public string FatherName { get; set; }
        public DateTime Dob { get; set; }
        public bool IsActive { get; set; }        
    }
}
