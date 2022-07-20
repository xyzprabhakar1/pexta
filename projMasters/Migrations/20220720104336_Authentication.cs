using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projMasters.Migrations
{
    public partial class Authentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_app_setting",
                columns: table => new
                {
                    pkid_setting = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    AppSettingKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    AppSettingValue = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_app_setting", x => x.pkid_setting);
                });

            migrationBuilder.CreateTable(
                name: "tblBankMaster",
                columns: table => new
                {
                    BankId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBankMaster", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "tblCodeGenrationMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeGenrationType = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncludeCountryCode = table.Column<bool>(type: "bit", nullable: false),
                    IncludeStateCode = table.Column<bool>(type: "bit", nullable: false),
                    IncludeCompanyCode = table.Column<bool>(type: "bit", nullable: false),
                    IncludeZoneCode = table.Column<bool>(type: "bit", nullable: false),
                    IncludeLocationCode = table.Column<bool>(type: "bit", nullable: false),
                    IncludeYear = table.Column<bool>(type: "bit", nullable: false),
                    IncludeMonthYear = table.Column<bool>(type: "bit", nullable: false),
                    IncludeYearWeek = table.Column<bool>(type: "bit", nullable: false),
                    DigitFormate = table.Column<byte>(type: "tinyint", nullable: false),
                    OrgId = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeGenrationMasterId = table.Column<long>(type: "bigint", nullable: true),
                    EntityType = table.Column<byte>(type: "tinyint", nullable: true),
                    RequestedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestedBy = table.Column<long>(type: "bigint", nullable: true),
                    RequestedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ApprovalDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalBy = table.Column<long>(type: "bigint", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ApprovalStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCodeGenrationMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCodeGenrationMaster_tblCodeGenrationMaster_CodeGenrationMasterId",
                        column: x => x.CodeGenrationMasterId,
                        principalTable: "tblCodeGenrationMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblCountry",
                columns: table => new
                {
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPrefix = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCountry", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "tblCurrency",
                columns: table => new
                {
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCurrency", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "tblFileMaster",
                columns: table => new
                {
                    FileId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFileMaster", x => x.FileId);
                });

            migrationBuilder.CreateTable(
                name: "tblOrganisation",
                columns: table => new
                {
                    OrgId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OfficeAddress = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    City = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    AlternateEmail = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    AlternateContactNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrganisation", x => x.OrgId);
                });

            migrationBuilder.CreateTable(
                name: "tblRoleMaster",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoleMaster", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "tblUserOTP",
                columns: table => new
                {
                    SecurityStamp = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DescId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectiveFromDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveToDt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserOTP", x => x.SecurityStamp);
                });

            migrationBuilder.CreateTable(
                name: "tblCodeGenrationDetails",
                columns: table => new
                {
                    Sno = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(type: "bigint", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZoneCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthYear = table.Column<long>(type: "bigint", nullable: false),
                    Year = table.Column<long>(type: "bigint", nullable: false),
                    YearWeek = table.Column<long>(type: "bigint", nullable: false),
                    Counter = table.Column<long>(type: "bigint", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCodeGenrationDetails", x => x.Sno);
                    table.ForeignKey(
                        name: "FK_tblCodeGenrationDetails_tblCodeGenrationMaster_Id",
                        column: x => x.Id,
                        principalTable: "tblCodeGenrationMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblState",
                columns: table => new
                {
                    StateId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblState", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_tblState_tblCountry_CountryId",
                        column: x => x.CountryId,
                        principalTable: "tblCountry",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "tblCompanyMaster",
                columns: table => new
                {
                    CompanyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrgId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCompanyMaster", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_tblCompanyMaster_tblOrganisation_OrgId",
                        column: x => x.OrgId,
                        principalTable: "tblOrganisation",
                        principalColumn: "OrgId");
                });

            migrationBuilder.CreateTable(
                name: "tblOrganisation_Log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgId = table.Column<long>(type: "bigint", nullable: true),
                    RequestedDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestedBy = table.Column<long>(type: "bigint", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ApprovalDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalBy = table.Column<long>(type: "bigint", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ApprovalStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint", nullable: false),
                    OfficeAddress = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    City = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    AlternateEmail = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    AlternateContactNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrganisation_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOrganisation_Log_tblOrganisation_OrgId",
                        column: x => x.OrgId,
                        principalTable: "tblOrganisation",
                        principalColumn: "OrgId");
                });

            migrationBuilder.CreateTable(
                name: "tblUsersMaster",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LoginFailCount = table.Column<byte>(type: "tinyint", nullable: false),
                    LoginFailCountdt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_logged_blocked = table.Column<byte>(type: "tinyint", nullable: false),
                    logged_blocked_dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    logged_blocked_Enddt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrgId = table.Column<long>(type: "bigint", nullable: true),
                    RequiredChangePassword = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsersMaster", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_tblUsersMaster_tblOrganisation_OrgId",
                        column: x => x.OrgId,
                        principalTable: "tblOrganisation",
                        principalColumn: "OrgId");
                });

            migrationBuilder.CreateTable(
                name: "tblRoleClaim",
                columns: table => new
                {
                    RoleClaimId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentMaster = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    AdditionalClaim = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoleClaim", x => x.RoleClaimId);
                    table.ForeignKey(
                        name: "FK_tblRoleClaim_tblRoleMaster_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tblRoleMaster",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "tblCompanyMaster_Log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    RequestedDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestedBy = table.Column<long>(type: "bigint", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ApprovalDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalBy = table.Column<long>(type: "bigint", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ApprovalStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    OrgId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCompanyMaster_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCompanyMaster_Log_tblCompanyMaster_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "tblCompanyMaster",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_tblCompanyMaster_Log_tblOrganisation_OrgId",
                        column: x => x.OrgId,
                        principalTable: "tblOrganisation",
                        principalColumn: "OrgId");
                });

            migrationBuilder.CreateTable(
                name: "tblZoneMaster",
                columns: table => new
                {
                    ZoneId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OfficeAddress = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    City = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    AlternateEmail = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    AlternateContactNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    OrgId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblZoneMaster", x => x.ZoneId);
                    table.ForeignKey(
                        name: "FK_tblZoneMaster_tblCompanyMaster_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "tblCompanyMaster",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_tblZoneMaster_tblOrganisation_OrgId",
                        column: x => x.OrgId,
                        principalTable: "tblOrganisation",
                        principalColumn: "OrgId");
                });

            migrationBuilder.CreateTable(
                name: "tblUserAllClaim",
                columns: table => new
                {
                    RoleClaimId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentMaster = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    AdditionalClaim = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserAllClaim", x => x.RoleClaimId);
                    table.ForeignKey(
                        name: "FK_tblUserAllClaim_tblUsersMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsersMaster",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "tblUserClaim",
                columns: table => new
                {
                    RoleClaimId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentMaster = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserClaim", x => x.RoleClaimId);
                    table.ForeignKey(
                        name: "FK_tblUserClaim_tblUsersMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsersMaster",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "tblUserCompanyPermission",
                columns: table => new
                {
                    Sno = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    HaveAllZoneAccess = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserCompanyPermission", x => x.Sno);
                    table.ForeignKey(
                        name: "FK_tblUserCompanyPermission_tblCompanyMaster_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "tblCompanyMaster",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_tblUserCompanyPermission_tblUsersMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsersMaster",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "tblUserLoginLog",
                columns: table => new
                {
                    Sno = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DeviceDetails = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LoginStatus = table.Column<bool>(type: "bit", maxLength: 128, nullable: false),
                    FromLocation = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LoginDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserLoginLog", x => x.Sno);
                    table.ForeignKey(
                        name: "FK_tblUserLoginLog_tblUsersMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsersMaster",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "tblUserOrganisationPermission",
                columns: table => new
                {
                    Sno = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    OrgId = table.Column<long>(type: "bigint", nullable: true),
                    HaveAllCompanyAccess = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserOrganisationPermission", x => x.Sno);
                    table.ForeignKey(
                        name: "FK_tblUserOrganisationPermission_tblOrganisation_OrgId",
                        column: x => x.OrgId,
                        principalTable: "tblOrganisation",
                        principalColumn: "OrgId");
                    table.ForeignKey(
                        name: "FK_tblUserOrganisationPermission_tblUsersMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsersMaster",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "tblUserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    RoleId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserRole", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_tblUserRole_tblRoleMaster_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tblRoleMaster",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_tblUserRole_tblUsersMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsersMaster",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "tblLocationMaster",
                columns: table => new
                {
                    LocationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OfficeAddress = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    City = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    AlternateEmail = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    AlternateContactNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    LocationType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ZoneId = table.Column<long>(type: "bigint", nullable: true),
                    OrgId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLocationMaster", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_tblLocationMaster_tblOrganisation_OrgId",
                        column: x => x.OrgId,
                        principalTable: "tblOrganisation",
                        principalColumn: "OrgId");
                    table.ForeignKey(
                        name: "FK_tblLocationMaster_tblZoneMaster_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "tblZoneMaster",
                        principalColumn: "ZoneId");
                });

            migrationBuilder.CreateTable(
                name: "tblUserZonePermission",
                columns: table => new
                {
                    Sno = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    ZoneId = table.Column<long>(type: "bigint", nullable: true),
                    HaveAllLocationAccess = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserZonePermission", x => x.Sno);
                    table.ForeignKey(
                        name: "FK_tblUserZonePermission_tblUsersMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsersMaster",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_tblUserZonePermission_tblZoneMaster_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "tblZoneMaster",
                        principalColumn: "ZoneId");
                });

            migrationBuilder.CreateTable(
                name: "tblZoneMaster_Log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneId = table.Column<long>(type: "bigint", nullable: true),
                    RequestedDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestedBy = table.Column<long>(type: "bigint", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ApprovalDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalBy = table.Column<long>(type: "bigint", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ApprovalStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint", nullable: false),
                    OfficeAddress = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    City = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    AlternateEmail = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    AlternateContactNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    OrgId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblZoneMaster_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblZoneMaster_Log_tblCompanyMaster_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "tblCompanyMaster",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_tblZoneMaster_Log_tblOrganisation_OrgId",
                        column: x => x.OrgId,
                        principalTable: "tblOrganisation",
                        principalColumn: "OrgId");
                    table.ForeignKey(
                        name: "FK_tblZoneMaster_Log_tblZoneMaster_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "tblZoneMaster",
                        principalColumn: "ZoneId");
                });

            migrationBuilder.CreateTable(
                name: "tblLocationMaster_Log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    RequestedDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestedBy = table.Column<long>(type: "bigint", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ApprovalDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalBy = table.Column<long>(type: "bigint", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ApprovalStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint", nullable: false),
                    OfficeAddress = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    City = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    AlternateEmail = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    AlternateContactNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    LocationType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ZoneId = table.Column<long>(type: "bigint", nullable: true),
                    OrgId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLocationMaster_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblLocationMaster_Log_tblLocationMaster_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tblLocationMaster",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_tblLocationMaster_Log_tblOrganisation_OrgId",
                        column: x => x.OrgId,
                        principalTable: "tblOrganisation",
                        principalColumn: "OrgId");
                    table.ForeignKey(
                        name: "FK_tblLocationMaster_Log_tblZoneMaster_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "tblZoneMaster",
                        principalColumn: "ZoneId");
                });

            migrationBuilder.CreateTable(
                name: "tblUserAllLocationPermission",
                columns: table => new
                {
                    Sno = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserAllLocationPermission", x => x.Sno);
                    table.ForeignKey(
                        name: "FK_tblUserAllLocationPermission_tblLocationMaster_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tblLocationMaster",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_tblUserAllLocationPermission_tblUsersMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsersMaster",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "tblUserLocationPermission",
                columns: table => new
                {
                    Sno = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserLocationPermission", x => x.Sno);
                    table.ForeignKey(
                        name: "FK_tblUserLocationPermission_tblLocationMaster_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tblLocationMaster",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_tblUserLocationPermission_tblUsersMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsersMaster",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCodeGenrationDetails_Id",
                table: "tblCodeGenrationDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblCodeGenrationMaster_CodeGenrationMasterId",
                table: "tblCodeGenrationMaster",
                column: "CodeGenrationMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCompanyMaster_OrgId",
                table: "tblCompanyMaster",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCompanyMaster_Log_CompanyId",
                table: "tblCompanyMaster_Log",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCompanyMaster_Log_OrgId",
                table: "tblCompanyMaster_Log",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLocationMaster_OrgId",
                table: "tblLocationMaster",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLocationMaster_ZoneId",
                table: "tblLocationMaster",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLocationMaster_Log_LocationId",
                table: "tblLocationMaster_Log",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLocationMaster_Log_OrgId",
                table: "tblLocationMaster_Log",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLocationMaster_Log_ZoneId",
                table: "tblLocationMaster_Log",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrganisation_Log_OrgId",
                table: "tblOrganisation_Log",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRoleClaim_RoleId",
                table: "tblRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblState_CountryId",
                table: "tblState",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserAllClaim_UserId",
                table: "tblUserAllClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserAllLocationPermission_LocationId",
                table: "tblUserAllLocationPermission",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserAllLocationPermission_UserId",
                table: "tblUserAllLocationPermission",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserClaim_UserId",
                table: "tblUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserCompanyPermission_CompanyId",
                table: "tblUserCompanyPermission",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserCompanyPermission_UserId",
                table: "tblUserCompanyPermission",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserLocationPermission_LocationId",
                table: "tblUserLocationPermission",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserLocationPermission_UserId",
                table: "tblUserLocationPermission",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserLoginLog_UserId",
                table: "tblUserLoginLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserOrganisationPermission_OrgId",
                table: "tblUserOrganisationPermission",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserOrganisationPermission_UserId",
                table: "tblUserOrganisationPermission",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserOTP_UserId",
                table: "tblUserOTP",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRole_RoleId",
                table: "tblUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRole_UserId",
                table: "tblUserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsersMaster_OrgId",
                table: "tblUsersMaster",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserZonePermission_UserId",
                table: "tblUserZonePermission",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserZonePermission_ZoneId",
                table: "tblUserZonePermission",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_tblZoneMaster_CompanyId",
                table: "tblZoneMaster",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblZoneMaster_OrgId",
                table: "tblZoneMaster",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_tblZoneMaster_Log_CompanyId",
                table: "tblZoneMaster_Log",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblZoneMaster_Log_OrgId",
                table: "tblZoneMaster_Log",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_tblZoneMaster_Log_ZoneId",
                table: "tblZoneMaster_Log",
                column: "ZoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_app_setting");

            migrationBuilder.DropTable(
                name: "tblBankMaster");

            migrationBuilder.DropTable(
                name: "tblCodeGenrationDetails");

            migrationBuilder.DropTable(
                name: "tblCompanyMaster_Log");

            migrationBuilder.DropTable(
                name: "tblCurrency");

            migrationBuilder.DropTable(
                name: "tblFileMaster");

            migrationBuilder.DropTable(
                name: "tblLocationMaster_Log");

            migrationBuilder.DropTable(
                name: "tblOrganisation_Log");

            migrationBuilder.DropTable(
                name: "tblRoleClaim");

            migrationBuilder.DropTable(
                name: "tblState");

            migrationBuilder.DropTable(
                name: "tblUserAllClaim");

            migrationBuilder.DropTable(
                name: "tblUserAllLocationPermission");

            migrationBuilder.DropTable(
                name: "tblUserClaim");

            migrationBuilder.DropTable(
                name: "tblUserCompanyPermission");

            migrationBuilder.DropTable(
                name: "tblUserLocationPermission");

            migrationBuilder.DropTable(
                name: "tblUserLoginLog");

            migrationBuilder.DropTable(
                name: "tblUserOrganisationPermission");

            migrationBuilder.DropTable(
                name: "tblUserOTP");

            migrationBuilder.DropTable(
                name: "tblUserRole");

            migrationBuilder.DropTable(
                name: "tblUserZonePermission");

            migrationBuilder.DropTable(
                name: "tblZoneMaster_Log");

            migrationBuilder.DropTable(
                name: "tblCodeGenrationMaster");

            migrationBuilder.DropTable(
                name: "tblCountry");

            migrationBuilder.DropTable(
                name: "tblLocationMaster");

            migrationBuilder.DropTable(
                name: "tblRoleMaster");

            migrationBuilder.DropTable(
                name: "tblUsersMaster");

            migrationBuilder.DropTable(
                name: "tblZoneMaster");

            migrationBuilder.DropTable(
                name: "tblCompanyMaster");

            migrationBuilder.DropTable(
                name: "tblOrganisation");
        }
    }
}
