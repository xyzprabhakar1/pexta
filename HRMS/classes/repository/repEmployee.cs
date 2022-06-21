using Common;
using HRMS.Database;
using HRMS.Models;

namespace HRMS.classes.repository
{
    public class repEmployee
    {
        
        private readonly HRMSContext _HRMSContext;
        public DataTableParameters dtp=null;
        public repEmployee(HRMSContext hrmsContext)
        {
            _HRMSContext = hrmsContext;
        }
        private void SetDefaultParameter()
        {
            if (this.dtp == null)
            {
                dtp = new DataTableParameters() { columns = new List<mdlDataTableColumn>(), order = new List<mdlDataOrder>(), search = new mdlSearch() { regex = false, value = "" } };
            }
        }

        private IQueryable<tblEmpDepartment> GetCurrentDepartmentQuery(DateTime EffectiveDt)
        {
            var TempQuery = _HRMSContext.tblEmpDepartment.Where(q => q.IsActive && q.EffectiveDt <= EffectiveDt).AsQueryable();
            var Query = TempQuery.GroupBy(q => q.EmpId)
                .Select(q => new { EmpId = q.Key, EffectiveDt = q.Max(r => r.EffectiveDt) })
                .Join(TempQuery, t1 => new { t1.EmpId, t1.EffectiveDt }, t2 => new { t2.EmpId, t2.EffectiveDt }, (t1, t2) => new { t1.EmpId, t1.EffectiveDt, t2.DepId, t2.EmpDepId })
                .GroupBy(q => new { q.EmpId, q.EffectiveDt })
                .Select(q => new { EmpId = q.Key.EmpId, EffectiveDt = q.Key.EffectiveDt, EmpDepId = q.Max(r => r.EmpDepId) })
                .Join(TempQuery, t1 => t1.EmpDepId, t2 => t2.EmpDepId, (t1, t2) => new tblEmpDepartment
                {
                    EmpDepId = t2.EmpDepId,
                    DepId = t2.DepId,
                    EmpId = t2.EmpId,
                    EffectiveDt = t2.EffectiveDt,
                    DepWorkingRoleId = t2.DepWorkingRoleId,
                    IsActive = t2.IsActive,
                    ModifiedRemarks = t2.ModifiedRemarks,
                    ModifiedBy = t2.ModifiedBy,
                    ModifiedDt = t2.ModifiedDt
                });
            return Query;
        }
        private IQueryable<tblEmpLocation> GetCurrentLocationQuery(DateTime EffectiveDt)
        {
            var TempQuery = _HRMSContext.tblEmpLocation.Where(q => q.IsActive && q.EffectiveDt <= EffectiveDt).AsQueryable();
            var Query = TempQuery.GroupBy(q => q.EmpId)
                .Select(q => new { EmpId = q.Key, EffectiveDt = q.Max(r => r.EffectiveDt) })
                .Join(TempQuery, t1 => new { t1.EmpId, t1.EffectiveDt }, t2 => new { t2.EmpId, t2.EffectiveDt }, (t1, t2) => new { t1.EmpId, t1.EffectiveDt, t2.LocationId, t2.EmpLocationId })
                .GroupBy(q => new { q.EmpId, q.EffectiveDt })
                .Select(q => new { EmpId = q.Key.EmpId, EffectiveDt = q.Key.EffectiveDt, EmpLocationId = q.Max(r => r.EmpLocationId) })
                .Join(TempQuery, t1 => t1.EmpLocationId, t2 => t2.EmpLocationId, (t1, t2) => new tblEmpLocation
                {
                    CompanyId = t2.CompanyId,
                    ZoneId = t2.ZoneId,
                    EmpLocationId = t2.EmpLocationId,
                    LocationId = t2.LocationId,
                    EmpId = t2.EmpId,
                    EffectiveDt = t2.EffectiveDt,
                    SubLocationId = t2.SubLocationId,
                    IsActive = t2.IsActive,
                    ModifiedRemarks = t2.ModifiedRemarks,
                    ModifiedBy = t2.ModifiedBy,
                    ModifiedDt = t2.ModifiedDt
                });
            return Query;
        }



        public IEnumerable<mdlEmployeeBasic> GetBasicDetail(DateTime EffectiveDt,bool AllData, Dictionary<uint,string> Departmentlst, Dictionary<uint,string> Locationlst , bool OnlyActive=true )
        {
            IEnumerable<mdlEmployeeBasic> empBasic = new List<mdlEmployeeBasic>();
            SetDefaultParameter();
            GetCurrentDepartmentQuery(EffectiveDt);
            GetCurrentLocationQuery(EffectiveDt);
            return empBasic;
        }
    }
}
