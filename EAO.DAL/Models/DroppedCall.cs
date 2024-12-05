using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class DroppedCall
{
    public long Id { get; set; }

    public long CallerId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }
}
