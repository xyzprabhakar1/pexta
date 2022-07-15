using Common;
using Common.Enums;
using Microsoft.IdentityModel.Tokens;
using projMasters.Database;
using projMasters.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Common.Database;

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

        public void SaveLoginLog(ulong UserId, string IPAddress, string DeviceDetails, bool LoginStatus, string FromLocation, string Longitude, string Latitude)
        {   
            _masterContext.tblUserLoginLog.Add(new Common.Database.tblUserLoginLog()
            {
                UserId = UserId,
                IPAddress = IPAddress,
                DeviceDetails = DeviceDetails,
                LoginStatus = LoginStatus,
                FromLocation = FromLocation,
                LoginDateTime = DateTime.Now,
                Longitude = Longitude,
                Latitude = Latitude
            });
            _masterContext.SaveChanges();
        }

        public string GenerateJSONWebToken(string JWTKey, string JWTIssuer,
           ulong UserId, int CustomerId,int EmployeeId, int VendorId, ulong DistributorId
           , enmUserType userType, int OrgId
           )
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            List<Claim> _claim = new List<Claim>();
            _claim.Add(new Claim("__UserId", Convert.ToString(UserId)));
            _claim.Add(new Claim("__CustomerId", Convert.ToString(CustomerId)));
            _claim.Add(new Claim("__EmployeeId", Convert.ToString(EmployeeId)));
            _claim.Add(new Claim("__VendorId", Convert.ToString(VendorId)));
            _claim.Add(new Claim("__DistributorId", Convert.ToString(DistributorId)));
            _claim.Add(new Claim("__UserType", Convert.ToString(userType)));
            _claim.Add(new Claim("__OrgId", Convert.ToString(OrgId)));
            int TokenExpiryTime = 10080;
            int.TryParse(_setting.GetSettings("UserSetting", "TokenExpiryTime"), out TokenExpiryTime);
            var token = new JwtSecurityToken(JWTIssuer, JWTIssuer, _claim, expires: DateTime.Now.AddMinutes(TokenExpiryTime),
              signingCredentials: credentials);
            string Token = new JwtSecurityTokenHandler().WriteToken(token);
            return Token;
        }

        public void SetTempRoleClaim(ulong UserId)
        {
            FormattableString formattableString = $@"delete from tblUserAllClaim Where UserId={UserId};
                insert into tblUserAllClaim(UserId,DocumentMaster,DocumentType)
            select Distinct {UserId},DocumentMaster,DocumentType from 
             (select t2.DocumentMaster,t2.DocumentType,t2.AdditionalClaim from tblUserRole t1 inner join tblRoleClaim  t2 on t1.RoleId=t2.RoleId Where t1.UserId={0} and t1.IsDeleted=0 and t2.IsDeleted=0 
             union 
             select DocumentMaster,DocumentType,AdditionalClaim from tblUserClaim where UserId={UserId} and IsDeleted=0) t1;";
            _masterContext.Database.ExecuteSqlInterpolated(formattableString);
        }

        public void SetTempOrganisation(ulong UserId)
        {

            _masterContext.Database.ExecuteSqlInterpolated($@"delete from tblUserAllLocationPermission  Where UserId={UserId};
             insert into tblUserAllLocationPermission(UserId,LocationId)
             select Distinct {UserId},LocationId  from 
             (select t2.LocationId from tblUserOrganisationPermission t1 inner join tblLocationMaster t2 on t1.OrgId=t2.OrgId and t1.HaveAllCompanyAccess=1 
             Where t1.UserId={UserId} and t1.IsDeleted=0 
             union
             select t3.LocationId from tblUserOrganisationPermission t1 inner join tblZoneMaster t2 on t1.OrgId=t2.OrgId and t1.UserId={UserId} and t1.IsDeleted=0 and t1.HaveAllCompanyAccess=0 
             inner join tblLocationMaster t3 on t2.ZoneId=t3.ZoneId
             inner join tblUserCompanyPermission t4 on t4.CompanyId=t2.CompanyId and t4.UserId={UserId} and t4.IsDeleted=0  and t4.HaveAllZoneAccess=1
             union
             select t3.LocationId from tblUserOrganisationPermission t1 inner join tblZoneMaster t2 on t1.OrgId=t2.OrgId and t1.UserId={UserId} and t1.IsDeleted=0 and t1.HaveAllCompanyAccess=0 
             inner join tblLocationMaster t3 on t2.ZoneId=t3.ZoneId
             inner join tblUserCompanyPermission t4 on t4.CompanyId=t2.CompanyId and t4.UserId={UserId} and t4.IsDeleted=0  and t4.HaveAllZoneAccess=0
             inner join tblUserZonePermission t5 on t5.ZoneId=t2.ZoneId and t5.UserId={UserId} and t5.IsDeleted=0  and t5.HaveAllLocationAccess=1
             union
             select LocationId from tblUserLocationPermission Where UserId={UserId} and IsDeleted=0 )t;" );

        }
        public List<Document> GetUserDocuments(ulong UserId, bool OnlyDisplayMenu)
        {
            IEnumerable<tblUserAllClaim> alluserClaims = _masterContext.tblUserAllClaim.Where(p => p.UserId == UserId);            
            var tempData = alluserClaims.Select(p => p.DocumentMaster).Distinct();
            List<Document> documents = new List<Document>();
            foreach (var d in tempData)
            {
                enmDocumentType permissionType = enmDocumentType.None;
                Document doc = d.GetDocumentDetails();
                if (doc.HaveCreate && alluserClaims.Any(p => p.DocumentType == enmDocumentType.Create))
                {
                    permissionType = permissionType | enmDocumentType.Create;
                }
                if (doc.HaveUpdate && alluserClaims.Any(p => p.DocumentType == enmDocumentType.Update))
                {
                    permissionType = permissionType | enmDocumentType.Update;
                }
                if (doc.HaveApproval && alluserClaims.Any(p => p.DocumentType == enmDocumentType.Approval))
                {
                    permissionType = permissionType | enmDocumentType.Approval;
                }
                if (doc.HaveDelete && alluserClaims.Any(p => p.DocumentType == enmDocumentType.Delete))
                {
                    permissionType = permissionType | enmDocumentType.Delete;
                }
                if (doc.HaveReport && alluserClaims.Any(p => p.DocumentType == enmDocumentType.Report))
                {
                    permissionType = permissionType | enmDocumentType.Report;
                }
                if (doc.HaveDisplayMenu && alluserClaims.Any(p => p.DocumentType == enmDocumentType.DisplayMenu))
                {
                    permissionType = permissionType | enmDocumentType.DisplayMenu;
                }
                if (doc.HavePendingReport  && alluserClaims.Any(p => p.DocumentType == enmDocumentType.PendingReport))
                {
                    permissionType = permissionType | enmDocumentType.PendingReport;
                }
                if (doc.HaveDetailView && alluserClaims.Any(p => p.DocumentType == enmDocumentType.DetailView))
                {
                    permissionType = permissionType | enmDocumentType.DetailView;
                }
                doc.DocumentType = permissionType;
                documents.Add(doc);
            }
            if (OnlyDisplayMenu)
            {
                documents.RemoveAll(q => !q.HaveDisplayMenu);
            }
            return documents;
        }


        #region UserRole
        public List<uint> GetUserRole(ulong UserId)
        {
            return _masterContext.tblUserRole.Where(p => p.UserId == UserId && !p.IsDeleted ).Select(p => p.RoleId??0 ).ToList();
        }
        public bool SetUserRole(mdlUserRolesWraper userRoles, ulong CreatedBy)
        {
            DateTime dateTime = DateTime.Now;

            _masterContext.Database.ExecuteSqlInterpolated($@"update tblUserRole set isdeleted=1,ModifiedBy='{CreatedBy}',ModifiedDt='{dateTime.ToString("yyyy-MM-dd")}' Where  UserId={userRoles.userMaster.userId} and isdeleted=0;");

            List<tblUserRole> TobeAdded = new List<tblUserRole>();
            List<tblUserRole> TobeUpdate = new List<tblUserRole>();
            //Get Existsing Role
            var tempData = _masterContext.tblUserRole.Where(p => p.UserId == userRoles.userMaster.userId && !p.IsDeleted);
            userRoles.userRoles.ForEach(q =>
            {
                var innerTemp = tempData.FirstOrDefault(p => p.RoleId == q.roleMaster.roleId);
                if (innerTemp == null)
                {
                    TobeAdded.Add(new tblUserRole()
                    {
                        RoleId =  q.roleMaster.roleId,
                        IsDeleted=false,
                        ModifiedBy = Convert.ToUInt32( CreatedBy),
                        ModifiedDt = dateTime,
                        UserId= userRoles.userMaster.userId,
                        ModifiedRemarks=String.Empty,
                    });
                }
                else
                {
                    if (q.isActive != innerTemp.IsActive)
                    {
                        innerTemp.IsActive = q.isActive;
                        innerTemp.last_modified_by = CreatedBy;
                        innerTemp.last_modified_date = dateTime;
                        TobeUpdate.Add(innerTemp);
                    }
                }


            });
            _masterContext.tblUserRole.AddRange(TobeAdded);
            _masterContext.tblUserRole.UpdateRange(TobeAdded);
            _masterContext.SaveChanges();
            return true;
        }
        #endregion

    }
}