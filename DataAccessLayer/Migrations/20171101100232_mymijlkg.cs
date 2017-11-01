using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Migrations
{
    public partial class mymijlkg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acedemic_Year",
                table: "AcademicYear");

            migrationBuilder.DropColumn(
                name: "Batch_Name",
                table: "AcademicYear");

            migrationBuilder.DropColumn(
                name: "Course_Id",
                table: "AcademicYear");

            migrationBuilder.DropColumn(
                name: "Created_Date",
                table: "AcademicYear");

            migrationBuilder.AddColumn<string>(
                name: "Academic_Year",
                table: "AcademicYear",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BatchInchargeId",
                table: "AcademicYear",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "AcademicYear",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "AcademicYear",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DurationType",
                table: "AcademicYear",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatternId",
                table: "AcademicYear",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartYear",
                table: "AcademicYear",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCourseId",
                table: "AcademicYear",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Academic_Year",
                table: "AcademicYear");

            migrationBuilder.DropColumn(
                name: "BatchInchargeId",
                table: "AcademicYear");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "AcademicYear");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "AcademicYear");

            migrationBuilder.DropColumn(
                name: "DurationType",
                table: "AcademicYear");

            migrationBuilder.DropColumn(
                name: "PatternId",
                table: "AcademicYear");

            migrationBuilder.DropColumn(
                name: "StartYear",
                table: "AcademicYear");

            migrationBuilder.DropColumn(
                name: "SubCourseId",
                table: "AcademicYear");

            migrationBuilder.AddColumn<int>(
                name: "Acedemic_Year",
                table: "AcademicYear",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Batch_Name",
                table: "AcademicYear",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Course_Id",
                table: "AcademicYear",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_Date",
                table: "AcademicYear",
                nullable: true);
        }
    }
}
