
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAO.BL.DTOs.Question
{
    public class QuestionDto
    {
        public long Id { get; set; }

        public string Question1 { get; set; } = null!;

        public int ApplicableFor { get; set; }

        public string Format { get; set; } = null!;

        public string? Instructions { get; set; }

        public bool? AllowMultiple { get; set; }

        public string? Condition { get; set; }
    }
}
