﻿using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface ICurrentUser
    {
        int CustomerId { get; }
        ulong DistributorId { get; }
        int EmployeeId { get; }
        int OrgId { get; }
        ulong UserId { get; }
        enmUserType UserType { get; }
        int VendorId { get; }
    }
}
