using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projMasters.Migrations
{
    public partial class DefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblCountry",
                columns: new[] { "CountryId", "Code", "ContactPrefix", "IsActive", "ModifiedBy", "ModifiedDt", "ModifiedRemarks", "Name" },
                values: new object[] { 1L, "IN", "", true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "India" });

            migrationBuilder.InsertData(
                table: "tblOrganisation",
                columns: new[] { "OrgId", "AlternateContactNo", "AlternateEmail", "City", "Code", "ContactNo", "CountryId", "Email", "IsActive", "Locality", "Logo", "ModifiedBy", "ModifiedDt", "ModifiedRemarks", "Name", "OfficeAddress", "Pincode", "StateId" },
                values: new object[] { 1L, "", "punit.singh@sakshemit.com", "", "GL", "9873404402", 1L, "prabhakar.singh@sakshemit.com", true, "", "", 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Glaze", "Janakpuri", "110053", 7L });

            migrationBuilder.InsertData(
                table: "tblRoleMaster",
                columns: new[] { "RoleId", "IsActive", "ModifiedBy", "ModifiedDt", "ModifiedRemarks", "RoleName" },
                values: new object[] { 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Admin" });

            migrationBuilder.InsertData(
                table: "tblCompanyMaster",
                columns: new[] { "CompanyId", "Code", "IsActive", "Logo", "ModifiedBy", "ModifiedDt", "ModifiedRemarks", "Name", "OrgId" },
                values: new object[] { 1L, "GC", true, "", 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Glaze Trading India Pvt Ltd", 1L });

            migrationBuilder.InsertData(
                table: "tblRoleClaim",
                columns: new[] { "RoleClaimId", "AdditionalClaim", "CreatedBy", "CreatedDt", "DocumentMaster", "DocumentType", "IsDeleted", "ModifiedBy", "ModifiedDt", "ModifiedRemarks", "RoleId" },
                values: new object[,]
                {
                    { 1L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 2L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 3L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 16, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 4L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 32, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 5L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 64, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 6L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 128, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 7L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 8L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 9L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 10L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 16, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 11L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 32, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 12L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 64, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 13L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 128, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 14L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 15L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 16L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 17L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 16, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 18L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 32, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 19L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 64, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 20L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 128, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 21L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 22L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 23L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 24L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 16, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 25L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 32, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 26L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 64, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 27L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 128, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 28L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 29L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 30L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 16, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 31L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 128, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 32L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 33L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 2, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 34L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 16, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 35L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 128, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 36L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1101, 2, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 37L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1101, 16, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 38L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1101, 128, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 39L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1103, 2, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 40L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1103, 16, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 41L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1103, 128, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L }
                });

            migrationBuilder.InsertData(
                table: "tblRoleClaim",
                columns: new[] { "RoleClaimId", "AdditionalClaim", "CreatedBy", "CreatedDt", "DocumentMaster", "DocumentType", "IsDeleted", "ModifiedBy", "ModifiedDt", "ModifiedRemarks", "RoleId" },
                values: new object[,]
                {
                    { 42L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1105, 2, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 43L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1105, 16, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 44L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1105, 128, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 45L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1107, 2, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 46L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1107, 16, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 47L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1107, 128, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 48L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1109, 2, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 49L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1109, 16, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 50L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1109, 128, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 51L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1111, 2, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 52L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1111, 16, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L },
                    { 53L, 0, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1111, 128, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L }
                });

            migrationBuilder.InsertData(
                table: "tblState",
                columns: new[] { "StateId", "Code", "CountryId", "IsActive", "ModifiedBy", "ModifiedDt", "ModifiedRemarks", "Name" },
                values: new object[,]
                {
                    { 1L, "JK", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Jammu and Kashmir" },
                    { 2L, "HP", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Himachal Pradesh" },
                    { 3L, "PB", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Punjab" },
                    { 4L, "CH", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Chandigarh" },
                    { 5L, "UK", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Uttarakhand" },
                    { 6L, "HR", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Haryana" },
                    { 7L, "DL", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Delhi" },
                    { 8L, "RJ", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Rajasthan" },
                    { 9L, "UP", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Uttar Pradesh" },
                    { 10L, "BR", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Bihar" },
                    { 11L, "SK", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Sikkim" },
                    { 12L, "AR", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Arunachal Pradesh" },
                    { 13L, "NL", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Nagaland" },
                    { 14L, "MN", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Manipur" },
                    { 15L, "MZ", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Mizoram" },
                    { 16L, "TR", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Tripura" },
                    { 17L, "ML", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Meghalaya" },
                    { 18L, "AS", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Assam" },
                    { 19L, "WB", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "West Bengal" },
                    { 20L, "JH", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Jharkhand" },
                    { 21L, "OD", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Odisha" },
                    { 22L, "CG", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Chhattisgarh" },
                    { 23L, "MP", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Madhya Pradesh" },
                    { 24L, "GJ", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Gujarat" },
                    { 26L, "DNHDD", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Dadra and Nagar Haveli" },
                    { 27L, "MH", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Maharashtra" },
                    { 29L, "KA", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Karnataka" },
                    { 30L, "GA", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Goa" },
                    { 31L, "LD", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Lakshadweep" },
                    { 32L, "KL", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Kerala" }
                });

            migrationBuilder.InsertData(
                table: "tblState",
                columns: new[] { "StateId", "Code", "CountryId", "IsActive", "ModifiedBy", "ModifiedDt", "ModifiedRemarks", "Name" },
                values: new object[,]
                {
                    { 33L, "TN", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Tamil Nadu" },
                    { 34L, "PY", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Puducherry" },
                    { 35L, "AN", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Andaman and Nicobar Islands" },
                    { 36L, "TS", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Telangana" },
                    { 37L, "AD", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Andhra Pradesh" },
                    { 38L, "LA", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Ladakh" },
                    { 97L, "OT", 1L, true, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Daman and Diu" }
                });

            migrationBuilder.InsertData(
                table: "tblUsersMaster",
                columns: new[] { "UserId", "Email", "EmailConfirmed", "IsActive", "LoginFailCount", "LoginFailCountdt", "ModifiedBy", "ModifiedDt", "ModifiedRemarks", "NormalizedName", "OrgId", "Password", "PhoneNumber", "PhoneNumberConfirmed", "RequiredChangePassword", "UserName", "UserType", "is_logged_blocked", "logged_blocked_Enddt", "logged_blocked_dt" },
                values: new object[] { 1L, "prabhakarks90@gmail.com", true, true, (byte)0, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Prabhakar", 1L, "123456", "9873404402", true, false, "Admin", 2, (byte)0, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "tblUserOrganisationPermission",
                columns: new[] { "Sno", "HaveAllCompanyAccess", "IsDeleted", "ModifiedBy", "ModifiedDt", "ModifiedRemarks", "OrgId", "UserId" },
                values: new object[] { 1L, true, false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L, 1L });

            migrationBuilder.InsertData(
                table: "tblUserRole",
                columns: new[] { "UserRoleId", "CreatedBy", "CreatedDt", "IsDeleted", "ModifiedBy", "ModifiedDt", "ModifiedRemarks", "RoleId", "UserId" },
                values: new object[] { 1L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1L, 1L });

            migrationBuilder.InsertData(
                table: "tblZoneMaster",
                columns: new[] { "ZoneId", "AlternateContactNo", "AlternateEmail", "City", "CompanyId", "ContactNo", "CountryId", "Email", "IsActive", "Locality", "ModifiedBy", "ModifiedDt", "ModifiedRemarks", "Name", "OfficeAddress", "OrgId", "Pincode", "StateId" },
                values: new object[] { 1L, "", "", "", 1L, "", 0L, "", true, "", 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Delhi", "", 1L, "", 0L });

            migrationBuilder.InsertData(
                table: "tblLocationMaster",
                columns: new[] { "LocationId", "AlternateContactNo", "AlternateEmail", "City", "ContactNo", "CountryId", "Email", "IsActive", "Locality", "LocationType", "ModifiedBy", "ModifiedDt", "ModifiedRemarks", "Name", "OfficeAddress", "OrgId", "Pincode", "StateId", "ZoneId" },
                values: new object[] { 1L, "", "", "", "987340442", 1L, "prabhakarks90@gmail.com", true, "", 1, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Head Office", "", 1L, "110053", 7L, 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblLocationMaster",
                keyColumn: "LocationId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "tblRoleClaim",
                keyColumn: "RoleClaimId",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "tblState",
                keyColumn: "StateId",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                table: "tblUserOrganisationPermission",
                keyColumn: "Sno",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "tblUserRole",
                keyColumn: "UserRoleId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "tblCountry",
                keyColumn: "CountryId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "tblRoleMaster",
                keyColumn: "RoleId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "tblUsersMaster",
                keyColumn: "UserId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "tblZoneMaster",
                keyColumn: "ZoneId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "tblCompanyMaster",
                keyColumn: "CompanyId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "tblOrganisation",
                keyColumn: "OrgId",
                keyValue: 1L);
        }
    }
}
