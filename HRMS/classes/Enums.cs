namespace HRMS.classes
{
    public enum enmEmpType
    {
        None=0,
        FullTime=1,
        PartTime=2
    }

    public enum enmEmpCategory
    {
        None=0,
        Contract=1,
        SubContract=2,
        Temporary=3,
        Interns=4,
        FullTime=5,
        consultant=6
    }
    public enum enmEmpStatus
    {
        None = 0,
        Probation=1,
        Confirmed=2,
        Notice=3,
        separated=4,
        Terminated=5,
    }

    public enum enmQualification
    { 
        None=0,
        HighSchool=1,
        HigherSecondary=2,
        HigherSecondaryEqDiploma=3,        
        Graduation=4,
        PostGraduation=5,
        OtherDiploma=6,
        Doctrate=7,
        Other = 8,
    }

    public enum enmLeaveType :byte
    {
        Other=0,
        EarnedLeave=1,
        CasualLeave=2,
        SickLeave=3,
        MaternityLeave=4,
        CompensatoryOff=5,
        MarriageLeave=6,
        PaternityLeave=7,
        BereavementLeave=8,
        LeaveWithoutPay=10,//Loss of Pay (LOP) / Leave Without Pay (LWP)
    }

    public enum enmPunchType : byte
    {
        None=0,
        SinglePunchPresent=1,
        SinglePunchAbsent = 2,
        PunchExempted = 2,

    }
}
