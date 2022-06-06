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
}
