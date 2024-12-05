using EAO.BL.DTOs;
using EAO.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EAO.BL.Services
{
    public class AreaService
    {
        private readonly EaoNsContext _context;
        public AreaService(EaoNsContext eaoNsContext)
        {
            _context = eaoNsContext;
        }


        public IQueryable<SelectItemDto> GetArea(int GovernorateId)
        {
            var list = _context.Lookups.AsNoTracking()
                .Where(e => e.Parent == GovernorateId
                && e.Type == "area")
                .Select(e => new SelectItemDto
                {
                    Id = (int)e.Id,
                    Name = e.Name,
                });

            return list;
        }


    }
}
