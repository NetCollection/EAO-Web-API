using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EAO.BL.DTOs.Request
{
    public class AddRequestDto
    {
        //Caller
        public string CallerName { get; set; }
        public string CallerPhone { get; set; }
        public string CallerOtherPhone { get; set; }

        //Patients
        public int GenderId { get; set; }
        public int Age { get; set; }
        public int NationalityId { get; set; }
        public string HospitalName1 { get; set; }
        public string HospitalName2 { get; set; }
        public string HospitalName3 { get; set; }
        public string InjuryType { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string NationalID { get; set; }
        public string PassportID { get; set; }
        public string PatientPhone { get; set; }


        //Tickets
        public int GovernorateId { get; set; }
        public int AreaId { get; set; }
        public string Address { get; set; }
        public int SubType { get; set; }


    }
}
