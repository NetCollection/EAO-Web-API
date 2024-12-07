using EAO.BL.DTOs;
using EAO.BL.DTOs.Patient;
using EAO.BL.DTOs.Ticket;
using EAO.BL.DTOs.Validation;
using EAO.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAO.BL.Services
{
    public class PatientService
    {
        private readonly EaoNsContext _context;
        public PatientService(EaoNsContext eaoNsContext)
        {
            _context = eaoNsContext;
        }

        //Get

        public IEnumerable<SelectItemDto> GetGenderList()
        {
            var list = _context.Lookups
                .Where(e => e.Type == "gender"
                && e.Active == true)
                .Select(e=>new SelectItemDto
                {
                    Id=(int)e.Id,
                    Name=e.Name,
                });

            return list;
        }


        public IEnumerable<SelectItemDto> GetNationalityList()
        {
            var list = _context.Lookups
                .Where(e => e.Type == "Nationality"
                && e.Active == true)
                .Select(e => new SelectItemDto
                {
                    Id = (int)e.Id,
                    Name = e.Name,
                });

            return list;
        }

        //Add

        public ValidationMassageWithValueDto Add(AddPatientDto addPatientDto)
        {
            var ticket = new Patient
            {
               Phone =addPatientDto.PatientPhone,
                FirstName = addPatientDto.FirstName,
                FullName = addPatientDto.FullName,
                Hospital1 = addPatientDto.HospitalName1,
                Hospital2 = addPatientDto.HospitalName2,
                Hospital3 = addPatientDto.HospitalName3,
                Age = addPatientDto.Age,
                Nationality = addPatientDto.NationalityId,
                Passport=addPatientDto.PassportID,
                TypeOfInjury = addPatientDto.InjuryType,
                Gender = addPatientDto.GenderId,
                NationalityId = addPatientDto.NationalID,

                TicketId = addPatientDto.TicketId,  
                CreatedBy= addPatientDto.CreatedBy
            };

            _context.Patients.Add(ticket);
            _context.SaveChanges();

            return new ValidationMassageWithValueDto
            {
                HasValidation = false,
                Massage = "Patient Saved Successfully",
                ValueId = (int)ticket.Id
            };
        }


        //Bool

        public bool IsGenderValid(int id)
        {
            var isValid = GetGenderList().Any(e => e.Id == id);
            return isValid;
        }

        public bool IsNationalityValid(int id)
        {
            var isValid = GetNationalityList().Any(e => e.Id == id);
            return isValid;
        }

    }
}
