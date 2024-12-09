using EAO.BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class IncidentController : ControllerBase
    {
        private readonly IncidentService _incidentService;

        public IncidentController(IncidentService incident)
        {
            _incidentService = incident;
        }

        /// <summary>
        /// This endpoint is used to Get Sub Type list.
        /// </summary>
        /// <returns> Sub Type list</returns>
        /// <remarks>
        /// 
        /// Sample requset
        /// Get Api/Governorate/GetSubCaseTypes
        /// 
        /// </remarks>
        /// <response code="200"> Return list of IDs and names of sub-cases </response>
        /// <response code="401">Returns Unauthorized: Authentication failed.</response>

        [HttpGet]
        [Route("GetSubCaseTypes")]
        [Produces("application/json")]
        public IActionResult GetSubCaseTypes()
        {
            try
            {
                var list = _incidentService.GetSubTypeList();

                return Ok(list);

            }
            catch (Exception ex)
            {
                return Problem();
            }
        }


    }
}
