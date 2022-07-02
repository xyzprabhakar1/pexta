using Microsoft.EntityFrameworkCore;

namespace HRMS.Database
{
    public class HRMSContext : DbContext
    {
        //add-migration -s HRMS EmployeeMaster -Context HRMS.Database.HRMSContext
        //update-database -s HRMS -Context HRMS.Database.HRMSContext
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

        #region ************ Employee Master ******************
        public DbSet<tblEmployeeMaster> tblEmployeeMaster { get; set; }
        public DbSet<tblEmployeeMaster_log> tblEmployeeMaster_log { get; set; }
        public DbSet<tblEmpAddress> tblEmpAddress { get; set; }
        public DbSet<tblEmpAddress_Log> tblEmpAddress_Log { get; set; }
        public DbSet<tblEmpContacts> tblEmpContacts { get; set; }
        public DbSet<tblEmpContacts_Log> tblEmpContacts_Log { get; set; }        
        public DbSet<tblEmpDepartment> tblEmpDepartment { get; set; }
        public DbSet<tblEmpDepartment_log> tblEmpDepartment_log { get; set; }
        public DbSet<tblEmpLocation> tblEmpLocation { get; set; }
        public DbSet<tblEmpLocation_log> tblEmpLocation_log { get; set; }
        public DbSet<tblEmpDesignation> tblEmpDesignation { get; set; }
        public DbSet<tblEmpDesignation_log> tblEmpDesignation_log { get; set; }
        public DbSet<tblEmpManager> tblEmpManager { get; set; }
        public DbSet<tblEmpManager_log> tblEmpManager_log { get; set; }
        public DbSet<tblEmpOfficialDetails> tblEmpOfficialDetails { get; set; }
        public DbSet<tblEmpOfficialDetails_log> tblEmpOfficialDetails_log { get; set; }
        public DbSet<tblEmpPersonalDetails> tblEmpPersonalDetails { get; set; }
        public DbSet<tblEmpPersonalDetails_log> tblEmpPersonalDetails_log { get; set; }
        public DbSet<tblEmpDocument> tblEmpDocument { get; set; }
        public DbSet<tblEmpDocument_log> tblEmpDocument_log { get; set; }
        public DbSet<tblEmpBankDetails> tblEmpBankDetails { get; set; }
        public DbSet<tblEmpBankDetails_log> tblEmpBankDetails_log { get; set; }
        public DbSet<tblEmpFamilyDetails> tblEmpFamilyDetails { get; set; }
        public DbSet<tblEmpFamilyDetails_log> tblEmpFamilyDetails_log { get; set; }
        public DbSet<tblEmpQualification> tblEmpQualification { get; set; }
        public DbSet<tblEmpQualification_log> tblEmpQualification_log { get; set; }
        public DbSet<tblEmpWorkExperience> tblEmpWorkExperience { get; set; }
        public DbSet<tblEmpWorkExperience_log> tblEmpWorkExperience_log { get; set; }
        #endregion




    }
}
