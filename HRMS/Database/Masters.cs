using Common.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Database
{
    public class tblHolidayMaster :  d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HolidayId { get; set; }
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
        public int DeptId { get; set; }
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
        public int WorkingRoleId { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("tblDepartment")] // Foreign Key here
        public int? DeptId { get; set; }
        public tblDepartment tblDepartment { get; set; }
        public int OrgId { get; set; }
    }

    public class tblGrade : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public int Level { get; set; }
        public bool IsActive { get; set; }
        public int OrgId { get; set; }
    }
    public class tblDesignation : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public int Level { get; set; }
        public bool IsActive { get; set; }
        public int OrgId { get; set; }
    }
    public class tblReligionMaster : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public int Level { get; set; }
        public bool IsActive { get; set; }
        public int OrgId { get; set; }
    }

    public class tblMachineMaster : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MachineId { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(64)]
        public string IPAddress { get; set; }
        public ushort Port { get; set; }
        [MaxLength(64)]
        public string Password { get; set;}
        public int? LocationId { get; set; }
        public int? SubLocationId { get; set; }
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
