using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAO.BL.DTOs.Validation
{
    public class ValidationMassageWithValueDto: ValidationMassageDto
    {
        public int ValueId { get; set; }
    }
}
