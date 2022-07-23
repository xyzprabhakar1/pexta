using Common;
using Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projMasters
{
    

    public class CurrentUser : ICurrentUser
    {

        private uint _UserId = 0, _DistributorId = 0, _OrgId = 0;
        private int _EmployeeId = 0, _CustomerId = 0, _VendorId = 0 ;
        //private int[] _OrgIds;
        private enmUserType _UserType = enmUserType.Customer;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            uint.TryParse(httpContextAccessor.HttpContext.User.Claims.Where(p => p.Type == "__UserId").FirstOrDefault()?.Value, out _UserId);
            int.TryParse(httpContextAccessor.HttpContext.User.Claims.Where(p => p.Type == "__CustomerId").FirstOrDefault()?.Value, out _CustomerId);
            int.TryParse(httpContextAccessor.HttpContext.User.Claims.Where(p => p.Type == "__EmployeeId").FirstOrDefault()?.Value, out _EmployeeId);
            int.TryParse(httpContextAccessor.HttpContext.User.Claims.Where(p => p.Type == "__VendorId").FirstOrDefault()?.Value, out _VendorId);
            uint.TryParse(httpContextAccessor.HttpContext.User.Claims.Where(p => p.Type == "__DistributorId").FirstOrDefault()?.Value, out _DistributorId);
            uint.TryParse(httpContextAccessor.HttpContext.User.Claims.Where(p => p.Type == "__OrgId").FirstOrDefault()?.Value, out _OrgId);
            Enum.TryParse(httpContextAccessor.HttpContext.User.Claims.Where(p => p.Type == "__UserType").FirstOrDefault()?.Value, out _UserType);
            //string tempOrg = httpContextAccessor.HttpContext.User.Claims.Where(p => p.Type == "__OrgIds").FirstOrDefault()?.Value ?? string.Empty;
            //try
            //{
            //    _OrgIds = tempOrg.Split(",")?.Select(p => Convert.ToInt32(p))?.ToArray() ?? null;
            //    if (_OrgIds == null)
            //    {
            //        _OrgIds = new int[1];
            //        _OrgIds[0] = _OrgId;
            //    }
            //}
            //catch { }
        }
        public uint UserId { get { return _UserId; } private set { } }
        public uint OrgId { get { return _OrgId; } private set { } }
        //public int[] OrgIds { get { return _OrgIds; } private set { } }
        public int CustomerId { get { return _CustomerId; } private set { } }
        public int EmployeeId { get { return _EmployeeId; } private set { } }
        public int VendorId { get { return _VendorId; } private set { } }
        public uint DistributorId { get { return _DistributorId; } private set { } }
        public enmUserType UserType { get { return _UserType; } private set { } }
        //public bool HaveOrganisationPermission(int OrgId)
        //{
        //    return _OrgIds.Any(p => p == OrgId);
        //}
    }
}
