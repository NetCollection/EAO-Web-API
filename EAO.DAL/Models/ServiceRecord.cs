using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class ServiceRecord
{
    public long Id { get; set; }

    public long AmbCarId { get; set; }

    public int? CarCode { get; set; }

    public long TicketId { get; set; }

    public DateTime Start { get; set; }

    public DateTime? End { get; set; }

    public int DriverId { get; set; }

    public int ParamedicId { get; set; }

    public long? CounterStart { get; set; }

    public long? CounterEnd { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
