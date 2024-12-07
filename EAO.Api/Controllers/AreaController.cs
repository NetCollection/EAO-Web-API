using EAO.BL.Services;
using Microsoft.AspNetCore.Authorization;
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
            try
            {
                var list = _areaService.GetAreaList(GovernorateId).ToList();

                return Ok(list);

            }
            catch (Exception ex)
            {
                return Problem();
            }
        }


    }
}
