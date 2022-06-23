﻿using Common;
using HRMS.Database;
using HRMS.Models;
using Common.Enums;

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

        private IQueryable<tblEmployeeMaster> GetCurrentEmpQuery(bool OnlyActive = true)
        {
            return OnlyActive ? _HRMSContext.tblEmployeeMaster.Where(p => p.IsActive) : _HRMSContext.tblEmployeeMaster;
        }

        private IQueryable<tblEmpContacts> GetEmpCurrentContact(enmContactType ContactType)
        {

            var TempQuery = _HRMSContext.tblEmpContacts.Where(q => q.ContactType== ContactType && q.IsActive).AsQueryable();            
            return TempQuery;
        }



        public IEnumerable<mdlEmployeeBasic> GetBasicDetail(DateTime EffectiveDt,bool AllData, Dictionary<uint,string> Departmentlst, Dictionary<uint,string> Locationlst , bool OnlyActive=true )
        {
            IEnumerable<mdlEmployeeBasic> empBasic = new List<mdlEmployeeBasic>();
            var EmpQuery= GetCurrentEmpQuery(OnlyActive);
            var EmpContactQuery = GetEmpCurrentContact(enmContactType.Official);
            var EmpDepartmentQuery = Departmentlst?.Count>0? GetCurrentDepartmentQuery(EffectiveDt).Where(q=> Departmentlst.Keys.Contains( q.DepId??0)): GetCurrentDepartmentQuery(EffectiveDt);
            var EmpLocationQuery = Locationlst?.Count>0? GetCurrentLocationQuery(EffectiveDt).Where(q=> Locationlst.Keys.Contains( q.LocationId??0)): GetCurrentLocationQuery(EffectiveDt);

            var FinalQuery = from t1 in EmpQuery
                             join t2 in EmpContactQuery on t1.Id equals t2.EmpId
                             join t3 in EmpDepartmentQuery on t1.Id equals t3.EmpId
                             join t4 in EmpLocationQuery on t1.Id equals t4.EmpId
                             join t5 in _HRMSContext.tblDepartment on t3.DepId equals t5.DeptId
                             select new mdlEmployeeBasic
                             {
                                 Id=t1.Id,
                                 Code=t1.Code,
                                 EmpName=(t1.Title==enmTitle.MR?"Mr ": t1.Title == enmTitle.MRS?"Mrs ": t1.Title == enmTitle.MASTER ? "Master " : t1.Title == enmTitle.MISS ? "Miss " : "")+
                                 t1.FirstName+" "+
                                 (!(t1.MiddleName==null || t1.MiddleName=="")? t1.MiddleName+" ":"")+
                                 t1.LastName,
                                 OfficialEmail=t2.Email,
                                 OfficialContactNo=t2.ContactNo,
                                 DepId=t3.DepId??0,
                                 DepartmentName="("+t5.Code +") - "+t5.Name,
                                 LocationId =t4.LocationId??0,
                                 SubLocationId=t4.SubLocationId??0
                             };



            if (!string.IsNullOrEmpty( dtp?.search?.value ))
            {
                FinalQuery = FinalQuery.Where(p => p.OfficialEmail.Contains(dtp.search.value) ||
                p.EmpName.Contains(dtp.search.value) ||
                p.OfficialContactNo.Contains(dtp.search.value)||
                p.Code.Contains(dtp.search.value) ||
                p.DepartmentName.Contains(dtp.search.value)
                );
            }

            if (dtp?.order?.Count > 0)
            {
                string ColumnName = (dtp?.columns?.Count ?? 0) > dtp.order[0].column ? dtp.columns[dtp.order[0].column].name : "";
                FinalQuery = LinqHelper.DataSorting<mdlEmployeeBasic>(FinalQuery, ColumnName, dtp.order[0].dir);
            }
            if (dtp?.length > 0)
            {
                FinalQuery = FinalQuery.Skip(dtp.start).Take(dtp.length);
            }
            empBasic = FinalQuery;
            return empBasic;
        }
    }
}
