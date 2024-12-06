using EAO.BL.DTOs.Request;
using EAO.BL.DTOs.Ticket;
using EAO.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace EAO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            if (addRequestDto == null) return BadRequest("Ticket data is required.");

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
