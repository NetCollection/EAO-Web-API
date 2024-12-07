using EAO.BL.DTOs;
using EAO.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EAO.BL.Services
{
    public class GovernorateService
    {
        private readonly EaoNsContext _context;
        public GovernorateService(EaoNsContext eaoNsContext)
        {
            _context = eaoNsContext;
        }

        //Get
        public IQueryable<SelectItemDto> GetGovernorateList()
        {
            var list = _context.Lookups.AsNoTracking()
                .Where(e=>e.Type== "Governorate")
                .Select(e => new SelectItemDto
                {
                    Id = (int)e.Id,
                    Name = e.Name,
                });

            return list;
        }



        //Bool
        public bool IsGovernorateValid(int id)
        {
            var isValid = GetGovernorateList().AsEnumerable().Any(e => e.Id == id);
            return isValid;
        }



    }
}
