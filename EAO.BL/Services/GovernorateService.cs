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


        public IQueryable<SelectItemDto> GetGovernorates()
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

    }
}
