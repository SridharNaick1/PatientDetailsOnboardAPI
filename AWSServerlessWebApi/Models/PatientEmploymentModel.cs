using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Models
{
    public class PatientEmploymentModel
    {
        public int POBPatientEmploymentID { get; set; }
        public int POBPatientID { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserID { get; set; }
        public string CurrentPosition { get; set; }
        public DateTime EmpStartDate { get; set; }
        public string EmpDepartment { get; set; }
        public int CurrentDutiesID { get; set; }
        public int EmploymentStatusID { get; set; }
        public int OccupationID { get; set; }

    }
}
