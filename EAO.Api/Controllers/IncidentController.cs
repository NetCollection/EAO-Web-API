﻿using EAO.BL.Services;
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


        [HttpGet]
        [Route("GetSubType")]
        [Produces("application/json")]
        public IActionResult GetSubType()
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
