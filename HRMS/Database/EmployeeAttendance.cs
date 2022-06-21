using Common.Database;
using Common.Enums;
using HRMS.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database
{
    public class tblEmployeeMachinePunch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint PunchId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public uint? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        [ForeignKey("tblMachineMaster")] // Foreign Key here        
        public uint? MachineId { get; set; }
        public tblMachineMaster tblMachineMaster { get; set; }
        [ForeignKey("tblMachineMaster")] // Foreign Key here        
        public DateTime PunchTime { get; set; }
        public DateTime CreatedDt { get; set; }
    }
    public class tblEmployeeMobilePunch: d_CreatedModified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint PunchId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public uint? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        public DateTime InTime { get; set; }
        public DateTime? OutTime { get; set; }        
    }
    public class tblEmployeeManualPunch : d_CreatedModified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint PunchId { get; set; }
        [ForeignKey("tblEmployeeMaster")] // Foreign Key here        
        public uint? EmpId { get; set; }
        public tblEmployeeMaster tblEmployeeMaster { get; set; }
        public DateTime InTime { get; set; }
        public DateTime? OutTime { get; set; }
    }
    public class tblEmployeeAttendance
    {
        [Key]
        public uint EmpId { get; set; }
        [Key]
        public DateTime AttendanceDt { get; set; }
        public DateTime InTime { get; set; }
        public DateTime? OutTime { get; set; }
        [ForeignKey("tblShiftMaster")] 
        public int? ShiftId { get; set; }
        public tblShiftMaster tblShiftMaster { get; set; }
        public DateTime ShiftInTime { get; set; }
        public DateTime ShiftMaxInTime { get; set; }
        public DateTime ShiftOutTime { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsWeekoff { get; set; }
        public bool IsLeaveApplied { get; set; }
        public bool IsSandwichApplied { get; set; }
        public bool IsLateIn { get; set; }
        public bool IsGraceApplied { get; set; }
        public bool IsOtApplied { get; set; }
        public bool IsOutdoorApplied { get; set; }
        public bool IsMobilepunchApplied { get; set; }
        public bool IsManualPunchApplied { get; set; }
        public bool IsRegularizeApplied { get; set; }
        public ushort OtMinuter { get; set; }
        public ushort TotalWorkingMinute { get; set; }
        public ushort NetWorkingMinute { get; set; }
        public enmDayStatus DayStatus { get; set; }
        public enmPaidStatus PaidStatus { get; set; }
    }
    public class tblEmployeeAttendanceLeaveDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint DetailId { get; set; }
        public uint EmpId { get; set; }        
        public DateTime AttendanceDt { get; set; }
        
    }

}
