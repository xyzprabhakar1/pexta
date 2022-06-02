using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum enmApprovalStatus:byte
    {
        Pending=0,
        Approve=1,
        Reject=2,
        InProcess=4,        
    }

    public enum enmEntityType : byte
    {
        Create=1,
        Update=2,
        Delete=3,
    }
}
