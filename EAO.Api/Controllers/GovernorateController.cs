using EAO.BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernorateController : ControllerBase
    {
        private readonly GovernorateService _governorateService;

        public GovernorateController(GovernorateService governorateService)
        {
            _governorateService = governorateService;
        }

        [HttpGet]
        [Route("Governorates")]
        [Produces("application/json")]
        public IActionResult Governorates()
        {
            var list = _governorateService.GetGovernorates().ToList();

            return Ok(list);
        }
    }
}
