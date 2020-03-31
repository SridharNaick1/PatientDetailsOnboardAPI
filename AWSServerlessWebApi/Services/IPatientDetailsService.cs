using AWSServerlessWebApi.Models;
using System.Collections.Generic;

namespace AWSServerlessWebApi.Services
{
    public interface IPatientDetailsService
    {
        Dictionary<string, int> GetItemsFromPatientDb();
        void AddPatientDetailsToDb(PatientDetailModel p_Details);
    }
}