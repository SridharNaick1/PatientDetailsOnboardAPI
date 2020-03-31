using AWSServerlessWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace AWSServerlessWebApi.Services
{
    public class PatientDetailsService : IPatientDetailsService
    {   

        private readonly Dictionary<string, int> PersonalDetailsDict = new Dictionary<string, int>();
        public Dictionary<string, int> GetItemsFromPatientDb()
        {
            return PersonalDetailsDict;
        }

        public void AddPatientDetailsToDb(PatientDetailModel p_Details)
        {


            SqlConnection conn = new SqlConnection("Server = demosql001.cc4mi4fhf4fo.ap-southeast-2.rds.amazonaws.com; Database = WHADemo; User Id = whadevfe; Password = 4MeW3%T7JxMA;");
            SqlCommand cmd = new SqlCommand("POBPatientSave", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlCommandBuilder.DeriveParameters(cmd);
            foreach (SqlParameter p in cmd.Parameters)
            {
                PersonalDetailsDict.Add(p.ParameterName, p_Details.CountryID);
                Console.WriteLine(p.ParameterName);
            }

           


        }
    }
}
 