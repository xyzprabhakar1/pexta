using Common.CustomAttribute;

namespace HRMS.Models
{
    public class mdlEmployeeBasic
    {
        public uint Id { get; set; }
        [IsFilterAllowed(true)]
        public string Code { get; set; }
        public string Title { get; set; }
        [IsFilterAllowed(true)]
        public string EmpName { get; set; }
        [IsFilterAllowed(true)]
        public DateTime JoiningDt { get; set; }
        public bool IsActive { get; set; }
        [IsFilterAllowed(true)]
        public string OfficialEmail { get; set; }
        [IsFilterAllowed(true)]
        public string OfficialContactNo { get; set; }
        public uint DepId { get; set; }
        [IsFilterAllowed(true)]
        public string DepartmentName{ get; set; }
        public uint LocationId { get; set; }
        public uint SubLocationId { get; set; }
    }

    
}
