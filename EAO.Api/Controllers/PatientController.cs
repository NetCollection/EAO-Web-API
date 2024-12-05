using EAO.BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientController(GovernorateService patientService)
        {
            _patientService = _patientService;
        }

        [HttpGet]
        [Route("GetGender")]
        [Produces("application/json")]
        public IActionResult GetGender()
        {
            var list = _patientService.GetGenderList();

            return Ok(list);
        }
    }
}
