using Common;
using HRMS.classes.repository;
using HRMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IserEmployee _serEmployee;
        public EmployeeController(IserEmployee serEmployee)
        {
            _serEmployee = serEmployee;
        }
        [HttpPost]
        [Route("EmpBasicDetails")]
        public IEnumerable<mdlEmployeeBasic> EmpBasicDetails(DataTableParameters dtp=null)
        {
            DateTime CurrentDt = DateTime.Now;
            Dictionary<uint, string> Departmentlst = new Dictionary<uint, string>();
            Dictionary<uint, string> Locationlst = new Dictionary<uint, string>();
            return _serEmployee.GetBasicDetail(CurrentDt, false, Departmentlst, Locationlst, true);
            var tempData= _serEmployee.GetBasicDetail(CurrentDt, false, Departmentlst, Locationlst, true).ToList();
            return tempData;
        }

    }
}
