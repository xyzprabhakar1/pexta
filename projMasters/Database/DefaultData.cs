using Common.Database;
using Common.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projMasters.Database
{
    public class DefaultData
    {
        private static DateTime CurrentDate = new DateTime(2021, 1, 1);

        public static void InsertCountryMaster(ModelBuilder modelBuilder)
        {
            tblCountry countryData = new tblCountry()
            {
                CountryId = 1,
                ContactPrefix = "",
                Code= "IN",
                Name = "India",
                IsActive = true,
                ModifiedBy = 1,
                ModifiedDt = CurrentDate,
                ModifiedRemarks = string.Empty,
                
            };
            modelBuilder.Entity<tblCountry>().HasData(countryData);
            //insert into the state
            List<tblState> all_states = new List<tblState>();
            all_states.Add(new tblState() { CountryId = 1, StateId = 35, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Andaman and Nicobar Islands",Code="AN" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 37, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Andhra Pradesh", Code = "AD" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 12, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Arunachal Pradesh",Code = "AR" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 18, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Assam", Code = "AS" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 10, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Bihar", Code = "BR" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 4, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Chandigarh", Code = "CH" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 22, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Chhattisgarh", Code = "CG" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 26, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Dadra and Nagar Haveli", Code = "DNHDD" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 97, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Daman and Diu", Code = "OT" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 7, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Delhi", Code = "DL" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 30, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Goa", Code = "GA" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 24, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Gujarat", Code = "GJ" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 6, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Haryana", Code = "HR" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 2, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Himachal Pradesh", Code = "HP" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 1, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Jammu and Kashmir", Code = "JK" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 20, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Jharkhand", Code = "JH" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 29, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Karnataka", Code = "KA" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 32, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Kerala", Code = "KL" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 38, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Ladakh", Code = "LA" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 31, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Lakshadweep", Code = "LD" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 23, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Madhya Pradesh", Code = "MP" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 27, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Maharashtra", Code = "MH" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 14, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Manipur", Code = "MN" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 17, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Meghalaya", Code = "ML" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 15, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Mizoram", Code = "MZ" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 13, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Nagaland", Code = "NL" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 21, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Odisha", Code = "OD" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 34, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Puducherry", Code = "PY" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 3, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Punjab", Code = "PB" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 8, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Rajasthan", Code = "RJ" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 11, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Sikkim", Code = "SK" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 33, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Tamil Nadu", Code = "TN" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 36, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Telangana", Code = "TS" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 16, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Tripura", Code = "TR" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 9, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Uttar Pradesh", Code = "UP" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 5, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "Uttarakhand", Code = "UK" });
            all_states.Add(new tblState() { CountryId = 1, StateId = 19, ModifiedBy = 1, ModifiedDt = CurrentDate, IsActive = true,  Name = "West Bengal", Code = "WB" });
            modelBuilder.Entity<tblState>().HasData(all_states);
            
        }

        public static void InsertOrganisation(ModelBuilder modelBuilder)
        {
            tblOrganisation org = new tblOrganisation()
            {
                Code = "GL",
                Name = "Glaze",
                StateId = 7,
                CountryId = 1,
                City = "",
                Email = "prabhakar.singh@sakshemit.com",
                AlternateEmail = "punit.singh@sakshemit.com",
                IsActive = true,
                AlternateContactNo = "",
                ContactNo = "9873404402",
                OfficeAddress = "Janakpuri",
                Locality = "",
                ModifiedRemarks = "",
                Pincode = "110053",
                ModifiedBy = 1,
                ModifiedDt = CurrentDate,
                OrgId = 1,
                Logo = "",
            };
            tblCompanyMaster com = new tblCompanyMaster() { 
                CompanyId=1,
                OrgId=1,
                Code="GC",
                Name="Glaze Trading India Pvt Ltd",
                Logo="",
                IsActive=true,
                ModifiedBy = 1,
                ModifiedDt = CurrentDate,
                ModifiedRemarks=String.Empty
            };
            tblZoneMaster zn = new tblZoneMaster()
            {
                CompanyId = 1,
                OrgId = 1,
                ZoneId=1,                
                Name = "Delhi",
                IsActive = true,
                ModifiedBy = 1,
                ModifiedDt = CurrentDate,
                ModifiedRemarks = String.Empty
            };
            tblLocationMaster lc = new tblLocationMaster()
            {
                LocationId = 1,
                CompanyId = 1,
                OrgId = 1,
                ZoneId = 1,
                Name = "Head Office",
                LocationType = Common.Enums.enmLocationType.HeadOffice,
                StateId = 7,
                CountryId = 1,
                Pincode = "110053",
                ContactNo = "987340442",
                AlternateContactNo = "",
                AlternateEmail = "",
                Email = "prabhakarks90@gmail.com",
                City = "",
                Locality="",
                IsActive = true,
                ModifiedBy = 1,
                ModifiedDt = CurrentDate,
                ModifiedRemarks = String.Empty
            };

            modelBuilder.Entity<tblOrganisation>().HasData(org);
            modelBuilder.Entity<tblCompanyMaster>().HasData(com);
            modelBuilder.Entity<tblZoneMaster>().HasData(zn);
            modelBuilder.Entity<tblLocationMaster>().HasData(lc);
        }

        public static void InsertRoleMaster(ModelBuilder modelBuilder)
        {
            tblRoleMaster roleMaster = new tblRoleMaster()
            {
                IsActive = true,
                ModifiedBy=1,
                ModifiedDt=CurrentDate,
                RoleId=1,
                RoleName="Admin"
            };

            List<tblRoleClaim> allRoleClaim = new List<tblRoleClaim>();
            var rdata =Enum.GetValues(typeof (enmDocumentMaster));
            var rtype = Enum.GetValues(typeof(enmDocumentType));
            uint index = 0;
            foreach (var r in rdata)
            {

                if (((enmDocumentMaster)r) == enmDocumentMaster.None)
                {
                    continue;
                }
                var d=((enmDocumentMaster)r).GetDocumentDetails();
                foreach (var t in rtype)
                {
                    if (d.DocumentType.HasFlag((enmDocumentType)t))
                    {
                        if (((enmDocumentType)t) == enmDocumentType.None)
                        {
                            continue ;
                        }
                        ++index;
                        allRoleClaim.Add(
                        new tblRoleClaim()
                        {
                            RoleId=1,
                            DocumentType= (enmDocumentType)t,
                            DocumentMaster= (enmDocumentMaster)r,
                            AdditionalClaim= enmAdditionalClaim.None,
                            CreatedBy=1,
                            CreatedDt= CurrentDate,
                            IsDeleted = false,
                            ModifiedBy = 1,
                            ModifiedDt = CurrentDate,
                            ModifiedRemarks = String.Empty,
                            RoleClaimId = index
                        });
                    }                    
                }                
            }

            var adata = Enum.GetValues(typeof(enmAdditionalClaim));
            foreach (var r in adata)
            {
                if (((enmAdditionalClaim)r) == enmAdditionalClaim.None)
                { 
                    continue;
                }
                ++index;
                allRoleClaim.Add(
                new tblRoleClaim()
                {
                    RoleId = 1,
                    DocumentType = enmDocumentType.None,
                    DocumentMaster = enmDocumentMaster.None,
                    AdditionalClaim = ((enmAdditionalClaim)r),
                    CreatedBy = 1,
                    CreatedDt = CurrentDate,
                    IsDeleted= false,
                    ModifiedBy=1,
                    ModifiedDt= CurrentDate,
                    ModifiedRemarks =String.Empty,
                    RoleClaimId=index
                });
            }

            modelBuilder.Entity<tblRoleMaster>().HasData(roleMaster);
            modelBuilder.Entity<tblRoleClaim>().HasData(allRoleClaim);
        }

        public static void InsertDefaultUser(ModelBuilder modelBuilder)
        {
            tblUsersMaster user = new tblUsersMaster()
            {
                UserId = 1,
                NormalizedName = "Prabhakar",
                UserName="Admin",
                Email="prabhakarks90@gmail.com",
                EmailConfirmed=true,
                PhoneNumber="9873404402",
                PhoneNumberConfirmed=true,
                Password="123456",
                UserType=enmUserType.Employee,
                IsActive= true,
                LoginFailCount=0,
                LoginFailCountdt=CurrentDate,
                is_logged_blocked=0,
                logged_blocked_dt=CurrentDate,
                logged_blocked_Enddt=CurrentDate,
                OrgId=1,
                RequiredChangePassword=false,
                ModifiedDt=CurrentDate,
                ModifiedBy=1,
                ModifiedRemarks=String.Empty,
            };
            modelBuilder.Entity<tblUsersMaster>().HasData(user);

            tblUserRole userrole = new tblUserRole()
            {
                UserId=1,
                RoleId  =1,
                CreatedBy=1,
                CreatedDt=CurrentDate,
                IsDeleted=false,
                ModifiedBy=1,
                ModifiedDt=CurrentDate,
                ModifiedRemarks=String.Empty,
                UserRoleId=1
            };
            modelBuilder.Entity<tblUserRole>().HasData(userrole);


            tblUserOrganisationPermission org = new tblUserOrganisationPermission()
            {
                HaveAllCompanyAccess=true,
                IsDeleted=false,
                OrgId=1,
                UserId=1,
                Sno=1,
                ModifiedBy = 1,
                ModifiedDt = CurrentDate,
                ModifiedRemarks = String.Empty,
            };
            modelBuilder.Entity<tblUserOrganisationPermission>().HasData(org);

        }

    }
}
