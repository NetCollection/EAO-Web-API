using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EAO.BL.DTOs.Request
{
    public class AddRequestDto
    {
        //Caller
       // [Required(ErrorMessage = "Caller Name is required")]
        public string CallerName { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Caller Phone Name is required")]
        public string CallerPhone { get; set; } = string.Empty;
        public string CallerOtherPhone { get; set; } = string.Empty;


        //Patients
        public int GenderId { get; set; }
        public int Age { get; set; }

   //     [Required(ErrorMessage = "Nationality Id is required")]
        public int NationalityId { get; set; }

        public string HospitalName1 { get; set; } = string.Empty;
        public string HospitalName2 { get; set; } = string.Empty;
        public string HospitalName3 { get; set; } = string.Empty;
        public string InjuryType { get; set; } = string.Empty;

   //     [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; } = string.Empty;

 //       [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = string.Empty;

        public string NationalID { get; set; } = string.Empty;
        public string PassportID { get; set; } = string.Empty;
        public string PatientPhone { get; set; } = string.Empty;


        //Tickets
   //     [Required(ErrorMessage = "Governorate Id is required")]
        public int GovernorateId { get; set; }

        public int AreaId { get; set; }
        public string Address { get; set; } = string.Empty;

 //       [Required(ErrorMessage = "Sub Type Id is required")]
        public int SubType { get; set; }


        public string CreatedBy { get; set; } = string.Empty;

    }
}
