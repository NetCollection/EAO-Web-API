using EAO.BL.DTOs.Request;
using EAO.BL.DTOs.Ticket;
using EAO.BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EAO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class RequestController : ControllerBase
    {
        private readonly RequestService _requestService;
        public RequestController(TicketService ticketService, RequestService requestService)
        {
            _requestService = requestService;
        }


        [HttpPost]
        [Route("AddRequest")]
        [Produces("application/json")]
        public IActionResult AddRequest(AddRequestDto addRequestDto)
        {
            // get email 
            if (addRequestDto == null) return BadRequest("Ticket data is required.");
            Claim createdObj = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault();
            if(createdObj!=null)
            {
                addRequestDto.CreatedBy = createdObj.Value;
            }
            var response = _requestService.Add(addRequestDto);

            if (!response.HasValidation)
            {
                return Ok(new {requestId= response.ValueId });
            }
            else
            {
                return BadRequest(response.Massage);
            }
        }





    }
}
