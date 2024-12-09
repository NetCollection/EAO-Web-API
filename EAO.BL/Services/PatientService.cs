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
                CreatedAt = DateTime.Now,
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
            var value = GetGenderList().Any(e => e.Id == id);
            return value;
        }

        public bool IsNationalityValid(int id)
        {
            var value = GetNationalityList().Any(e => e.Id == id);
            return value;
        }

        public bool IsEgyptian(int nationalityId)
        {
            var value = GetNationalityList().Any(e => e.Id == nationalityId && e.Name == "مصر");
            return value;

        }

    }
}
