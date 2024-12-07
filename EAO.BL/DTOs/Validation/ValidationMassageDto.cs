using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAO.BL.DTOs.Validation
{
    public class ValidationMassageDto
    {
        public bool HasValidation { get; set; }=false;

        public string Massage { get; set; } = string.Empty;

    }
}
