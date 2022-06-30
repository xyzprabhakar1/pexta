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
        }
        [HttpPost]
        [Route("test")]
        public IEnumerable<tblEmpLocation> test()
        {
            return LinqHelper.CurrentData(_hRMSContext.tblEmpLocation, p=>p.EmpId, p=>new {p.EffectiveDt,p.EmpLocationId });
        }
        [HttpPost]
        [Route("test1")]
        public dynamic test1()
        {
          var tempData= _hRMSContext.tblEmpLocation.Where(p=>p.EmpId==400).OrderBy(p=>p.EffectiveDt).DistinctBy(p=>p.EmpId);
            return tempData;


        }

    }
}
