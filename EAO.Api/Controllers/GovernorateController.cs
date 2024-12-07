using EAO.BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

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
            try
            {
                var list = _governorateService.GetGovernorateList().AsEnumerable();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return Problem();
            }

        }
    }
}
