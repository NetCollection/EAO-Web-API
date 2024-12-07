using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAO.BL.DTOs.Patient
{
    public class AddPatientDto
    {
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

        public int TicketId { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

    }
}
