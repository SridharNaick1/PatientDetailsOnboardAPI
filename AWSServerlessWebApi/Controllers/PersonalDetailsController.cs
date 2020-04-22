using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;

namespace AWSServerlessWebApi.Controllers
{
    [Route("v1/personaldetails")]
    [ApiController]
    public class PersonalDetailsController : ControllerBase
    {

        private readonly Services.IPatientDetailsService PatientDetailsService;
        private readonly Services.IPatientEmploymentService PatientEmploymentService;
        private readonly Services.IPatientLocationService PatientLocationService;



        //public PersonalDetailsController(IPatientDetailsService patientDetailsService)
        //{
        //    PatientDetailsService = patientDetailsService;
        //}
        public PersonalDetailsController(IPatientEmploymentService patientEmploymentService, IPatientDetailsService patientDetailsService, IPatientLocationService patientLocationService)
        {
            PatientEmploymentService = patientEmploymentService;
            PatientDetailsService = patientDetailsService;
            PatientLocationService = patientLocationService;
        }

        [HttpGet]
        public IActionResult PatientDetails()
        {
            List<string> OutPut = new List<string>();
            //Dictionary<string, string> dict = new Dictionary<string, string>();

            // string connectionString = "Server = demosql001.cc4mi4fhf4fo.ap-southeast-2.rds.amazonaws.com; Database = WHADemo; User Id = whadevfe; Password = 4MeW3%T7JxMA; ";
            //string connectionString = "SELECT TOP (1000) [PersonID],[LastName],[FirstName],[Address],[City] FROM [testdatabase].[dbo].[Persons]";
            //string connectionString = "Data Source=DESKTOP-SK0EJ1N;Initial Catalog=testdatabase;Integrated Security=True";
            //var xxx = ConfigurationManager.ConnectionStrings["DefaultConnectString"];
            //string myDb1ConnectionString = _configuration.GetConnectionString("myDb1");
            var appSettingsJson = AppSettingsJson.GetAppSettings();
            var connectionString = appSettingsJson["DefaultConnectString"];
            //string connectionString = "dfa";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            //SqlCommand com = new SqlCommand("select * from dbo.POBPatient where POBPatientID = 1;", conn);
            SqlCommand com = new SqlCommand("select * from dbo.Persons;", conn);
            var Returned = com.ExecuteReader();

            while (Returned.Read())
            {
                for (int i = 0; i < Returned.FieldCount; i++)
                {
                    OutPut.Add(Returned.GetName(i));

                    // columns.Add(Returned.GetName(i));
                }

                //OutPut.Add(Returned.GetString(3));
            }
            conn.Close();

            var column = new PatientEmpolymentHistory();
            //column.ColumnNames = OutPut;

            return Ok(OutPut);
        }



        [HttpPost]
        //[EnableCors("MyPolicy")]
        public IActionResult AddPatientDetailsToDb([FromBody] rawdata rawdata)
        {
            var P_Details = new PatientDetailModel();
            P_Details.POBPatientID = rawdata.POBPatientID;
            P_Details.PatientID = rawdata.PatientID;
            P_Details.FirstName = rawdata.FirstName;
            P_Details.LastName = rawdata.LastName;
            P_Details.MiddleNames = rawdata.MiddleNames;
            P_Details.Email = rawdata.Email;
            P_Details.Title = rawdata.Title;
            P_Details.Gender = rawdata.Gender;
            P_Details.DateOfBirth = rawdata.DateOfBirth;
            P_Details.Height = rawdata.Height;
            P_Details.WeightKg = rawdata.WeightKg;
            P_Details.BMI = rawdata.BMI;
            P_Details.Handedness = rawdata.Handedness;
            P_Details.Mobile = rawdata.Mobile;
            P_Details.StreetAddressID = rawdata.StreetAddressID;
            P_Details.FamilyDoctor = rawdata.FamilyDoctor;
            P_Details.LastVisit = rawdata.LastVisit;
            P_Details.WhyLastVisit = rawdata.WhyLastVisit;
            P_Details.CountryID = rawdata.CountryID;
            P_Details.CreateUserID = rawdata.CreateUserID;
            P_Details.KnownAsCode = rawdata.KnownAsCode;
            P_Details.FreeSearch = rawdata.FreeSearch;
            P_Details.OnboardCode = rawdata.OnboardCode;
            P_Details.SelectedEntityType = rawdata.SelectedEntityType;
            P_Details.PreviousWorkCompClaim = rawdata.PreviousWorkCompClaim;
            P_Details.PreviousWorkCompClaimDetails = rawdata.PreviousWorkCompClaimDetails;

            PatientDetailsService.AddPatientDetailsToDb(P_Details);


            var P_Emp_Details = new PatientEmploymentModel();
            P_Emp_Details.POBPatientEmploymentID = rawdata.POBPatientEmploymentID;
            P_Emp_Details.POBPatientID = rawdata.POBPatientID;
            P_Emp_Details.CreateDate = rawdata.CreateDate;
            P_Emp_Details.CreateUserID = rawdata.CreateUserID;
            P_Emp_Details.CurrentPosition = rawdata.CurrentPosition;
            P_Emp_Details.EmpStartDate = rawdata.EmpStartDate;
            P_Emp_Details.EmpDepartment = rawdata.EmpDepartment;
            P_Emp_Details.CurrentDutiesID = rawdata.CurrentDutiesID;
            P_Emp_Details.EmploymentStatusID = rawdata.EmploymentStatusID;
            P_Emp_Details.OccupationID = rawdata.OccupationID;

            PatientEmploymentService.AddPatienEmploymentToDb(P_Emp_Details);



            var P_Loc_Details = new PatientLocationModel();

            P_Loc_Details.AddressID = rawdata.AddressID;
            P_Loc_Details.Line1 = rawdata.Line1;
            P_Loc_Details.Line2 = rawdata.Line2;
            P_Loc_Details.Suburb = rawdata.Suburb;
            P_Loc_Details.StateID = rawdata.StateID;
            P_Loc_Details.PostCode = rawdata.PostCode;
            P_Loc_Details.AddressRegion = rawdata.AddressRegion;
            P_Loc_Details.LogUserID = rawdata.LogUserID;

            PatientLocationService.AddLocationToDB(P_Loc_Details);



            return Ok();
        }


    }


}