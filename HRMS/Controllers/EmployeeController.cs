using Common;
using HRMS.classes.repository;
using HRMS.Database;
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
        HRMSContext _hRMSContext;
        public EmployeeController(IserEmployee serEmployee, HRMSContext hRMSContext)
        {
            _serEmployee = serEmployee;
            _hRMSContext= hRMSContext;
        }
        [HttpPost]
        [Route("EmpBasicDetails")]
        public IEnumerable<mdlEmployeeBasic> EmpBasicDetails(DataTableParameters dtp = null)
        {
            DateTime CurrentDt = DateTime.Now;
            Dictionary<uint, string> Departmentlst = new Dictionary<uint, string>();
            Dictionary<uint, string> Locationlst = new Dictionary<uint, string>();
            return _serEmployee.GetBasicDetail(CurrentDt, false, Departmentlst, Locationlst, true);
            var tempData = _serEmployee.GetBasicDetail(CurrentDt, false, Departmentlst, Locationlst, true).ToList();
            return tempData;
        }
        [HttpPost]
        [Route("test")]
        public IEnumerable<tblEmpLocation> test()
        {
            return LinqHelper.CurrentData(_hRMSContext.tblEmpLocation, "EffectiveDt");
        }

    }
}
