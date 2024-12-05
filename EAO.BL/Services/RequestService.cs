using EAO.BL.DTOs.Caller;
using static EAO.BL.Helpers.GeneralNames;
using EAO.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAO.BL.DTOs.Ticket;
using EAO.BL.DTOs.Request;
using EAO.BL.DTOs.Validation;
using System.Net.Sockets;

namespace EAO.BL.Services
{
    public class RequestService
    {
        private readonly EaoNsContext _context;
        private readonly TicketService _ticketService;
        private readonly CallerService _callerService;
        public RequestService(EaoNsContext eaoNsContext, TicketService ticketService, CallerService callerService)
        {
            _context = eaoNsContext;
            _ticketService = ticketService;
            _callerService = callerService;
        }







        public ValidationMassageWithValueDto Add(AddRequestDto addRequestDto)
        {
            //Add Caller

            var callerDto = new AddCallerDto
            {
                CallerName = addRequestDto.CallerName,
                CallerPhone = addRequestDto.CallerPhone,
                CallerOtherPhone = addRequestDto.CallerOtherPhone,
            };

            var callerid = _callerService.Add(callerDto).ValueId;

            //Add Ticket

            var addTicketDto = new AddTicketDto
            {
                AreaId = addRequestDto.AreaId,
                GovernorateId = addRequestDto.GovernorateId,
                SubType = addRequestDto.SubType,
                Address = addRequestDto.Address,
                CallerId = callerid,
            };
            var ticketId = _ticketService.Add(addTicketDto).ValueId;

            return new ValidationMassageWithValueDto
            {
                HasValidation = false,
                Massage = "-- Saved Successfully",
               // ValueId = (int)ticket.Id
            };
        }



    }
}
