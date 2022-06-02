using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    public class tblCountry : d_Modified 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }  // primary key  must be public!
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string ContactPrefix { get; set; }
        public bool IsActive { get; set; }

    }

    public class tblState : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }  // primary key  must be public!
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("tblCountry")]
        public int? CountryId { get; set; }
        public tblCountry tblCountry { get; set; }

    }


    public class tblBankMaster : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankId { get; set; }
        [MaxLength(256)]
        public string BankName { get; set; }
        public bool IsActive { get; set; }
    }
    public class tblCurrency : d_Modified
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrencyId { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(8)]
        public string Symbol { get; set; }
        public bool IsActive { get; set; }
    }
}
