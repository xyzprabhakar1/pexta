using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum enmDefaultRole: UInt16
    {
        SuperAdmin = 1,
        HRAdmin = 11,
        EmployeeManager = 21,
        Employee = 22,
        CustomerAdmin = 31,
        Distributor = 41
    }
    public enum enmDocumentType : UInt16
    {
        None = 0,
        Create = 1,
        Update = 2,
        Approval = 4,
        Delete = 8,
        Report = 16,
        PendingReport = 32,
        DetailView = 64,
        DisplayMenu = 128
    }


    public enum enmApplication
    {
        [Application(DisplayOrder: 0, Name: "None", Description: "", Icon: "nav-icon fas fa-calculator", RouterUrl: "")]
        None = 1,
        [Application( DisplayOrder: 1, Name: "HRMS", Description: "", Icon: "nav-icon fas fa-calculator", RouterUrl: "hrms")]
        HRMS = 11,
        [Application(DisplayOrder: 2, Name: "Asset Management", Description: "", Icon: "nav-icon fas fa-mobile", RouterUrl: "asset-management")]
        AssetManagement = 12,
        [Application(DisplayOrder: 3, Name: "Time Sheeting", Description: "", Icon: "nav-icon fas fa-calendar", RouterUrl: "ets")]
        ETS = 13,
        [Application(DisplayOrder: 4, Name: "Point of Sale", Description: "", Icon: "nav-icon fas fa-calendar", RouterUrl: "pos")]
        POS = 14,
        [Application(DisplayOrder: 5, Name: "CRM", Description: "", Icon: "nav-icon fas fa-calendar", RouterUrl: "crm")]
        CRM = 15,
        [Application(DisplayOrder: 6, Name: "SRM", Description: "", Icon: "nav-icon fas fa-calendar", RouterUrl: "srm")]
        SRM = 16,
    }
    public enum enmModule
    {
        [Module(EnmApplication: enmApplication.None, DisplayOrder: 0, Name: "Organisation", Description: "", Icon: "nav-icon far fa-plus-square", RouterUrl: "")]
        None=1,

        [Module(enmApplication.HRMS, DisplayOrder: 0, Name: "Master", Description: "", Icon: "nav-icon far fa-plus-square", RouterUrl: "master")]
        HRMS_Master = 1100,

    }
    public enum enmSubModule
    {
        [SubModule(EnmModule: enmModule.None, DisplayOrder: 0, Name: "Organisation", Description: "", Icon: "nav-icon far fa-plus-square", RouterUrl: "organisation")]
        Organisation = 1,
        [SubModule(EnmModule: enmModule.None, DisplayOrder: 0, Name: "Masters", Description: "", Icon: "nav-icon far fa-plus-square", RouterUrl: "master")]
        Masters = 2,
        [SubModule(EnmModule: enmModule.None, DisplayOrder: 5, Name: "Authentication ", Description: "", Icon: "nav-icon far fa-plus-square", RouterUrl: "authentication")]
        Authentication = 10,
        
    }
    public enum enmDocumentMaster
    {
        [Document(EnmSubModule : enmSubModule.Organisation , DocumentType: enmDocumentType.DetailView | enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu | enmDocumentType.PendingReport | enmDocumentType.Approval,
            DisplayOrder: 1, Name: "Organisation", Description: "Dashboard the Orgasnisation Details", Icon: "far fa-circle nav-icon", RouterUrl : "Organisation")]
        Organisation = 2,
        [Document(EnmSubModule: enmSubModule.Organisation, DocumentType: enmDocumentType.Create | enmDocumentType.Update | enmDocumentType.DetailView | enmDocumentType.Report | enmDocumentType.DisplayMenu | enmDocumentType.PendingReport | enmDocumentType.Approval,
            DisplayOrder: 2, Name: "Company", Description: "Company", Icon: "far fa-circle nav-icon", RouterUrl: "company")]
        Company = 3,
        [Document(EnmSubModule: enmSubModule.Organisation, DocumentType: enmDocumentType.Create | enmDocumentType.Update | enmDocumentType.DetailView | enmDocumentType.Report | enmDocumentType.DisplayMenu | enmDocumentType.PendingReport | enmDocumentType.Approval,
            DisplayOrder: 3, Name: "Zone", Description: "Zone", Icon: "far fa-circle nav-icon", RouterUrl: "zone")]
        Zone = 4,
        [Document(EnmSubModule: enmSubModule.Organisation, DocumentType: enmDocumentType.Create | enmDocumentType.Update | enmDocumentType.DetailView | enmDocumentType.Report | enmDocumentType.DisplayMenu | enmDocumentType.PendingReport | enmDocumentType.Approval,
            DisplayOrder: 4, Name: "Location", Description: "Location", Icon: "far fa-circle nav-icon", RouterUrl: "location")]
        Location = 5,

        [Document(EnmSubModule: enmSubModule.Authentication, DocumentType: enmDocumentType.Create | enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
            DisplayOrder: 1, Name: "Org Permission", Description: "Organisation Permission", Icon: "far fa-circle nav-icon", RouterUrl: "org-permission")]
        Org_Permission = 6,
        [Document(EnmSubModule: enmSubModule.Authentication, DocumentType: enmDocumentType.Create | enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
            DisplayOrder: 1, Name: "User Permission", Description: "User Permission", Icon: "far fa-circle nav-icon", RouterUrl: "user-permission")]
        User_Permission = 7,


        //[Document(enmApplication.HRMS, DocumentType: enmDocumentType.Create | enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
        //    DisplayOrder: 1, Name: "Dashboard", Description: "Hrms Dashboard", Icon: "far fa-circle nav-icon", ActionName: "/HRMS/Master/Dashboard")]
        //HRMS_Dashboard = 1100,
        [Document( EnmSubModule: enmSubModule.Masters, enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
            DisplayOrder: 1, Name: "Holiday", Description: "Holiday", Icon: "far fa-circle nav-icon", RouterUrl: "holiday")]
        HRMS_Holiday = 1101,
        //[Document(EnmSubModule: enmSubModule.HRMS_Holiday, enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
        //    DisplayOrder: 1, Name: "Assign Holiday", Description: "Holiday", Icon: "far fa-circle nav-icon", ActionName: "/HRMS/Master/AssignHoliday")]
        //HRMS_Holiday_Assign = 1102,
        [Document( EnmSubModule: enmSubModule.Masters, enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
            DisplayOrder: 1, Name: "Department", Description: "Department", Icon: "far fa-circle nav-icon", RouterUrl: "/HRMS/Master/Department")]
        HRMS_Department = 1103,
        //[Document(enmApplication.HRMS, EnmModule: enmModule.HRMS_Master, EnmSubModule: enmSubModule.HRMS_Department, enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
        //    DisplayOrder: 1, Name: "Assign Department", Description: "Department", Icon: "far fa-circle nav-icon", ActionName: "/HRMS/Master/AssignDepartment")]
        //HRMS_Department_Assign = 1104,
        [Document(EnmSubModule: enmSubModule.Masters, enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
            DisplayOrder: 1, Name: "Working Role", Description: "Working Role", Icon: "far fa-circle nav-icon", RouterUrl: "working-role")]
        HRMS_Working_Role = 1105,
        //[Document(enmApplication.HRMS, EnmModule: enmModule.HRMS_Master, EnmSubModule: enmSubModule.HRMS_WorkingRole, enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
        //    DisplayOrder: 1, Name: "Assign WorkingRole", Description: "Working Role", Icon: "far fa-circle nav-icon", ActionName: "/HRMS/Master/AssignWorkingRole")]
        //HRMS_Assign_Working_Role = 1106,
        [Document(EnmSubModule: enmSubModule.Masters, enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
            DisplayOrder: 1, Name: "Grade", Description: "Grade", Icon: "far fa-circle nav-icon", RouterUrl: "grade")]
        HRMS_Grade = 1107,
        //[Document(enmApplication.HRMS, EnmModule: enmModule.HRMS_Master, EnmSubModule: enmSubModule.HRMS_Grade, enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
        //    DisplayOrder: 1, Name: "Assign Grade", Description: "Grade", Icon: "far fa-circle nav-icon", ActionName: "/HRMS/Master/AssignGrade")]
        //HRMS_Grade_Assign = 1108,
        [Document( EnmSubModule: enmSubModule.Masters, enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
            DisplayOrder: 1, Name: "Designation", Description: "Designation", Icon: "far fa-circle nav-icon", RouterUrl: "designation")]
        HRMS_Designation = 1109,
        //[Document(enmApplication.HRMS, EnmModule: enmModule.HRMS_Master, EnmSubModule: enmSubModule.HRMS_Designation, enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
        //    DisplayOrder: 1, Name: "Assign Designation", Description: "Designation", Icon: "far fa-circle nav-icon", ActionName: "/HRMS/Master/AssignDesignation")]
        //HRMS_Designation_Assign = 1110,
        [Document(EnmSubModule: enmSubModule.Masters, enmDocumentType.Update | enmDocumentType.Report | enmDocumentType.DisplayMenu,
            DisplayOrder: 1, Name: "Religion", Description: "Religion", Icon: "far fa-circle nav-icon", RouterUrl: "religion")]
        HRMS_Religion = 1111,
    }
    


    public interface IDocuments
    {
        int DisplayOrder { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Icon { get; set; }
        string RouterUrl { get; set; }
    }


    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class Application : Attribute, IDocuments
    {
        public Application(int DisplayOrder, string Name, string Description, string Icon, string RouterUrl)
        {

            
            this.DisplayOrder = DisplayOrder;
            this.Name = Name;
            this.Description = Description;
            this.Icon = Icon;
            this.RouterUrl = RouterUrl;
        }
        public virtual int Id { get; set; }        
        public int DisplayOrder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string RouterUrl { get; set; }
        public virtual List<Module> Modules { get; set; }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class Module : Attribute, IDocuments
    {
        public Module(int DisplayOrder, string Name, string Description, string Icon, string RouterUrl)
        {
            
            this.DisplayOrder = DisplayOrder;
            this.Description = Description;
            this.Name = Name;
            this.Icon = Icon;
            this.RouterUrl = RouterUrl;
            
        }
        public Module(enmApplication EnmApplication, int DisplayOrder, string Name, string Description, string Icon, string RouterUrl)
        {
            this.EnmApplication = EnmApplication;            
            this.DisplayOrder = DisplayOrder;
            this.Description = Description;
            this.Name = Name;
            this.Icon = Icon;
            this.RouterUrl = RouterUrl;
        }
        public virtual int Id { get; set; }
        public enmApplication? EnmApplication { get; set; }        
        public int DisplayOrder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string RouterUrl { get; set; }                
    }


    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class SubModule : Attribute, IDocuments
    {
        public SubModule(enmModule EnmModule, int DisplayOrder, string Name, string Description, string Icon, string RouterUrl)
        {
            this.EnmModule = EnmModule;
            this.DisplayOrder = DisplayOrder;
            this.Description = Description;
            this.Name = Name;
            this.RouterUrl = RouterUrl;
            this.Icon = Icon;
        }
        public virtual int Id { get; set; }
        public enmModule EnmModule { get; set; }
        public int DisplayOrder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string RouterUrl { get; set; }
        public virtual List<Document> Documents { get; set; }

    }

    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class Document : Attribute, IDocuments
    {

        public Document(enmModule EnmModule, enmDocumentType DocumentType, int DisplayOrder, string Name, string Description,
            string Icon, string RouterUrl, string[] AdditionalClaim = null)
        {

            this.DocumentType = DocumentType;
            this.DisplayOrder = DisplayOrder;
            this.Description = Description;
            this.Name = Name;
            this.Icon = Icon;
            this.RouterUrl = RouterUrl;
            this.EnmModule = EnmModule;
            this.AdditionalClaim = AdditionalClaim;
        }

        public Document(enmModule EnmModule, enmSubModule EnmSubModule, enmDocumentType DocumentType, int DisplayOrder, string Name, string Description,
            string Icon, string RouterUrl, string[] AdditionalClaim = null)
        {

            this.DocumentType = DocumentType;
            this.DisplayOrder = DisplayOrder;
            this.Description = Description;
            this.Name = Name;
            this.Icon = Icon;
            this.RouterUrl = RouterUrl;
            this.EnmSubModule = EnmSubModule;
            this.EnmModule = EnmModule;
            this.AdditionalClaim = AdditionalClaim;
        }
        public Document(enmSubModule EnmSubModule, enmDocumentType DocumentType, int DisplayOrder, string Name, string Description,
            string Icon, string RouterUrl, string[] AdditionalClaim = null)
        {
            this.DocumentType = DocumentType;
            this.DisplayOrder = DisplayOrder;
            this.Description = Description;
            this.Name = Name;
            this.Icon = Icon;
            this.RouterUrl = RouterUrl;
            this.EnmSubModule = EnmSubModule;
            this.AdditionalClaim = AdditionalClaim;
        }

        public Document(enmApplication EnmApplication, enmDocumentType DocumentType, int DisplayOrder, string Name, string Description,
            string Icon, string RouterUrl, string[] AdditionalClaim = null)
        {
            this.EnmApplication = EnmApplication;
            this.DocumentType = DocumentType;
            this.DisplayOrder = DisplayOrder;
            this.Description = Description;
            this.Name = Name;
            this.Icon = Icon;
            this.RouterUrl = RouterUrl;
            this.AdditionalClaim = AdditionalClaim;
        }

       

        public Document(enmApplication EnmApplication, enmModule EnmModule, enmSubModule EnmSubModule, enmDocumentType DocumentType, int DisplayOrder, string Name, string Description,
            string Icon, string RouterUrl, string[] AdditionalClaim = null)
        {
            this.EnmApplication = EnmApplication;
            this.DocumentType = DocumentType;
            this.DisplayOrder = DisplayOrder;
            this.Description = Description;
            this.Name = Name;
            this.Icon = Icon;
            this.RouterUrl = RouterUrl;
            this.EnmSubModule = EnmSubModule;
            this.EnmModule = EnmModule;
            this.AdditionalClaim = AdditionalClaim;
        }
        public Document(enmApplication EnmApplication, enmSubModule EnmSubModule, enmDocumentType DocumentType, int DisplayOrder, string Name, string Description,
            string Icon, string RouterUrl, string[] AdditionalClaim=null)
        {
            this.EnmApplication = EnmApplication;
            this.DocumentType = DocumentType;
            this.DisplayOrder = DisplayOrder;
            this.Description = Description;
            this.Name = Name;
            this.Icon = Icon;
            this.RouterUrl = RouterUrl;
            this.EnmSubModule = EnmSubModule;
            this.AdditionalClaim = AdditionalClaim;
        }


        public enmApplication? EnmApplication { get; set; }
        public virtual int Id { get; set; }
        public enmSubModule? EnmSubModule { get; set; }
        public enmDocumentType DocumentType { get; set; }
        public string Description { get; set; }
        public enmModule? EnmModule { get; set; }
        public int DisplayOrder { get; set; }
        public string Name { get; set; }
        public string RouterUrl { get; set; }
        public string Icon { get; set; }
        public string[]AdditionalClaim { get; set;}
        public bool HaveCreate { get { return DocumentType.HasFlag(enmDocumentType.Create); } }
        public bool HaveUpdate { get { return DocumentType.HasFlag(enmDocumentType.Update); } }
        public bool HaveApproval { get { return DocumentType.HasFlag(enmDocumentType.Approval); } }
        public bool HaveDelete { get { return DocumentType.HasFlag(enmDocumentType.Delete); } }
        public bool HaveReport { get { return DocumentType.HasFlag(enmDocumentType.Report); } }
        public bool PendingReport { get { return DocumentType.HasFlag(enmDocumentType.PendingReport); } }
        public bool HaveDisplayMenu { get { return DocumentType.HasFlag(enmDocumentType.DisplayMenu); } }
        public bool HaveDetailView { get { return DocumentType.HasFlag(enmDocumentType.DetailView); } }
    }






}
