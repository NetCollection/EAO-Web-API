using EAO.BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AreaController : ControllerBase
    {
        private readonly AreaService _areaService;

        public AreaController(AreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        [Route("Governorates")]
        [Produces("application/json")]
        public IActionResult Governorates(int GovernorateId)
        {
            var list = _areaService.GetArea(GovernorateId).ToList();

            return Ok(list);
        }


    }
}
