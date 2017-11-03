﻿// <auto-generated />
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DataAccessLayer.Migrations.FunctionalDbEntitiesMigrations
{
    [DbContext(typeof(FunctionalDbEntities))]
    [Migration("20171102094906_mymijlkg")]
    partial class mymijlkg
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Academics_Mentor");

                    b.Property<string>("Academics_Mentor_Designation");

                    b.Property<string>("Address");

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressLine3");

                    b.Property<string>("App_Status");

                    b.Property<int?>("Batch");

                    b.Property<string>("BloodGroup");

                    b.Property<string>("Caste");

                    b.Property<string>("Category");

                    b.Property<int?>("CenterId");

                    b.Property<int?>("City");

                    b.Property<int?>("Country");

                    b.Property<int?>("Course");

                    b.Property<DateTime>("Create_date");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("DOB");

                    b.Property<DateTime?>("DOJ");

                    b.Property<string>("Del_Status");

                    b.Property<int?>("Education");

                    b.Property<string>("Email");

                    b.Property<byte[]>("EncryptedMobileNo");

                    b.Property<int?>("Entrance_Exam");

                    b.Property<string>("FCRollNo");

                    b.Property<int?>("Father_Address");

                    b.Property<string>("FirstName");

                    b.Property<int?>("Gaps_In_Education");

                    b.Property<string>("Gender");

                    b.Property<decimal?>("Graduation");

                    b.Property<decimal?>("HSC_Marks");

                    b.Property<string>("IP_Address");

                    b.Property<string>("IsAknowledgemail");

                    b.Property<string>("LastName");

                    b.Property<int?>("LocalGuardian");

                    b.Property<decimal?>("MAT_CAT");

                    b.Property<int?>("Mentorid");

                    b.Property<string>("MiddleName");

                    b.Property<string>("MobileNo");

                    b.Property<string>("PIBMEmailId");

                    b.Property<string>("PRNNo");

                    b.Property<string>("PhoneNo");

                    b.Property<string>("Photo");

                    b.Property<bool?>("PhysicallyHandicapped");

                    b.Property<string>("Pincode");

                    b.Property<int?>("Relative");

                    b.Property<string>("Religion");

                    b.Property<string>("RollNo");

                    b.Property<decimal?>("SSC_Marks");

                    b.Property<int?>("Section");

                    b.Property<int?>("Semester");

                    b.Property<string>("SpecializationMajor");

                    b.Property<string>("Specialization_Minor");

                    b.Property<int?>("State");

                    b.Property<int?>("User_Id");

                    b.Property<string>("Valid_Code");

                    b.Property<string>("WhatsappMobileNo");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
