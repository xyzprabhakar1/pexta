using Common.Enums;
using HRMS.classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database
{
    public class tblAttendanceGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceGroupId { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public enmPunchType PunchType { get; set; }
        public bool IsSandwichApplicable { get; set; }
        public bool IsOverTimeApplicable { get; set; }
        [ForeignKey("tblOverTimeMaster")]
        public int? OvertimeId { get; set; }
        public tblOverTimeMaster tblOverTimeMaster { get; set; }
        public bool IsCompoffApplicable { get; set; }
        public bool IsRosterApplicable { get; set; }
        public bool IsMobilePunchApplicable { get; set; }
        public bool IsGraceTimeAllowed { get; set; }
        public int MaxGraceTimeMinute { get; set; }
        public int GraceTimeCountAllowed { get; set; }
        [ForeignKey("tblShiftMaster")] 
        public int? ShiftId { get; set; }
        public tblShiftMaster tblShiftMaster { get; set; }
        [ForeignKey("tblWeekoffMaster")]
        public int? Weekoff { get; set; }
        public tblWeekoffMaster tblWeekoffMaster { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }
    public class tblAttendanceGroupLeave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tblAttendanceGroup")] // Foreign Key here        
        public int? AttendanceGroupId { get; set; }
        public tblAttendanceGroup tblAttendanceGroup { get; set; }
        [ForeignKey("tblLeaveMaster")] // Foreign Key here        
        public int? LeaveId { get; set; }
        public tblLeaveMaster tblLeaveMaster { get; set; }
    }

    public class tblAttendanceGroupHoliday
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tblAttendanceGroup")] // Foreign Key here        
        public int? AttendanceGroupId { get; set; }
        public tblAttendanceGroup tblAttendanceGroup { get; set; }
        [ForeignKey("tblHolidayMaster")] // Foreign Key here        
        public int? HolidayId { get; set; }
        public tblHolidayMaster tblHolidayMaster { get; set; }
    }




    public class tblShiftMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShiftId { get; set; }  
        [MaxLength(64)]
        public string ShiftName { get; set; }
        public bool IsNightShift { get; set; }
        public bool IsDynamicShift { get; set; }
        public DateTime InTime { get; set; }
        public DateTime MaxInTime { get; set; }
        public DateTime OutTime { get; set; }
        public DateTime BreakTimeStart { get; set; }
        public DateTime BreakEndStart { get; set; }
        public byte TotalShiftHour { get; set; }
        public byte TotalShiftMinute { get; set; }
        public byte NetShiftHour { get; set; }
        public byte NetShiftMinute { get; set; }
        public byte HalfShiftHour { get; set; }
        public byte HalfShiftMinute { get; set; }
        public bool IsBreakPunchApplicable { get; set; }
        public bool IsEarlyPunchConsider { get; set; } //Consider Early Punch in Working Time
        public int MaxEarlyInMinute { get; set; }
        public int MaxLateOutMinute { get; set; }        
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class tblWeekoffMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WeekoffId { get; set; }
        [MaxLength(64)]
        public string WeekoffName { get; set; }
        public enmWeekOff Sunday { get; set; }
        public enmWeekOff Monday { get; set; }
        public enmWeekOff Tuesday { get; set; }
        public enmWeekOff Wednesday { get; set; }
        public enmWeekOff Thursday { get; set; }
        public enmWeekOff Friday { get; set; }
        public enmWeekOff Saturday { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }

    public class tblLeaveMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveId { get; set; }
        [MaxLength(64)]
        public string LeaveName { get; set; }
        public enmLeaveType LeaveType { get; set; }
        public bool IsHalfdayApplicable { get; set; }
        public enmFrequence CreditFrequence { get; set; }
        public double LeaveCreditValue { get; set; }
        public double LeaveYearlyCaping { get; set; }
        public double LeaveTotalCaping { get; set; }
        public double IsExpirable { get; set; }
        public enmFrequence ExpiryFrequence { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;
    }
    public class tblLeaveMaster_log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("tblLeaveMaster")] // Foreign Key here        
        public  int? LeaveId { get; set; }
        public tblLeaveMaster tblLeaveMaster { get; set; }
        [MaxLength(64)]
        public string LeaveName { get; set; }
        public enmLeaveType LeaveType { get; set; }
        public bool IsHalfdayApplicable { get; set; }
        public enmFrequence CreditFrequence { get; set; }
        public double LeaveCreditValue { get; set; }
        public double LeaveYearlyCaping { get; set; }
        public double LeaveTotalCaping { get; set; }
        public double IsExpirable { get; set; }
        public enmFrequence ExpiryFrequence { get; set; }
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

    public class tblOverTimeMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OverTimeId { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public bool CalculateOverTimeInHour { get; set; }
        public int MinHourOvertime { get; set; }
        public int MinMinuteOverTime { get; set; }
        public bool OverTimeCaping { get; set; }
        public int CapingInHour { get; set; }
        public int CapingInMinute { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        [MaxLength(256)]
        public string ModifiedRemarks { get; set; } = string.Empty;

    }

    






}
