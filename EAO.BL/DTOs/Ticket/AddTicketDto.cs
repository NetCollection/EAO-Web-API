﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAO.BL.DTOs.Ticket
{
    public class AddTicketDto
    {
        public int GovernorateId { get; set; }
        public int AreaId { get; set; }
        public string Address { get; set; }
        public int SubType { get; set; }
        public int CallerId { get; set; }
    }
}