using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class Alert
{
    public long Id { get; set; }

    public string? Alert1 { get; set; }

    public string? ToParams { get; set; }

    public string ShallReadBy { get; set; } = null!;

    public int Priority { get; set; }

    public DateTime? ExpiredOn { get; set; }

    public bool? Read { get; set; }

    public DateTime CreatedAt { get; set; }
}
