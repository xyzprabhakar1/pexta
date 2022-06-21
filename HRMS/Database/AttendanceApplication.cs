using Common.Database;
using HRMS.classes;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database
{
    public class tblLeaveApplication: d_Approval
    {
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
    }
}
