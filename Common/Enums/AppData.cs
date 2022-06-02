using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum enmDefaultRole
    {
        SuperAdmin = 1,
        HRAdmin = 11,
        EmployeeManager = 21,
        Employee = 22,
        CustomerAdmin = 31,
        Distributor = 41
    }


    public enum enmApplication
    {
        [Application(IsArea: false, DisplayOrder: 3, Name: "HRMS", Description: "", Icon: "nav-icon fas fa-calculator", AreaName: "")]
        HRMS = 11,
        [Application(IsArea: false, DisplayOrder: 4, Name: "Asset Management", Description: "", Icon: "nav-icon fas fa-mobile", AreaName: "/Asset/Dashboard")]
        AssetManagement = 12,
        [Application(IsArea: false, DisplayOrder: 5, Name: "Time Sheeting", Description: "", Icon: "nav-icon fas fa-calendar", AreaName: "/Task/Dashboard")]
        ETS = 13,
    }
    public enum enmModule
    {
    }
    public enum enmSubModule
    {
    }
    public enum enmForms
    {
    }
    public enum enmClaim
    { 
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

        public Module(enmApplication EnmApplication, bool IsArea, int DisplayOrder, string Name, string Description, string Icon, string RouterUrl)
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





}
