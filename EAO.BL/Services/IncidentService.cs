using EAO.BL.DTOs;
using EAO.BL.DTOs.Incident;
using EAO.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAO.BL.Services
{
    public class IncidentService
    {
        private readonly EaoNsContext _context;
        public IncidentService(EaoNsContext eaoNsContext)
        {
            _context = eaoNsContext;
        }


        public IQueryable<SelectItemDto> GetSubTypeList()
        {
            //get non-emergency case only = 6
            var list = _context.IncidentCategories.AsNoTracking()
                .Where(e=>e.Parent==6)
                .Select(e => new SelectItemDto
                {
                    Id = (int)e.Id,  
                    Name = e.Name,
                });

            return list;    
        }


        //Bool

        public bool IsSubTypeValid(int id)
        {
            var isValid = GetSubTypeList().AsEnumerable().Any(e => e.Id == id);
            return isValid;
        }




    }




}
