using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    public class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        {

        }

        #region ************************ Code Genration master ********************
        public DbSet<tblCodeGenrationMaster> tblCodeGenrationMaster { get; set; }
        public DbSet<tblCodeGenrationDetails> tblCodeGenrationDetails { get; set; }
        public DbSet<tblCodeGenrationMaster_log> tblCodeGenrationMaster_log { get; set; }
        #endregion

        #region ************************ Organisation Master ********************
        public DbSet<tblOrganisation> tblOrganisation { get; set; }
        public DbSet<tblOrganisation_Log> tblOrganisation_Log { get; set; }
        public DbSet<tblCompanyMaster> tblCompanyMaster { get; set; }
        public DbSet<tblCompanyMaster_Log> tblCompanyMaster_Log { get; set; }
        public DbSet<tblZoneMaster> tblZoneMaster { get; set; }
        public DbSet<tblZoneMaster_Log> tblZoneMaster_Log { get; set; }
        public DbSet<tblLocationMaster> tblLocationMaster { get; set; }
        public DbSet<tblLocationMaster_Log> tblLocationMaster_Log { get; set; }
        #endregion

        #region ********************** Masters **************************
        public DbSet<tblCountry> tblCountry { get; set; }
        public DbSet<tblState> tblState { get; set; }
        public DbSet<tblBankMaster> tblBankMaster { get; set; }
        public DbSet<tblCurrency> tblCurrency { get; set; }
        #endregion


    }
}
