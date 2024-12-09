using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EAO.BL.DTOs.Request
{
    public class AddRequestDto
    {
        // Caller Information


        [SwaggerSchema(Description = "Gets or sets the name of the caller. This field is required ")]
        [Required(ErrorMessage = "Caller Name is required")]
        public string CallerName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the caller.
        /// This field is required.
        /// </summary>
        [Required(ErrorMessage = "Caller Phone is required")]
        public string CallerPhone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets an additional phone number for the caller (optional).
        /// </summary>
        public string CallerOtherPhone { get; set; } = string.Empty;


        // Patient Information
        /// <summary>
        /// Gets or sets the gender ID of the patient.
        /// This field is required.
        /// </summary>
        [Required(ErrorMessage = "Gender Id is required")]
        public int GenderId { get; set; }

        /// <summary>
        /// Gets or sets the age of the patient (optional).
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the nationality ID of the patient.
        /// This field is required.
        /// </summary>
        [Required(ErrorMessage = "Nationality Id is required")]
        public int NationalityId { get; set; }

        /// <summary>
        /// Gets or sets the name of the hospital associated with the patient (optional).
        /// </summary>
        public string HospitalName1 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the second hospital (optional).
        /// </summary>
        public string HospitalName2 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the third hospital (optional).
        /// </summary>
        public string HospitalName3 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type of injury the patient has (optional).
        /// </summary>
        public string InjuryType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the full name of the patient.
        /// This field is required.
        /// </summary>
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the first name of the patient.
        /// This field is required.
        /// </summary>
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the national ID of the patient (optional).
        /// </summary>
        public string NationalId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the passport ID of the patient (optional).
        /// </summary>
        public string PassportId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the patient (optional).
        /// </summary>
        public string PatientPhone { get; set; } = string.Empty;


        // Ticket Information
        /// <summary>
        /// Gets or sets the governorate ID associated with the request.
        /// This field is required.
        /// </summary>
        [Required(ErrorMessage = "Governorate is required")]
        public int GovernorateId { get; set; }

        /// <summary>
        /// Gets or sets the area ID associated with the request.
        /// This field is required.
        /// </summary>
        [Required(ErrorMessage = "Area is required")]
        public int AreaId { get; set; }

        /// <summary>
        /// Gets or sets the request address (optional).
        /// </summary>
        public string RequestAddress { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the sub-type of the request.
        /// This field is required.
        /// </summary>
        [Required(ErrorMessage = "Sub Type is required")]
        public int RequestSubType { get; set; }


        // Created By Information
        /// <summary>
        /// Gets or sets the name or ID of the user who created the request.
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;
    }
}
