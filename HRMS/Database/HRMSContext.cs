using Microsoft.EntityFrameworkCore;

namespace HRMS.Database
{
    public class HRMSContext : DbContext
    {
        //add-migration -s projApi 31_Oct_20211 -Context projContext.DB.HRMS.HRMSContext
        //update-database -s projApi -Context projContext.DB.HRMS.HRMSContext
        public HRMSContext(DbContextOptions<HRMSContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<tblHolidayMaster> tblHolidayMaster { get; set; }
        public DbSet<tblDepartment> tblDepartment { get; set; }
        public DbSet<tblDepartWorkingRole> tblDepartWorkingRole { get; set; }
        public DbSet<tblGrade> tblGrade { get; set; }
        public DbSet<tblDesignation> tblDesignation { get; set; }
        public DbSet<tblReligionMaster> tblReligionMaster { get; set; }
    }
}
