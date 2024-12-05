using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class Call
{
    public long Id { get; set; }

    public long CallerId { get; set; }

    public string Type { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
