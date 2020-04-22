using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Models
{
    public class rawdata
    {
        public int POBPatientID { get; set; }
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleNames { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public decimal WeightKg { get; set; }
        public decimal BMI { get; set; }
        public string Handedness { get; set; }
        public int Mobile { get; set; }
        public int StreetAddressID { get; set; }
        public string FamilyDoctor { get; set; }
        public DateTime LastVisit { get; set; }
        public string WhyLastVisit { get; set; }
        public int CountryID { get; set; }
        public int CreateUserID { get; set; }
        public string KnownAsCode { get; set; }
        public string FreeSearch { get; set; }
        public string OnboardCode { get; set; }
        public int SelectedEntityType { get; set; }
        public int PreviousWorkCompClaim { get; set; }
        public string PreviousWorkCompClaimDetails { get; set; }
        public int POBPatientEmploymentID { get; set; }
        public DateTime CreateDate { get; set; }
        public string CurrentPosition { get; set; }
        public DateTime EmpStartDate { get; set; }
        public string EmpDepartment { get; set; }
        public int CurrentDutiesID { get; set; }
        public int EmploymentStatusID { get; set; }
        public int OccupationID { get; set; }
        public int AddressID { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Suburb { get; set; }
        public int StateID { get; set; }
        public string PostCode { get; set; }
        public int AddressRegion { get; set; }
        public int LogUserID { get; set; }


        //public int POBPatientID { get; set; }
        //public int PatientID { get; set; }
        //public string Country { get; set; }
    }
}
