using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Database;
using Microsoft.EntityFrameworkCore;

namespace projMasters.Database
{
    //add-migration -s pextaApi Authentication -Context projMasters.Database.MasterContext -project projMasters
    //update-database -s pextaApi -Context projMasters.Database.MasterContext -project projMasters
    public class MasterContext : CommonContext
    {
        public MasterContext(DbContextOptions<MasterContext> options) :base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DefaultData.InsertCountryMaster(modelBuilder);
            DefaultData.InsertOrganisation(modelBuilder);
            DefaultData.InsertRoleMaster(modelBuilder);
            DefaultData.InsertDefaultUser(modelBuilder);            
        }
    }
}
