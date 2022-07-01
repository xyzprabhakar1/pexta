using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CustomAttribute
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class IsFilterAllowed: Attribute
    {
        private bool isFilterAllowed;
        public IsFilterAllowed(bool isFilterAllowed)
        {
            this.isFilterAllowed = isFilterAllowed;
        }
        public bool IsAllowed { get { return isFilterAllowed; } }
    }
}
