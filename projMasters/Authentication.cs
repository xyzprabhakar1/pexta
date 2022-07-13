using Common;
using Common.Enums;
using projMasters.Database;
using projMasters.Models;

namespace projMasters
{
    public class Auth
    {
        private readonly MasterContext _masterContext;
        private readonly ISettings _setting;
        public Auth(MasterContext masterContext,ISettings setting)
        {
            _masterContext = masterContext;
            _setting = setting;
        }
        public mdlLoginResponse Login(mdlLoginRequest req)
        {
            mdlLoginResponse res = new mdlLoginResponse() { messageType=enmMessageType.Error,normalizedName = String.Empty, error = new Common.CustomModels.Error() };
            var tempData=_masterContext.tblUsersMaster.Where(p => p.UserName == req.userName && p.OrgId== req.orgId ).FirstOrDefault();
            if (tempData==null)
            {
                res.error.ErrorId = Common.Enums.enmError.InvalidUserorPassword;                
                return res;
            }
            if (!tempData.IsActive)
            {
                res.error.ErrorId = Common.Enums.enmError.InvalidUser;
                return res;
            }
            if (tempData.is_logged_blocked == 1)
            {
                if (tempData.logged_blocked_Enddt < DateTime.Now)
                {
                    BlockUnblockUser(tempData.UserId, 0);
                }
                else
                {
                    res.error.ErrorId = Common.Enums.enmError.UserLocked;
                    return res;
                }
            }
            if (tempData.Password != req.password)
            {
                BlockUnblockUser(tempData.UserId, 1);
                res.error.ErrorId = Common.Enums.enmError.InvalidUserorPassword;
                return res;
            }
            res.messageType = enmMessageType.Success;

            return res;

        }


        public void BlockUnblockUser(ulong UserId, byte is_logged_blocked)
        {
            bool AllowBlockonFail = false;
            DateTime CurrentDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));
            int BlockUserAfterLoginFailAttempets = 10, BlockUserAfterLoginFailAttempetsForTime = 30;
            var tempData = _masterContext.tblUsersMaster.Where(p => p.UserId == UserId).FirstOrDefault();
            if (tempData == null)
            {
                return;
            }
            if (is_logged_blocked == 1)
            {
                bool.TryParse(_setting.GetSettings("UserSetting", "AllowBlockonFail"), out AllowBlockonFail);
                if (AllowBlockonFail)
                {
                    int.TryParse(_setting.GetSettings("UserSetting", "BlockUserAfterLoginFailAttempets"), out BlockUserAfterLoginFailAttempets);
                    int.TryParse(_setting.GetSettings("UserSetting", "BlockUserAfterLoginFailAttempetsForTime"), out BlockUserAfterLoginFailAttempetsForTime);
                    if (tempData.LoginFailCount >= BlockUserAfterLoginFailAttempets && DateTime.Compare(tempData.LoginFailCountdt, CurrentDate) == 0)
                    {
                        tempData.is_logged_blocked = is_logged_blocked;
                        tempData.logged_blocked_dt = DateTime.Now;
                        tempData.logged_blocked_Enddt = DateTime.Now.AddMinutes(BlockUserAfterLoginFailAttempetsForTime);

                    }
                    else
                    {
                        if (DateTime.Compare(tempData.LoginFailCountdt, CurrentDate) != 0)
                        {
                            tempData.LoginFailCount = 1;
                            tempData.LoginFailCountdt = CurrentDate;
                        }
                        else
                        {
                            tempData.LoginFailCount = ++tempData.LoginFailCount;
                        }
                    }
                }
            }
            else
            {
                tempData.is_logged_blocked = 0;
            }
            _masterContext.tblUsersMaster.Update(tempData);
            _masterContext.SaveChanges();

        }

    }
}