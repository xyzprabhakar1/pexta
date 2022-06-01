using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    public class AppData : IModified
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ApiBaseUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        public string ModifiedRemarks { get; set; }
        public DateTime CreatedDt { get; set; }
        public int CreatedBy { get; set; }
    }
    
}
