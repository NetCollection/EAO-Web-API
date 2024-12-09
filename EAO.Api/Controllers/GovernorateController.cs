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
        private readonly AreaService _areaService;

        public GovernorateController(GovernorateService governorateService, AreaService areaService)
        {
            _governorateService = governorateService;
            _areaService = areaService;
        }


        /// <summary>
        /// This endpoint is used to Get governorates list.
        /// </summary>
        /// <returns>governorates list</returns>
        /// <remarks>
        /// 
        /// Sample requset
        /// Get Api/Governorate/GetGovernorates
        /// 
        /// </remarks>
        /// <response code="200"> Return list of governorates includes id and name. </response>
        /// <response code="401">Returns Unauthorized: Authentication failed.</response>

        [HttpGet]
        [Route("GetGovernorates")]
        [Produces("application/json")]
        public IActionResult GetGovernorates()
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

        /// <summary>
        /// This endpoint is used to Get Area list.
        /// </summary>
        /// <param name="GovernorateId"></param>
        /// <returns>area list </returns>
        /// <remarks>
        /// 
        /// Sample requset
        /// Get Api/Governorate/GetAreas
        /// 
        /// </remarks>
        /// <response code="200"> Return list of areas includes id and name. </response>
        /// <response code="401">Returns Unauthorized: Authentication failed.</response>

        [HttpGet]
        [Route("GetAreas")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetAreas(int GovernorateId)
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
