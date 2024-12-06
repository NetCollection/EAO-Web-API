using EAO.BL.DTOs.Caller;
using EAO.BL.DTOs.Validation;
using EAO.DAL.Models;
using System.Net.Sockets;
using static EAO.BL.Helpers.GeneralNames;

namespace EAO.BL.Services
{
    public class CallerService
    {
        private readonly EaoNsContext _context;
        public CallerService(EaoNsContext eaoNsContext)
        {
            _context = eaoNsContext;
        }


        //Add

        public ValidationMassageWithValueDto Add(AddCallerDto addCallerDto)
        {
            var caller = new Caller
            {
                CallerName = addCallerDto.CallerName,
                CallerPhone = addCallerDto.CallerPhone,
                CallerOtherPhones = addCallerDto.CallerOtherPhone,
                CreatedAt = DateTime.Now,
                CreatedBy = MobileApp,
            };

            _context.Callers.Add(caller);
            _context.SaveChanges();


            return new ValidationMassageWithValueDto
            {
                HasValidation = false,
                Massage = "Caller Saved Successfully",
                ValueId = (int)caller.Id
            };
        }

    }
}
