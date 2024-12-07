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


        public IQueryable<SelectItemDto> GetAreaList(int governorateId)
        {
            var list = _context.Lookups.AsNoTracking()
                .Where(e => e.Parent == governorateId
                && e.Type == "area")
                .Select(e => new SelectItemDto
                {
                    Id = (int)e.Id,
                    Name = e.Name,
                });

            return list;
        }

        //Bool
        public bool IsAreaValid(int areaId,int governorateId)
        {
            var isValid = GetAreaList(governorateId).AsEnumerable()
                .Any(e => e.Id == areaId);

            return isValid;
        }


    }
}
