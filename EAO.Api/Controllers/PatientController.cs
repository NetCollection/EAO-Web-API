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


        /// <summary>
        /// This endpoint is used to get nationalities list.
        /// </summary>
        /// <returns>nationalities list</returns>
        /// <remarks>
        /// 
        /// Sample requset
        /// Get Api/Patient/GetNationality
        /// 
        /// </remarks>
        /// <response code="200"> Return list of IDs and names of Nationalities </response>
        /// <response code="401">Returns Unauthorized: Authentication failed.</response>

        [HttpGet]
        [Route("GetNationality")]
        [Produces("application/json")]
        public IActionResult GetNationalities()
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

        /// <summary>
        /// This endpoint is used to get gender IDs.
        /// </summary>
        /// <returns>gender IDs</returns>
        /// <remarks>
        /// 
        /// Sample requset
        /// Get Api/Patient/GetGender
        /// 
        /// </remarks>
        /// <response code="200"> Return list of gender IDs </response>
        /// <response code="401">Returns Unauthorized: Authentication failed.</response>

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
