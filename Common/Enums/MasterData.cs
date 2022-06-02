using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum enmCodeGenrationType
    {
        Employee = 1,
        Customer = 2,
        Distributor = 3,
    }
    public enum enmLocationType
    {
        [Description("None")]
        None =0,
        [Description("Head Office")]
        HeadOffice = 1,
        [Description("Branch")]
        Branch = 2,
        [Description("Warehouse")]
        Warehouse = 3,
        [Description("Factory")]
        Factory = 4,
        [Description("Retail Store")]
        RetailStore = 5,
        [Description("Franchisees")]
        Franchisees = 6,
    }
    public enum enmFileType
    {
        ImageJPG = 1,
        ImageICO = 2,
        ImagePNG = 3,
        ImageBMP = 4,
        FileXLS = 5,
        FileXLSX = 6,
        FileDOC = 7,
        FileDOCX = 8,
        FilePDF = 9
    }

}
