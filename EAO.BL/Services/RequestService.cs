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
using EAO.BL.DTOs.Patient;

namespace EAO.BL.Services
{
    public class RequestService
    {
        private readonly EaoNsContext _context;
        private readonly TicketService _ticketService;
        private readonly CallerService _callerService;
        private readonly PatientService _patientService;

        public RequestService(EaoNsContext eaoNsContext, TicketService ticketService, CallerService callerService, PatientService patientService)
        {
            _context = eaoNsContext;
            _ticketService = ticketService;
            _callerService = callerService;
            _patientService = patientService;
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

            var callerid = _callerService.Add(callerDto,  createdby).ValueId;

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

            //Add Patient

            var addPatientDto = new AddPatientDto
            {
                Age = addRequestDto.Age,
                FirstName = addRequestDto.FirstName,
                FullName = addRequestDto.FullName,
                GenderId = addRequestDto.GenderId,
                HospitalName1 = addRequestDto.HospitalName1,
                HospitalName2 = addRequestDto.HospitalName2,
                HospitalName3 = addRequestDto.HospitalName3,
                InjuryType = addRequestDto.InjuryType,
                NationalID = addRequestDto.NationalID,
                PassportID = addRequestDto.PassportID,
                NationalityId= addRequestDto.NationalityId,
                PatientPhone = addRequestDto.PatientPhone,
                TicketId= ticketId,
            };

            _patientService.Add(addPatientDto);


            return new ValidationMassageWithValueDto
            {
                HasValidation = false,
                Massage = "Request Saved Successfully",
                ValueId = (int)ticketId
            };

        }



    }
}
