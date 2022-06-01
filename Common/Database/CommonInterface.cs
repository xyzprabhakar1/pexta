using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database
{
    public interface ICreated
    {
        public DateTime CreatedDt { get; set; }
        public int CreatedBy { get; set; }
    }
    public interface IModified: ICreated
    {
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        public string ModifiedRemarks { get; set; }
    }
    public interface IRequested
    {
        public DateTime RequestedDt { get; set; }
        public int RequestedBy { get; set; }
        public string RequestedRemarks { get; set; }
    }
    public interface IApproval :IRequested
    {
        public DateTime? ApprovalDt { get; set; }
        public int? ApprovalBy { get; set; }
        public string ApprovalRemarks { get; set; }
        public enmApprovalStatus ApprovalStatus { get; set; }
    }
}
