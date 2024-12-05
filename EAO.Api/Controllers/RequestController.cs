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


        //[HttpPost]
        //[Route("SaveTicket")]
        //[Produces("application/json")]
        //public IActionResult SaveTicket(AddTicketDto addTicketDto)
        //{
        //    if (addTicketDto == null) return BadRequest("Ticket data is required.");

        //    var response = _requestService.Add(addTicketDto);

        //    if (!response.HasValidation)
        //    {
        //        return Ok(response.ValueId);
        //    }
        //    else
        //    {
        //        return BadRequest(response.Massage);
        //    }
        //}





    }
}
