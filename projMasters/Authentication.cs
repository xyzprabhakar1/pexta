using projMasters.Database;
using projMasters.Models;

namespace projMasters
{
    public class Auth
    {
        private readonly MasterContext _masterContext;
        public Auth(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }
        public mdlLoginResponse Login(mdlLoginRequest req)
        {
            mdlLoginResponse res = new mdlLoginResponse() { normalizedName = String.Empty, error = new Common.CustomModels.Error() };
            var tempData=_masterContext.tblUsersMaster.Where(p => p.UserName == req.userName && p.OrgId== req.orgId ).FirstOrDefault();
            if (tempData==null)
            {
                res.error.ErrorId = Common.Enums.enmError.InvalidUserorPassword;
                res.error.Message=

            }
        }
        
    }
}