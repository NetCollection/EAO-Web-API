using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAO.BL.DTOs.Incident
{
    public class IncidentDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public int? Parent { get; set; }

        public int? Priority { get; set; }

        public bool? Active { get; set; }

    }
}
