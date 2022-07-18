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
using Common.CustomModels;

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
            IEnumerable<tblUserAllClaim> alluserClaims = _masterContext.tblUserAllClaim.Where(p => p.UserId == UserId && p.AdditionalClaim == enmAdditionalClaim.None);            
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

        public List<enmAdditionalClaim> GetUserAdditionClaim(ulong UserId)
        {
            return _masterContext.tblUserAllClaim.Where(p => p.UserId == UserId && p.AdditionalClaim != enmAdditionalClaim.None).Select(q=>q.AdditionalClaim).ToList();
        }

        public bool SetRoleDocument(mdlRoleMaster roleDocument, uint CreatedBy)
        {
            DateTime dateTime = DateTime.Now;
            _masterContext.Database.ExecuteSqlInterpolated($@"update tblRoleClaim set isdeleted=1,ModifiedBy={CreatedBy},ModifiedDt={dateTime.ToString("yyyy-MM-dd")} Where  roleid={roleDocument.roleId} and isdeleted=0;");

            StringBuilder sb = new StringBuilder("");
            sb.Append("insert into tblRoleClaim(RoleId,DocumentMaster,DocumentType,AdditionalClaim,IsDeleted,ModifiedDt,ModifiedBy,ModifiedRemarks,CreatedDt,CreatedBy) values ");
            var tempdata = roleDocument?.roleDocument?.Where(q => q.documentId > 0 || q.additionalClaim>0).
                Select(p => new { data = string.Concat("(", "'" + roleDocument.roleId + "',", p.documentId, ","+p.permissionType+","+p.additionalClaim+",0,'" + dateTime.ToString("yyyy-MM-dd") + "'," + CreatedBy + ",'','" + dateTime.ToString("yyyy-MM-dd") + "','" + CreatedBy + "'", ")") });
            sb.AppendFormat(string.Join(",", tempdata) + ";");
            _masterContext.Database.ExecuteSqlRaw(sb.ToString());
            _masterContext.SaveChanges();
            return true;
        }

        #region UserRole
        public List<uint> GetUserRole(ulong UserId)
        {
            return _masterContext.tblUserRole.Where(p => p.UserId == UserId && !p.IsDeleted ).Select(p => p.RoleId??0 ).ToList();
        }

        public bool SetUserRole(mdlUserRolesWraper userRoles, ulong CreatedBy)
        {
            DateTime dateTime = DateTime.Now;

            _masterContext.Database.ExecuteSqlInterpolated($@"update tblUserRole set isdeleted=1,ModifiedBy={CreatedBy},ModifiedDt={dateTime.ToString("yyyy-MM-dd")} Where  UserId={userRoles.userMaster.userId} and isdeleted=0;");
            StringBuilder sb = new StringBuilder("");
            sb.Append("insert into tblUserRole(UserId,RoleId,IsDeleted,ModifiedDt,ModifiedBy,ModifiedRemarks,CreatedDt,CreatedBy) values ");
            var tempdata = userRoles?.userRoles?.Select(p => p.roleMaster?.roleId??0).Where(q=>q>0).
                Select(p=>new {data=string.Concat("(","'"+ userRoles.userMaster.userId + "',",p,",0,'"+ dateTime.ToString("yyyy-MM-dd") + "',"+ CreatedBy + ",'','" + dateTime.ToString("yyyy-MM-dd") + "','"+ CreatedBy + "'", ")")});
            sb.AppendFormat(string.Join(",", tempdata)+";");
            _masterContext.Database.ExecuteSqlRaw(sb.ToString());
            _masterContext.SaveChanges();
            return true;
        }
        #endregion

        public List<mdlCommonReturnuintWithParentID> GetUserOrganisation(ulong UserId)
        {
            List<mdlCommonReturnuintWithParentID> returnData = new List<mdlCommonReturnuintWithParentID>();
            returnData.AddRange(
            _masterContext.tblUserOrganisationPermission.Where(p => p.UserId == UserId && !p.IsDeleted).
                Select(p => new mdlCommonReturnuintWithParentID { Code = p.tblOrganisation.Code, Name = p.tblOrganisation.Name, IsActive = p.tblOrganisation.IsActive, Id = p.OrgId ?? 0 }
                ));
            return returnData;
        }

        public List<mdlCommonReturnuintWithParentID> GetUserCompany(ulong UserId, uint? OrgId, List<uint> OrgIds)
        {
            List<mdlCommonReturnuintWithParentID> returnData = new List<mdlCommonReturnuintWithParentID>();
            if (OrgId == 0)
            {
                return returnData;
            }
            var queryData = (from t1 in _masterContext.tblUserOrganisationPermission
                             join t2 in _masterContext.tblCompanyMaster on t1.OrgId equals t2.OrgId
                             where !t1.IsDeleted && t1.UserId == UserId && t1.HaveAllCompanyAccess
                             select new mdlCommonReturnuintWithParentID { ParentId = t2.OrgId ?? 0, Id = t2.CompanyId, Code = t2.Code, Name = t2.Name, IsActive = t2.IsActive }
                    ).Union(
                    from t1 in _masterContext.tblCompanyMaster
                    join t2 in _masterContext.tblUserOrganisationPermission on t1.OrgId equals t2.OrgId
                    join t3 in _masterContext.tblUserCompanyPermission on t1.CompanyId equals t3.CompanyId
                    where !t2.IsDeleted && t2.UserId == UserId && !t2.HaveAllCompanyAccess &&
                    !t3.IsDeleted && t3.UserId == UserId
                    select new mdlCommonReturnuintWithParentID { ParentId = t1.OrgId ?? 0, Id = t1.CompanyId, Code = t1.Code, Name = t1.Name, IsActive = t1.IsActive }
                    );
            if (OrgId > 0)
            {
                returnData.AddRange(queryData.Where(p => p.ParentId == OrgId));
            }
            else if ((OrgIds?.Count ?? 0) > 0)
            {
                returnData.AddRange(queryData.Where(p => OrgIds.Contains(p.ParentId)));
            }
            else
            {
                returnData.AddRange(queryData);
            }

            return returnData;
        }

        public List<mdlCommonReturnuintWithParentID> GetUserZone(ulong UserId, uint? OrgId, uint? CompanyId, List<uint> CompanyIds)
        {
            List<mdlCommonReturnuintWithParentID> returnData = new List<mdlCommonReturnuintWithParentID>();
            if (CompanyId == 0)
            {
                return returnData;
            }
            var QuerableData = (from t1 in _masterContext.tblUserOrganisationPermission
                                join t2 in _masterContext.tblCompanyMaster on t1.OrgId equals t2.OrgId
                                join t3 in _masterContext.tblZoneMaster on t2.CompanyId equals t3.CompanyId
                                where !t1.IsDeleted && t1.UserId == UserId && t1.HaveAllCompanyAccess
                                select new { OrgId = t3.OrgId, ParentId = t3.CompanyId ?? 0, Id = t3.ZoneId, Code = string.Empty, Name = t3.Name, IsActive = t3.IsActive }
                    ).Union(
                         from t1 in _masterContext.tblUserOrganisationPermission
                         join t2 in _masterContext.tblCompanyMaster on t1.OrgId equals t2.OrgId
                         join t3 in _masterContext.tblZoneMaster on t2.CompanyId equals t3.CompanyId
                         join t4 in _masterContext.tblUserCompanyPermission on t2.CompanyId equals t4.CompanyId
                         where !t1.IsDeleted && t1.UserId == UserId && !t1.HaveAllCompanyAccess
                         && t4.UserId == UserId && !t4.IsDeleted && t4.HaveAllZoneAccess
                         select new { OrgId = t3.OrgId, ParentId = t3.CompanyId ?? 0, Id = t3.ZoneId, Code = string.Empty, Name = t3.Name, IsActive = t3.IsActive }
                     )
                    .Union(
                    from t1 in _masterContext.tblUserOrganisationPermission
                    join t2 in _masterContext.tblCompanyMaster on t1.OrgId equals t2.OrgId
                    join t3 in _masterContext.tblZoneMaster on t2.CompanyId equals t3.CompanyId
                    join t4 in _masterContext.tblUserCompanyPermission on t2.CompanyId equals t4.CompanyId
                    join t5 in _masterContext.tblUserZonePermission on t3.ZoneId equals t5.ZoneId
                    where !t1.IsDeleted && t1.UserId == UserId && !t1.HaveAllCompanyAccess
                    && t4.UserId == UserId && !t4.IsDeleted && !t4.HaveAllZoneAccess
                    && t5.UserId == UserId && !t5.IsDeleted
                    select new { OrgId = t3.OrgId, ParentId = t3.CompanyId ?? 0, Id = t3.ZoneId, Code = string.Empty, Name = t3.Name, IsActive = t3.IsActive }
                    );
            if (CompanyId > 0)
            {
                returnData.AddRange(QuerableData.Where(p => p.ParentId == CompanyId).Select(p => new mdlCommonReturnuintWithParentID { ParentId = p.ParentId, Id = p.Id, Code = p.Code, Name = p.Name, IsActive = p.IsActive }));
            }
            else if (OrgId > 0)
            {
                returnData.AddRange(QuerableData.Where(p => p.OrgId == OrgId).Select(p => new mdlCommonReturnuintWithParentID { ParentId = p.ParentId, Id = p.Id, Code = p.Code, Name = p.Name, IsActive = p.IsActive }));
            }
            else if ((CompanyIds?.Count ?? 0) > 0)
            {
                returnData.AddRange(QuerableData.Where(p => CompanyIds.Contains(p.ParentId)).Select(p => new mdlCommonReturnuintWithParentID { ParentId = p.ParentId, Id = p.Id, Code = p.Code, Name = p.Name, IsActive = p.IsActive }));
            }
            else
            {
                returnData.AddRange(QuerableData.Select(p => new mdlCommonReturnuintWithParentID { ParentId = p.ParentId, Id = p.Id, Code = p.Code, Name = p.Name, IsActive = p.IsActive }));
            }

            return returnData;
        }


        public List<mdlCommonReturnuintWithParentID> GetUserLocation(bool ClearCache, ulong UserId, uint? OrgId, uint? CompanyId, uint? ZoneId)
        {
            List<mdlCommonReturnuintWithParentID> returnData = new List<mdlCommonReturnuintWithParentID>();
            if (ClearCache)
            {
                SetTempOrganisation(UserId);
            }
            if (ZoneId != null)
            {
                returnData.AddRange(
                _masterContext.tblUserAllLocationPermission.Where(p => p.UserId == UserId && p.tblLocationMaster.ZoneId == ZoneId).
                    Select(p => new mdlCommonReturnuintWithParentID { Name = p.tblLocationMaster.Name, Code = string.Empty, Id = p.LocationId ?? 0, IsActive = p.tblLocationMaster.IsActive, ParentId = p.tblLocationMaster.ZoneId ?? 0 }));
            }
            else if (CompanyId != null)
            {
                returnData.AddRange(
                from t1 in _masterContext.tblUserAllLocationPermission
                join t2 in _masterContext.tblLocationMaster on t1.LocationId equals t2.LocationId
                join t3 in _masterContext.tblZoneMaster on t2.ZoneId equals t3.ZoneId
                where t3.CompanyId == CompanyId && t1.UserId == UserId
                select new mdlCommonReturnuintWithParentID { Name = t2.Name, Code = string.Empty, Id = t2.LocationId, IsActive = t2.IsActive, ParentId = t3.ZoneId });
            }
            else if (OrgId != null)
            {
                returnData.AddRange(
                from t1 in _masterContext.tblUserAllLocationPermission
                join t2 in _masterContext.tblLocationMaster on t1.LocationId equals t2.LocationId
                where t2.OrgId == OrgId && t1.UserId == UserId
                select new mdlCommonReturnuintWithParentID { Name = t2.Name, Code = string.Empty, Id = t2.LocationId, IsActive = t2.IsActive, ParentId = t2.ZoneId ?? 0 });
            }
            else
            {
                returnData.AddRange(
                from t1 in _masterContext.tblUserAllLocationPermission
                join t2 in _masterContext.tblLocationMaster on t1.LocationId equals t2.LocationId
                where t1.UserId == UserId
                select new mdlCommonReturnuintWithParentID { Name = t2.Name, Code = string.Empty, Id = t2.LocationId, IsActive = t2.IsActive, ParentId = t2.ZoneId ?? 0 });
            }
            return returnData;
        }

    



    }
}