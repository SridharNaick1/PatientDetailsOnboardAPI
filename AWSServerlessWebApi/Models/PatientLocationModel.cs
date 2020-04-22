using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Models
{
    public class PatientLocationModel
    {
        public int AddressID { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Suburb { get; set; }
        public int StateID { get; set; }
        public string PostCode { get; set; }
        public int AddressRegion { get; set; }
        public int LogUserID { get; set; }
    }
}
