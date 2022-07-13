using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Database;
using Microsoft.EntityFrameworkCore;

namespace projMasters.Database
{
    public class MasterContext : CommonContext
    {
        public MasterContext(DbContextOptions<MasterContext> options) :base(options)
        { 
        }
    }
}
