using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public Nullable<int> Country { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<int> City { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> SSC_Marks { get; set; }
        public Nullable<decimal> HSC_Marks { get; set; }
        public Nullable<decimal> Graduation { get; set; }
        public Nullable<decimal> MAT_CAT { get; set; }
        public string Email { get; set; }
        public string App_Status { get; set; }
        public string Del_Status { get; set; }
        public Nullable<int> CenterId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> Mentorid { get; set; }
        public string IsAknowledgemail { get; set; }
        public byte[] EncryptedMobileNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Pincode { get; set; }
        public Nullable<bool> PhysicallyHandicapped { get; set; }
        public string SpecializationMajor { get; set; }
        public string Specialization_Minor { get; set; }
        public Nullable<int> Semester { get; set; }
        public string PRNNo { get; set; }
        public string FCRollNo { get; set; }
        public string WhatsappMobileNo { get; set; }
        public string PIBMEmailId { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<System.DateTime> DOJ { get; set; }
        public string BloodGroup { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string Category { get; set; }
        public Nullable<int> Course { get; set; }
        public Nullable<int> Batch { get; set; }
        public string RollNo { get; set; }
        public string Photo { get; set; }
        public Nullable<int> User_Id { get; set; }
        public Nullable<int> Relative { get; set; }
        public Nullable<int> Entrance_Exam { get; set; }
        public Nullable<int> Education { get; set; }
        public Nullable<int> Father_Address { get; set; }
        public Nullable<int> LocalGuardian { get; set; }
        public Nullable<int> Gaps_In_Education { get; set; }
        public Nullable<int> Academics_Mentor { get; set; }
        public string Academics_Mentor_Designation { get; set; }
        public System.DateTime Create_date { get; set; }
        public Nullable<int> Section { get; set; }
        public string IP_Address { get; set; }
        public string Valid_Code { get; set; }
    }
}
