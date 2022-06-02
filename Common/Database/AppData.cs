using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    public class AppData : d_Modified
    {
        public enmApplication Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }=String.Empty;
        [MaxLength(256)]
        public string Url { get; set; } = String.Empty;
        [MaxLength(256)]
        public string ApiBaseUrl { get; set; } = String.Empty;
        public bool IsActive { get; set; }        
    }
    
}
