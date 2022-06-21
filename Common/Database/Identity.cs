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
    public class tblCodeGenrationMaster : d_Modified
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public enmCodeGenrationType CodeGenrationType { get; set; }
        public string Prefix { get; set; }=String.Empty;
        public bool IncludeCountryCode { get; set; }
        public bool IncludeStateCode { get; set; }
        public bool IncludeCompanyCode { get; set; }
        public bool IncludeZoneCode { get; set; }
        public bool IncludeLocationCode { get; set; }
        public bool IncludeYear { get; set; }
        public bool IncludeMonthYear { get; set; }
        public bool IncludeYearWeek { get; set; }
        public byte DigitFormate { get; set; }        

    }
    public class tblCodeGenrationDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Sno { get; set; }
        [ForeignKey("tblCodeGenrationMaster")] // Foreign Key here
        public uint? Id { get; set; }
        public tblCodeGenrationMaster tblCodeGenrationMaster { get; set; }
        public string CountryCode { get; set; } = "";
        public string StateCode { get; set; } = "";
        public string CompanyCode { get; set; } = "";
        public string ZoneCode { get; set; } = "";
        public string LocationCode { get; set; } = "";
        public uint MonthYear { get; set; }
        public uint Year { get; set; }
        public uint YearWeek { get; set; }
        public uint Counter { get; set; } = 1;
        [Timestamp]
        [ConcurrencyCheck]
        public byte[] RowVersion { get; set; }        

    }

    #region ********************Log Tables ******************************
    public class tblCodeGenrationMaster_log : tblCodeGenrationMaster, IRequested, IApproval
    {
        [ForeignKey("tblCodeGenrationMaster")] // Foreign Key here
        public uint? CodeGenrationMasterId { get; set; }
        public tblCodeGenrationMaster tblCodeGenrationMaster { get; set; }
        public enmEntityType EntityType { get; set; } = enmEntityType.Create;
        public DateTime RequestedDt { get; set; }
        public uint RequestedBy { get; set; }
        [MaxLength(256)]        
        public string RequestedRemarks { get; set; } = string.Empty;
        public DateTime? ApprovalDt { get; set; }
        public uint? ApprovalBy { get; set; }
        [MaxLength(256)]        
        public string ApprovalRemarks { get; set; } = string.Empty;
        public enmApprovalStatus ApprovalStatus { get; set; }
    }
    

    #endregion
}
