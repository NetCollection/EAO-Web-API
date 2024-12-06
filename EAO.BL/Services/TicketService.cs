using EAO.BL.DTOs.Ticket;
using static EAO.BL.Helpers.GeneralNames;
using EAO.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAO.BL.DTOs.Validation;

namespace EAO.BL.Services
{
    public class TicketService
    {
        private readonly EaoNsContext _context;
        public TicketService(EaoNsContext eaoNsContext)
        {
            _context = eaoNsContext;
        }




        //Add

        public ValidationMassageWithValueDto Add(AddTicketDto addTicketDto)
        {

            var ticket = new Ticket
            {
                CallSource = 11397,//lookup 1000
                Area = addTicketDto.AreaId,
                Governorate = addTicketDto.GovernorateId,
                CaseType = 6,
                CaseSubType = addTicketDto.SubType,
                Priority = 88,
                IncidentLocation = addTicketDto.Address,
                CallerId = addTicketDto.CallerId,
                CreatedBy = MobileApp,
                CreatedAt = DateTime.Now,
            };

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return new ValidationMassageWithValueDto
            {
                HasValidation = false,
                Massage = "Ticket Saved Successfully",
                ValueId = (int)ticket.Id
            };
        }


    }
}
