using Common.Database;
using HRMS.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database
{
    public class tblLeaveApplication: d_Approval_with_delete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint ApplicationId { get; set; }
        [ForeignKey("tblLeaveMaster")] // Foreign Key here        
        public uint? LeaveId { get; set; }
        public tblLeaveMaster tblLeaveMaster { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public uint? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        public enmLeaveType LeaveType { get; set; }
        public enmApplicabilityType ApplicabilityType { get; set; }
        public enmDayPart DayPart { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class tblOutdoorApplication : d_Approval_with_delete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint ApplicationId { get; set; }
        public DateTime AttendanceDt { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public uint? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
    }

    public class tblAttendanceApplication : d_Approval_with_delete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint ApplicationId { get; set; }
        public DateTime AttendanceDt { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [ForeignKey("tblEmployeeMaster")] 
        public uint? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
    }

    public class tblRosterWeekOffApplication : d_Approval_with_delete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint ApplicationId { get; set; }
        public DateTime WeekoffDt { get; set; }        
        [ForeignKey("tblEmployeeMaster")]
        public uint? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
    }
}
