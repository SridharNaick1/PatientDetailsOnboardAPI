using AWSServerlessWebApi.Models;
using System.Collections.Generic;


namespace AWSServerlessWebApi.Services
{

    public interface IPatientEmploymentService
    {
        //Dictionary<string, int> GetItemsFromPatientDb();

        void AddPatienEmploymentToDb(PatientEmploymentModel P_Emp_Details);

    }
}