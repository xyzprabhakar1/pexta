using Common.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database
{
    public class tblHolidayMaster :  d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint HolidayId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime Todate { get; set; }
        [MaxLength(64)]
        public string? HolidayName { get; set; }
        public bool IsActive { get; set; }
        
    }

    public class tblDepartment : d_Modified
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint DeptId { get; set; }
        [MaxLength(16)]
        public string Code { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public bool IsActive { get; set; }        
    }

    public class tblDepartWorkingRole : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint WorkingRoleId { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("tblDepartment")] // Foreign Key here
        public uint? DeptId { get; set; }
        public tblDepartment tblDepartment { get; set; }
        public uint OrgId { get; set; }
    }

    public class tblGrade : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public uint Level { get; set; }
        public bool IsActive { get; set; }
        public uint OrgId { get; set; }
    }
    public class tblDesignation : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public uint Level { get; set; }
        public bool IsActive { get; set; }
        public uint OrgId { get; set; }
    }
    public class tblReligionMaster : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public uint Level { get; set; }
        public bool IsActive { get; set; }
        public uint OrgId { get; set; }
    }

    public class tblMachineMaster : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint MachineId { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(64)]
        public string IPAddress { get; set; }
        public ushort Port { get; set; }
        [MaxLength(64)]
        public string Password { get; set;}
        public uint? LocationId { get; set; }
        public uint? SubLocationId { get; set; }
        [NotMapped]        
        public string LocationName { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string ZoneName { get; set; }
        [NotMapped]
        public string SubLocationName { get; set; }
        public bool IsActive { get; set; }
    }

}
