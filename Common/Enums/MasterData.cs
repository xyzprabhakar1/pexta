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

    public enum enmUserType
    {
        SuperAdmin = 1,
        Employee = 2,
        Customer = 4,
        Vendor = 8,
    }
    public enum enmGender
    {
        None = 0,
        Male = 1,
        Female = 2,
        Other=3        
    }
    public enum enmTitle
    {
        None = 0,
        MR = 1,
        MRS = 2,
        MISS = 3,
        MASTER = 4
    }
    public enum enmContactType
    {
        Official=1,
        Primary = 2,
        Corresponding = 3,
        Emergency = 4,
    }
    public enum enmReligion
    {
        Christianity = 1,
        Islam = 2,
        Hinduism = 3,
        Buddhism = 4,
        Atheism = 5,
        Baháí = 6,
        Confucianism = 7,
        Druze = 8,
        Gnosticism = 9,
        Jainism = 10,
        Judaism = 11,
        Rastafarianism = 12,
        Shinto = 13,
        Sikhism = 14,
        Zoroastrianism = 15,
        TraditionalAfrican = 16,
        AfricanDiaspora = 17,
        IndigenousAmerican = 18,
        Other = 101
    }
    public enum enmMaritalStatus
    {
        Single = 1,
        Married = 2,
        Widowed = 3,
        Divorced = 4,
        Other = 101
    }

    public enum enmFamily
    {
        Father = 1,
        Mother = 2,
        Husband = 3,
        Wife = 4,
        Son = 5,
        Daughter = 6,
        GrandMother = 7,
        GrandFather = 8,
        Brother = 9,
        Sister = 10,
        Other = 101
    }

}
