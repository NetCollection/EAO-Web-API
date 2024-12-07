using EAO.BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [Route("GetNationality")]
        [Produces("application/json")]
        public IActionResult GetNationality()
        {
            try
            {
                var list = _patientService.GetNationalityList();

                return Ok(list);
            }
            catch (Exception ex) 
            {
                return Problem();
            }

        }


        [HttpGet]
        [Route("GetGender")]
        [Produces("application/json")]
        public IActionResult GetGender()
        {
            try
            {
                var list = _patientService.GetGenderList();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }




    }
}
