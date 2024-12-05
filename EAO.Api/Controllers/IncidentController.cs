using EAO.BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IncidentService _incidentService;

        public IncidentController(IncidentService incident)
        {
            _incidentService = incident;
        }


        [HttpGet]
        [Route("GetSubType")]
        [Produces("application/json")]
        public IActionResult GetSubType()
        {
            var list= _incidentService.GetSubType();

            return Ok(list);
        }


    }
}
