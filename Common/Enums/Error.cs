using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum enmError
    {
        [Description("")]
        None =0,
        [Description("Invalid username or password !!")]
        InvalidUserorPassword = 1,
        [Description("Access Denied!!!")]
        AccessDenied,
        [Description("Pending for Approval!!!")]
        PendingApproval,
        [Description("Save Successfully!!!")]
        SaveSucessfully,
        [Description("Update Successfully!!!")]
        UpdateSucessfully,
        [Description("Approved Successfully!!!")]
        ApprovedSucessfully,
        [Description("Rejected Successfully!!!")]
        RejectSucessfully,
        [Description("Enter all Required inputs!!!")]
        RequiredField,
        [Description("Invalid Id !!!")]
        InvalidID,
        [Description("Invalid Organization !!!")]
        InvalidOrganization,
        [Description("Invalid User !!!")]
        InvalidUser,
        [Description("Invalid Applicable date !!!")]
        InvalidApplicableDt,
        [Description("Invalid Data !!!")]
        InvalidData,        
        [Description("Invalid Operation !!!")]
        InvalidOperation,
        [Description("User Blocked !!!")]
        UserLocked,
        [Description("Data already exists !!!")]
        AlreadyExists,
        [Description("Request already in Processing !!!")]
        RequestAlreadyInProcessing,
        [Description("Request already Processed !!!")]
        RequestAlreadyProcessed,
        [Description("Data not exists !!!")]
        DataNotExists,
        [Description("Data not Found !!!")]
        DataNotFound,
        [Description("Concurrency Error !!!")]
        ConcurrencyError,
        [Description("Database Error !!!")]
        DatabaseError,
        [Description("Undefined Exception!!!")]
        UndefinedException,
        [Description("Only one head office can be created!!!")]
        SingleHeadOfficeException,
        [Description("Invalid Old Password !!!")]
        InvalidOldPassword,
        [Description("Invalid Service Provider !!!")]
        InvalidServiceProvider,
        [Description("Provider Not Implemeneted !!!")]
        ProviderNotImplemented,
        [Description("Insufficient Balance !!!")]
        InsufficientBalance,
        
    }
}
