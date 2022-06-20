using Common.Enums;
using HRMS.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database
{
    public class tblEmpAttendance: tblAttendanceGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  EmpAttendanceId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public int? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmployeeMaster_log")] // Foreign Key here        
        public int? EmpLogId { get; set; }
        public tblEmployeeMaster_log tblEmployeeMaster_log { get; set; }
        [ForeignKey("tblAttendanceGroup")] // Foreign Key here        
        public new int? AttendanceGroupId { get; set; }
        public tblAttendanceGroup tblAttendanceGroup { get; set; }
        public DateTime EffectiveFromDt { get; set; }
    }

    public class tblEmpLeaveGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpGroupId { get; set; }
        [ForeignKey("tblEmpAttendance")] // Foreign Key here        
        public int? EmpAttendanceId { get; set; }
        public tblEmpAttendance tblEmpAttendance { get; set; }
        [ForeignKey("tblLeaveMaster")] // Foreign Key here        
        public int? LeaveId { get; set; }
        public tblLeaveMaster tblLeaveMaster { get; set; }
    }
    public class tblEmpHolidayGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpGroupId { get; set; }
        [ForeignKey("tblEmpAttendance")] // Foreign Key here        
        public int? EmpAttendanceId { get; set; }
        public tblEmpAttendance tblEmpAttendance { get; set; }
        [ForeignKey("tblHolidayMaster")] // Foreign Key here        
        public int? HolidayId { get; set; }
        public tblHolidayMaster tblHolidayMaster { get; set; }
    }
}
