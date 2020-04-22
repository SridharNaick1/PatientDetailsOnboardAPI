using AWSServerlessWebApi.Models;



namespace AWSServerlessWebApi.Services
{
    public interface IPatientLocationService
    {
        void AddLocationToDB(PatientLocationModel P_Loc_Details);

    }
}