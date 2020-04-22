using AWSServerlessWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace AWSServerlessWebApi.Services
{
    public class PatientEmploymentService: IPatientEmploymentService
    {
        public void AddPatienEmploymentToDb(PatientEmploymentModel P_Emp_Details)
        {
            return;
            SqlConnection conn = new SqlConnection("Server = demosql001.cc4mi4fhf4fo.ap-southeast-2.rds.amazonaws.com; Database = WHADemo; User Id = whadevfe; Password = 4MeW3%T7JxMA;");
            SqlCommand cmd = new SqlCommand("POBPatientSave", conn);

            ////string connectionString = "Data Source=DESKTOP-SK0EJ1N;Initial Catalog=testdatabase;Integrated Security=True";
            //SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            //SqlCommand cmd = new SqlCommand("INSERT INTO Persons;", conn);

            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlCommandBuilder.DeriveParameters(cmd);
            //foreach (SqlParameter p in cmd.Parameters)
            //{
            //    PersonalDetailsDict.Add(p.ParameterName, p_Details.CountryID);
            //    Console.WriteLine(p.ParameterName);

            //}
        }

        public Dictionary<string, int> GetItemsFromPatientDb()
        {
            throw new NotImplementedException();
        }
    }
}
