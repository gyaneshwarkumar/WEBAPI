using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Academics_Mentor = table.Column<int>(type: "int", nullable: true),
                    Academics_Mentor_Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    App_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Batch = table.Column<int>(type: "int", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CenterId = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<int>(type: "int", nullable: true),
                    Course = table.Column<int>(type: "int", nullable: true),
                    Create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DOJ = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Del_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncryptedMobileNo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Entrance_Exam = table.Column<int>(type: "int", nullable: true),
                    FCRollNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Father_Address = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gaps_In_Education = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Graduation = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    HSC_Marks = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    IP_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAknowledgemail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGuardian = table.Column<int>(type: "int", nullable: true),
                    MAT_CAT = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Mentorid = table.Column<int>(type: "int", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIBMEmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRNNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicallyHandicapped = table.Column<bool>(type: "bit", nullable: true),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relative = table.Column<int>(type: "int", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RollNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSC_Marks = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Section = table.Column<int>(type: "int", nullable: true),
                    Semester = table.Column<int>(type: "int", nullable: true),
                    SpecializationMajor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization_Minor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: true),
                    User_Id = table.Column<int>(type: "int", nullable: true),
                    Valid_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsappMobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
