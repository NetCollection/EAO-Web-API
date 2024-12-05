using EAO.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAO.BL.Services
{
    public class QuestionService
    {
        private readonly EaoNsContext _context;
        public QuestionService(EaoNsContext eaoNsContext)
        {
            _context = eaoNsContext;
        }

        public IQueryable<Question> GetQuestionList() 
        {
            var list = _context.Questions.AsNoTracking()
                .Select(e => new Question
            {
                Id = e.Id, 
                Question1 = e.Question1,
                AllowMultiple = e.AllowMultiple,
                ApplicableFor = e.ApplicableFor,
                Condition = e.Condition,
                DeletedAt = e.DeletedAt,
                Format = e.Format,
                Instructions = e.Instructions,
            });
            return list;    
        }

    }
}
