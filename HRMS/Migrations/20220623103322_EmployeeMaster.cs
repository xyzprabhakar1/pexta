using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    public partial class EmployeeMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblDepartment",
                columns: table => new
                {
                    DeptId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDepartment", x => x.DeptId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblDesignation",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<uint>(type: "int unsigned", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OrgId = table.Column<uint>(type: "int unsigned", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDesignation", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmployeeMaster",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    FatherName = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dob = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployeeMaster", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblGrade",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<uint>(type: "int unsigned", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OrgId = table.Column<uint>(type: "int unsigned", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGrade", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblHolidayMaster",
                columns: table => new
                {
                    HolidayId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FromDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Todate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HolidayName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHolidayMaster", x => x.HolidayId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblReligionMaster",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<uint>(type: "int unsigned", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OrgId = table.Column<uint>(type: "int unsigned", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReligionMaster", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblDepartWorkingRole",
                columns: table => new
                {
                    WorkingRoleId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeptId = table.Column<uint>(type: "int unsigned", nullable: true),
                    OrgId = table.Column<uint>(type: "int unsigned", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDepartWorkingRole", x => x.WorkingRoleId);
                    table.ForeignKey(
                        name: "FK_tblDepartWorkingRole_tblDepartment_DeptId",
                        column: x => x.DeptId,
                        principalTable: "tblDepartment",
                        principalColumn: "DeptId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpAddress",
                columns: table => new
                {
                    AddressId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Address1 = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address2 = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pincode = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StateId = table.Column<uint>(type: "int unsigned", nullable: false),
                    CountryId = table.Column<uint>(type: "int unsigned", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpAddress", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_tblEmpAddress_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpContacts",
                columns: table => new
                {
                    ContactId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Email = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactNo = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpContacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_tblEmpContacts_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpDocument",
                columns: table => new
                {
                    DocumentDetailId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    DocumentNo = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Details = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IssueDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DocumentPaths = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpDocument", x => x.DocumentDetailId);
                    table.ForeignKey(
                        name: "FK_tblEmpDocument_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpFamilyDetails",
                columns: table => new
                {
                    FamilyDetailId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    enmFamily = table.Column<int>(type: "int", nullable: false),
                    RelationName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dob = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IDProofType = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDProofNo = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Occupation = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactNo = table.Column<string>(type: "varchar(24)", maxLength: 24, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsNominee = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NomineePercentage = table.Column<double>(type: "double", nullable: false),
                    IsDependent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpFamilyDetails", x => x.FamilyDetailId);
                    table.ForeignKey(
                        name: "FK_tblEmpFamilyDetails_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpLocation",
                columns: table => new
                {
                    EmpLocationId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    CompanyId = table.Column<uint>(type: "int unsigned", nullable: true),
                    ZoneId = table.Column<uint>(type: "int unsigned", nullable: true),
                    LocationId = table.Column<uint>(type: "int unsigned", nullable: true),
                    SubLocationId = table.Column<uint>(type: "int unsigned", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EffectiveDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpLocation", x => x.EmpLocationId);
                    table.ForeignKey(
                        name: "FK_tblEmpLocation_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmployeeMaster_log",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Title = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    FatherName = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dob = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployeeMaster_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmployeeMaster_log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpManager",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    ManagerId = table.Column<uint>(type: "int unsigned", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EffectiveDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpManager_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpManager_tblEmployeeMaster_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpOfficialDetails",
                columns: table => new
                {
                    OfficialDetailId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    CardNo = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrgJoiningDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ComJoiningDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TerminationDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DefaultProbationPeriodMonth = table.Column<uint>(type: "int unsigned", nullable: false),
                    DefaultProbationPeriodDay = table.Column<uint>(type: "int unsigned", nullable: false),
                    DefaultNoticePeriodMonth = table.Column<uint>(type: "int unsigned", nullable: false),
                    DefaultNoticePeriodDay = table.Column<uint>(type: "int unsigned", nullable: false),
                    ActualProbationPeriodMonth = table.Column<uint>(type: "int unsigned", nullable: false),
                    ActualProbationPeriodDay = table.Column<uint>(type: "int unsigned", nullable: false),
                    ActualNoticePeriodMonth = table.Column<uint>(type: "int unsigned", nullable: false),
                    ActualNoticePeriodDay = table.Column<uint>(type: "int unsigned", nullable: false),
                    PanNo = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PanName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdharNo = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hr_spoc = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JoiningRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TerminationRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpOfficialDetails", x => x.OfficialDetailId);
                    table.ForeignKey(
                        name: "FK_tblEmpOfficialDetails_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpPersonalDetails",
                columns: table => new
                {
                    PersonalDetailId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nationality = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Religion = table.Column<int>(type: "int", nullable: false),
                    MotherName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    BloodGroup = table.Column<int>(type: "int", nullable: false),
                    AnniversaryDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpPersonalDetails", x => x.PersonalDetailId);
                    table.ForeignKey(
                        name: "FK_tblEmpPersonalDetails_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpQualification",
                columns: table => new
                {
                    QualificationId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    QualificationType = table.Column<int>(type: "int", nullable: false),
                    CourseTitle = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Specialization = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    University = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    College = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DurationStartMonth = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    DurationStartYear = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    DurationEndMonth = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    DurationEndYear = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    CourseType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Percentage = table.Column<double>(type: "double", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpQualification", x => x.QualificationId);
                    table.ForeignKey(
                        name: "FK_tblEmpQualification_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpWorkExperience",
                columns: table => new
                {
                    WorkExperienceId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Designation = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EmployeeCode = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnnualSalary = table.Column<double>(type: "double", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpWorkExperience", x => x.WorkExperienceId);
                    table.ForeignKey(
                        name: "FK_tblEmpWorkExperience_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpDesignation",
                columns: table => new
                {
                    EmpDesId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    DesId = table.Column<uint>(type: "int unsigned", nullable: true),
                    GradeId = table.Column<uint>(type: "int unsigned", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EffectiveDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpDesignation", x => x.EmpDesId);
                    table.ForeignKey(
                        name: "FK_tblEmpDesignation_tblDesignation_DesId",
                        column: x => x.DesId,
                        principalTable: "tblDesignation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpDesignation_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpDesignation_tblGrade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "tblGrade",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpDepartment",
                columns: table => new
                {
                    EmpDepId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    DepId = table.Column<uint>(type: "int unsigned", nullable: true),
                    DepWorkingRoleId = table.Column<uint>(type: "int unsigned", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EffectiveDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpDepartment", x => x.EmpDepId);
                    table.ForeignKey(
                        name: "FK_tblEmpDepartment_tblDepartment_DepId",
                        column: x => x.DepId,
                        principalTable: "tblDepartment",
                        principalColumn: "DeptId");
                    table.ForeignKey(
                        name: "FK_tblEmpDepartment_tblDepartWorkingRole_DepWorkingRoleId",
                        column: x => x.DepWorkingRoleId,
                        principalTable: "tblDepartWorkingRole",
                        principalColumn: "WorkingRoleId");
                    table.ForeignKey(
                        name: "FK_tblEmpDepartment_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpBankDetails",
                columns: table => new
                {
                    BankDetailId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    DocumentId = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankId = table.Column<uint>(type: "int unsigned", nullable: true),
                    BranchCode = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BranchName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountNumber = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UPI = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameonBank = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpBankDetails", x => x.BankDetailId);
                    table.ForeignKey(
                        name: "FK_tblEmpBankDetails_tblEmpDocument_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "tblEmpDocument",
                        principalColumn: "DocumentDetailId");
                    table.ForeignKey(
                        name: "FK_tblEmpBankDetails_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpAddress_Log",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    AddressId = table.Column<uint>(type: "int unsigned", nullable: true),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    ContactType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Address1 = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address2 = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pincode = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StateId = table.Column<uint>(type: "int unsigned", nullable: false),
                    CountryId = table.Column<uint>(type: "int unsigned", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpAddress_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpAddress_Log_tblEmpAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "tblEmpAddress",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_tblEmpAddress_Log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpAddress_Log_tblEmployeeMaster_log_EmpLogId",
                        column: x => x.EmpLogId,
                        principalTable: "tblEmployeeMaster_log",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpContacts_Log",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    ContactId = table.Column<uint>(type: "int unsigned", nullable: true),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    ContactType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Email = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactNo = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpContacts_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpContacts_Log_tblEmpContacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "tblEmpContacts",
                        principalColumn: "ContactId");
                    table.ForeignKey(
                        name: "FK_tblEmpContacts_Log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpContacts_Log_tblEmployeeMaster_log_EmpLogId",
                        column: x => x.EmpLogId,
                        principalTable: "tblEmployeeMaster_log",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpDocument_log",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    DocumentDetailId = table.Column<uint>(type: "int unsigned", nullable: true),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    DocumentNo = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Details = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IssueDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DocumentPaths = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpDocument_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpDocument_log_tblEmpDocument_DocumentDetailId",
                        column: x => x.DocumentDetailId,
                        principalTable: "tblEmpDocument",
                        principalColumn: "DocumentDetailId");
                    table.ForeignKey(
                        name: "FK_tblEmpDocument_log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpDocument_log_tblEmployeeMaster_log_EmpLogId",
                        column: x => x.EmpLogId,
                        principalTable: "tblEmployeeMaster_log",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpFamilyDetails_log",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    FamilyDetailId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    enmFamily = table.Column<int>(type: "int", nullable: false),
                    RelationName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dob = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IDProofType = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IDProofNo = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Occupation = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactNo = table.Column<string>(type: "varchar(24)", maxLength: 24, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsNominee = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NomineePercentage = table.Column<double>(type: "double", nullable: false),
                    IsDependent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpFamilyDetails_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpFamilyDetails_log_tblEmpFamilyDetails_FamilyDetailId",
                        column: x => x.FamilyDetailId,
                        principalTable: "tblEmpFamilyDetails",
                        principalColumn: "FamilyDetailId");
                    table.ForeignKey(
                        name: "FK_tblEmpFamilyDetails_log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpFamilyDetails_log_tblEmployeeMaster_log_EmpLogId",
                        column: x => x.EmpLogId,
                        principalTable: "tblEmployeeMaster_log",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpLocation_log",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpLocationId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    CompanyId = table.Column<uint>(type: "int unsigned", nullable: true),
                    ZoneId = table.Column<uint>(type: "int unsigned", nullable: true),
                    LocationId = table.Column<uint>(type: "int unsigned", nullable: true),
                    SubLocationId = table.Column<uint>(type: "int unsigned", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EffectiveDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpLocation_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpLocation_log_tblEmpLocation_EmpLocationId",
                        column: x => x.EmpLocationId,
                        principalTable: "tblEmpLocation",
                        principalColumn: "EmpLocationId");
                    table.ForeignKey(
                        name: "FK_tblEmpLocation_log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpLocation_log_tblEmployeeMaster_log_EmpLogId",
                        column: x => x.EmpLogId,
                        principalTable: "tblEmployeeMaster_log",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpManager_log",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    ManagerId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EffectiveDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpManager_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpManager_log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpManager_log_tblEmployeeMaster_log_EmpLogId",
                        column: x => x.EmpLogId,
                        principalTable: "tblEmployeeMaster_log",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpManager_log_tblEmployeeMaster_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpQualification_log",
                columns: table => new
                {
                    QualificationId = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    QualificationType = table.Column<int>(type: "int", nullable: false),
                    CourseTitle = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Specialization = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    University = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    College = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DurationStartMonth = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    DurationStartYear = table.Column<short>(type: "smallint", nullable: false),
                    DurationEndMonth = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    DurationEndYear = table.Column<short>(type: "smallint", nullable: false),
                    CourseType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Percentage = table.Column<double>(type: "double", nullable: false),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpQualification_log", x => x.QualificationId);
                    table.ForeignKey(
                        name: "FK_tblEmpQualification_log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpQualification_log_tblEmployeeMaster_log_EmpLogId",
                        column: x => x.EmpLogId,
                        principalTable: "tblEmployeeMaster_log",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpOfficialDetails_log",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    OfficialDetailId = table.Column<uint>(type: "int unsigned", nullable: true),
                    CardNo = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    OrgJoiningDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ComJoiningDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TerminationDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DefaultProbationPeriodMonth = table.Column<uint>(type: "int unsigned", nullable: false),
                    DefaultProbationPeriodDay = table.Column<uint>(type: "int unsigned", nullable: false),
                    DefaultNoticePeriodMonth = table.Column<uint>(type: "int unsigned", nullable: false),
                    DefaultNoticePeriodDay = table.Column<uint>(type: "int unsigned", nullable: false),
                    ActualProbationPeriodMonth = table.Column<uint>(type: "int unsigned", nullable: false),
                    ActualProbationPeriodDay = table.Column<uint>(type: "int unsigned", nullable: false),
                    ActualNoticePeriodMonth = table.Column<uint>(type: "int unsigned", nullable: false),
                    ActualNoticePeriodDay = table.Column<uint>(type: "int unsigned", nullable: false),
                    PanNo = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PanName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdharNo = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hr_spoc = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JoiningRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TerminationRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpOfficialDetails_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpOfficialDetails_log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpOfficialDetails_log_tblEmployeeMaster_log_EmpLogId",
                        column: x => x.EmpLogId,
                        principalTable: "tblEmployeeMaster_log",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpOfficialDetails_log_tblEmpOfficialDetails_OfficialDeta~",
                        column: x => x.OfficialDetailId,
                        principalTable: "tblEmpOfficialDetails",
                        principalColumn: "OfficialDetailId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpPersonalDetails_log",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    PersonalDetailId = table.Column<uint>(type: "int unsigned", nullable: true),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Nationality = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Religion = table.Column<int>(type: "int", nullable: false),
                    MotherName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    BloodGroup = table.Column<int>(type: "int", nullable: false),
                    AnniversaryDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpPersonalDetails_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpPersonalDetails_log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpPersonalDetails_log_tblEmployeeMaster_log_EmpLogId",
                        column: x => x.EmpLogId,
                        principalTable: "tblEmployeeMaster_log",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpPersonalDetails_log_tblEmpPersonalDetails_PersonalDeta~",
                        column: x => x.PersonalDetailId,
                        principalTable: "tblEmpPersonalDetails",
                        principalColumn: "PersonalDetailId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpWorkExperience_log",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    WorkExperienceId = table.Column<uint>(type: "int unsigned", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Designation = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EmployeeCode = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnnualSalary = table.Column<double>(type: "double", nullable: false),
                    ModifiedDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ModifiedBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ModifiedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpWorkExperience_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpWorkExperience_log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpWorkExperience_log_tblEmployeeMaster_log_EmpLogId",
                        column: x => x.EmpLogId,
                        principalTable: "tblEmployeeMaster_log",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpWorkExperience_log_tblEmpWorkExperience_WorkExperience~",
                        column: x => x.WorkExperienceId,
                        principalTable: "tblEmpWorkExperience",
                        principalColumn: "WorkExperienceId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpDesignation_log",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpDesId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    DesId = table.Column<uint>(type: "int unsigned", nullable: true),
                    GradeId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EffectiveDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpDesignation_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpDesignation_log_tblDesignation_DesId",
                        column: x => x.DesId,
                        principalTable: "tblDesignation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpDesignation_log_tblEmpDesignation_EmpDesId",
                        column: x => x.EmpDesId,
                        principalTable: "tblEmpDesignation",
                        principalColumn: "EmpDesId");
                    table.ForeignKey(
                        name: "FK_tblEmpDesignation_log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpDesignation_log_tblEmployeeMaster_log_EmpLogId",
                        column: x => x.EmpLogId,
                        principalTable: "tblEmployeeMaster_log",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpDesignation_log_tblGrade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "tblGrade",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpDepartment_log",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpDepId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    DepId = table.Column<uint>(type: "int unsigned", nullable: true),
                    DepWorkingRoleId = table.Column<uint>(type: "int unsigned", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EffectiveDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpDepartment_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpDepartment_log_tblDepartment_DepId",
                        column: x => x.DepId,
                        principalTable: "tblDepartment",
                        principalColumn: "DeptId");
                    table.ForeignKey(
                        name: "FK_tblEmpDepartment_log_tblDepartWorkingRole_DepWorkingRoleId",
                        column: x => x.DepWorkingRoleId,
                        principalTable: "tblDepartWorkingRole",
                        principalColumn: "WorkingRoleId");
                    table.ForeignKey(
                        name: "FK_tblEmpDepartment_log_tblEmpDepartment_EmpDepId",
                        column: x => x.EmpDepId,
                        principalTable: "tblEmpDepartment",
                        principalColumn: "EmpDepId");
                    table.ForeignKey(
                        name: "FK_tblEmpDepartment_log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpDepartment_log_tblEmployeeMaster_log_EmpLogId",
                        column: x => x.EmpLogId,
                        principalTable: "tblEmployeeMaster_log",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tblEmpBankDetails_log",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<uint>(type: "int unsigned", nullable: true),
                    DocumentId = table.Column<uint>(type: "int unsigned", nullable: true),
                    EmpLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    DocumentLogId = table.Column<uint>(type: "int unsigned", nullable: true),
                    tblEmpDocument_logId = table.Column<uint>(type: "int unsigned", nullable: false),
                    BankDetailId = table.Column<uint>(type: "int unsigned", nullable: true),
                    RequestedDt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RequestedBy = table.Column<uint>(type: "int unsigned", nullable: false),
                    RequestedRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalDt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ApprovalBy = table.Column<uint>(type: "int unsigned", nullable: true),
                    ApprovalRemarks = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovalStatus = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EntityType = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    BankId = table.Column<uint>(type: "int unsigned", nullable: true),
                    BranchCode = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BranchName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountNumber = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UPI = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameonBank = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmpBankDetails_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEmpBankDetails_log_tblEmpBankDetails_BankDetailId",
                        column: x => x.BankDetailId,
                        principalTable: "tblEmpBankDetails",
                        principalColumn: "BankDetailId");
                    table.ForeignKey(
                        name: "FK_tblEmpBankDetails_log_tblEmpDocument_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "tblEmpDocument",
                        principalColumn: "DocumentDetailId");
                    table.ForeignKey(
                        name: "FK_tblEmpBankDetails_log_tblEmpDocument_log_tblEmpDocument_logId",
                        column: x => x.tblEmpDocument_logId,
                        principalTable: "tblEmpDocument_log",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEmpBankDetails_log_tblEmployeeMaster_EmpId",
                        column: x => x.EmpId,
                        principalTable: "tblEmployeeMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEmpBankDetails_log_tblEmployeeMaster_log_EmpLogId",
                        column: x => x.EmpLogId,
                        principalTable: "tblEmployeeMaster_log",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tblDepartWorkingRole_DeptId",
                table: "tblDepartWorkingRole",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpAddress_EmpId",
                table: "tblEmpAddress",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpAddress_Log_AddressId",
                table: "tblEmpAddress_Log",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpAddress_Log_EmpId",
                table: "tblEmpAddress_Log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpAddress_Log_EmpLogId",
                table: "tblEmpAddress_Log",
                column: "EmpLogId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpBankDetails_DocumentId",
                table: "tblEmpBankDetails",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpBankDetails_EmpId",
                table: "tblEmpBankDetails",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpBankDetails_log_BankDetailId",
                table: "tblEmpBankDetails_log",
                column: "BankDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpBankDetails_log_DocumentId",
                table: "tblEmpBankDetails_log",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpBankDetails_log_EmpId",
                table: "tblEmpBankDetails_log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpBankDetails_log_EmpLogId",
                table: "tblEmpBankDetails_log",
                column: "EmpLogId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpBankDetails_log_tblEmpDocument_logId",
                table: "tblEmpBankDetails_log",
                column: "tblEmpDocument_logId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpContacts_EmpId",
                table: "tblEmpContacts",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpContacts_Log_ContactId",
                table: "tblEmpContacts_Log",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpContacts_Log_EmpId",
                table: "tblEmpContacts_Log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpContacts_Log_EmpLogId",
                table: "tblEmpContacts_Log",
                column: "EmpLogId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDepartment_DepId",
                table: "tblEmpDepartment",
                column: "DepId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDepartment_DepWorkingRoleId",
                table: "tblEmpDepartment",
                column: "DepWorkingRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDepartment_EmpId",
                table: "tblEmpDepartment",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDepartment_log_DepId",
                table: "tblEmpDepartment_log",
                column: "DepId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDepartment_log_DepWorkingRoleId",
                table: "tblEmpDepartment_log",
                column: "DepWorkingRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDepartment_log_EmpDepId",
                table: "tblEmpDepartment_log",
                column: "EmpDepId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDepartment_log_EmpId",
                table: "tblEmpDepartment_log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDepartment_log_EmpLogId",
                table: "tblEmpDepartment_log",
                column: "EmpLogId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDesignation_DesId",
                table: "tblEmpDesignation",
                column: "DesId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDesignation_EmpId",
                table: "tblEmpDesignation",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDesignation_GradeId",
                table: "tblEmpDesignation",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDesignation_log_DesId",
                table: "tblEmpDesignation_log",
                column: "DesId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDesignation_log_EmpDesId",
                table: "tblEmpDesignation_log",
                column: "EmpDesId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDesignation_log_EmpId",
                table: "tblEmpDesignation_log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDesignation_log_EmpLogId",
                table: "tblEmpDesignation_log",
                column: "EmpLogId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDesignation_log_GradeId",
                table: "tblEmpDesignation_log",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDocument_EmpId",
                table: "tblEmpDocument",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDocument_log_DocumentDetailId",
                table: "tblEmpDocument_log",
                column: "DocumentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDocument_log_EmpId",
                table: "tblEmpDocument_log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpDocument_log_EmpLogId",
                table: "tblEmpDocument_log",
                column: "EmpLogId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpFamilyDetails_EmpId",
                table: "tblEmpFamilyDetails",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpFamilyDetails_log_EmpId",
                table: "tblEmpFamilyDetails_log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpFamilyDetails_log_EmpLogId",
                table: "tblEmpFamilyDetails_log",
                column: "EmpLogId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpFamilyDetails_log_FamilyDetailId",
                table: "tblEmpFamilyDetails_log",
                column: "FamilyDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpLocation_EmpId",
                table: "tblEmpLocation",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpLocation_log_EmpId",
                table: "tblEmpLocation_log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpLocation_log_EmpLocationId",
                table: "tblEmpLocation_log",
                column: "EmpLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpLocation_log_EmpLogId",
                table: "tblEmpLocation_log",
                column: "EmpLogId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeMaster_log_EmpId",
                table: "tblEmployeeMaster_log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpManager_EmpId",
                table: "tblEmpManager",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpManager_ManagerId",
                table: "tblEmpManager",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpManager_log_EmpId",
                table: "tblEmpManager_log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpManager_log_EmpLogId",
                table: "tblEmpManager_log",
                column: "EmpLogId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpManager_log_ManagerId",
                table: "tblEmpManager_log",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpOfficialDetails_EmpId",
                table: "tblEmpOfficialDetails",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpOfficialDetails_log_EmpId",
                table: "tblEmpOfficialDetails_log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpOfficialDetails_log_EmpLogId",
                table: "tblEmpOfficialDetails_log",
                column: "EmpLogId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpOfficialDetails_log_OfficialDetailId",
                table: "tblEmpOfficialDetails_log",
                column: "OfficialDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpPersonalDetails_EmpId",
                table: "tblEmpPersonalDetails",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpPersonalDetails_log_EmpId",
                table: "tblEmpPersonalDetails_log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpPersonalDetails_log_EmpLogId",
                table: "tblEmpPersonalDetails_log",
                column: "EmpLogId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpPersonalDetails_log_PersonalDetailId",
                table: "tblEmpPersonalDetails_log",
                column: "PersonalDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpQualification_EmpId",
                table: "tblEmpQualification",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpQualification_log_EmpId",
                table: "tblEmpQualification_log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpQualification_log_EmpLogId",
                table: "tblEmpQualification_log",
                column: "EmpLogId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpWorkExperience_EmpId",
                table: "tblEmpWorkExperience",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpWorkExperience_log_EmpId",
                table: "tblEmpWorkExperience_log",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpWorkExperience_log_EmpLogId",
                table: "tblEmpWorkExperience_log",
                column: "EmpLogId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmpWorkExperience_log_WorkExperienceId",
                table: "tblEmpWorkExperience_log",
                column: "WorkExperienceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEmpAddress_Log");

            migrationBuilder.DropTable(
                name: "tblEmpBankDetails_log");

            migrationBuilder.DropTable(
                name: "tblEmpContacts_Log");

            migrationBuilder.DropTable(
                name: "tblEmpDepartment_log");

            migrationBuilder.DropTable(
                name: "tblEmpDesignation_log");

            migrationBuilder.DropTable(
                name: "tblEmpFamilyDetails_log");

            migrationBuilder.DropTable(
                name: "tblEmpLocation_log");

            migrationBuilder.DropTable(
                name: "tblEmpManager");

            migrationBuilder.DropTable(
                name: "tblEmpManager_log");

            migrationBuilder.DropTable(
                name: "tblEmpOfficialDetails_log");

            migrationBuilder.DropTable(
                name: "tblEmpPersonalDetails_log");

            migrationBuilder.DropTable(
                name: "tblEmpQualification");

            migrationBuilder.DropTable(
                name: "tblEmpQualification_log");

            migrationBuilder.DropTable(
                name: "tblEmpWorkExperience_log");

            migrationBuilder.DropTable(
                name: "tblHolidayMaster");

            migrationBuilder.DropTable(
                name: "tblReligionMaster");

            migrationBuilder.DropTable(
                name: "tblEmpAddress");

            migrationBuilder.DropTable(
                name: "tblEmpBankDetails");

            migrationBuilder.DropTable(
                name: "tblEmpDocument_log");

            migrationBuilder.DropTable(
                name: "tblEmpContacts");

            migrationBuilder.DropTable(
                name: "tblEmpDepartment");

            migrationBuilder.DropTable(
                name: "tblEmpDesignation");

            migrationBuilder.DropTable(
                name: "tblEmpFamilyDetails");

            migrationBuilder.DropTable(
                name: "tblEmpLocation");

            migrationBuilder.DropTable(
                name: "tblEmpOfficialDetails");

            migrationBuilder.DropTable(
                name: "tblEmpPersonalDetails");

            migrationBuilder.DropTable(
                name: "tblEmpWorkExperience");

            migrationBuilder.DropTable(
                name: "tblEmpDocument");

            migrationBuilder.DropTable(
                name: "tblEmployeeMaster_log");

            migrationBuilder.DropTable(
                name: "tblDepartWorkingRole");

            migrationBuilder.DropTable(
                name: "tblDesignation");

            migrationBuilder.DropTable(
                name: "tblGrade");

            migrationBuilder.DropTable(
                name: "tblEmployeeMaster");

            migrationBuilder.DropTable(
                name: "tblDepartment");
        }
    }
}
