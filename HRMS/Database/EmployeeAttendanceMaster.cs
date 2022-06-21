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
        public uint  EmpAttendanceId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public uint? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblEmployeeMaster_log")] // Foreign Key here        
        public uint? EmpLogId { get; set; }
        public tblEmployeeMaster_log tblEmployeeMaster_log { get; set; }
        [ForeignKey("tblAttendanceGroup")] // Foreign Key here        
        public new uint? AttendanceGroupId { get; set; }
        public tblAttendanceGroup tblAttendanceGroup { get; set; }
        [NotMapped]
        public new string GroupName { get; set; }
        [NotMapped]
        public bool IsDefault { get; set; }
        public DateTime EffectiveFromDt { get; set; }
    }

    public class tblEmpLeaveGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint EmpGroupId { get; set; }
        [ForeignKey("tblEmpAttendance")] // Foreign Key here        
        public uint? EmpAttendanceId { get; set; }
        public tblEmpAttendance tblEmpAttendance { get; set; }
        [ForeignKey("tblLeaveMaster")] // Foreign Key here        
        public uint? LeaveId { get; set; }
        public tblLeaveMaster tblLeaveMaster { get; set; }
    }
    public class tblEmpHolidayGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint EmpGroupId { get; set; }
        [ForeignKey("tblEmpAttendance")] // Foreign Key here        
        public uint? EmpAttendanceId { get; set; }
        public tblEmpAttendance tblEmpAttendance { get; set; }
        [ForeignKey("tblHolidayMaster")] // Foreign Key here        
        public uint? HolidayId { get; set; }
        public tblHolidayMaster tblHolidayMaster { get; set; }
    }


}
