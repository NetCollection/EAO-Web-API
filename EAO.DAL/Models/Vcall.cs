using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class Vcall
{
    public long Id { get; set; }

    public long CallerId { get; set; }

    public string Type { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string CallerName { get; set; } = null!;

    public string CallerPhone { get; set; } = null!;

    public bool? IsSpam { get; set; }

    public int? TicketsCount { get; set; }

    public string? LastCallStatus { get; set; }
}
