using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class AmbCar
{
    public long Id { get; set; }

    public string CarCode { get; set; } = null!;

    public int GovId { get; set; }

    public bool Active { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsSoothed { get; set; }
}
