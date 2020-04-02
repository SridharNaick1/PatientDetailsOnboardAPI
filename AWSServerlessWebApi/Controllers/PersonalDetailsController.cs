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

        public PersonalDetailsController(IPatientDetailsService patientDetailsService)
        {
            PatientDetailsService = patientDetailsService;
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
        [EnableCors("SiteCorsPolicy")]
        public IActionResult AddPatientDetailsToDb([FromBody] PatientDetailModel P_Details)
        {

            PatientDetailsService.AddPatientDetailsToDb(P_Details);

            return Ok();
        }


    }


}