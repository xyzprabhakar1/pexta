namespace HRMS.Models
{
    public class mdlEmployeeBasic
    {
        public uint Id { get; set; }        
        public string Code { get; set; }
        public string EmpName { get; set; }
        public DateTime JoiningDt { get; set; }
        public bool IsActive { get; set; }
        public string OfficialEmail { get; set; }
        public string OfficialContactNo { get; set; }
        public uint DepId { get; set; }
        public uint LocationId { get; set; }
        public uint SubLocationId { get; set; }
    }
}
