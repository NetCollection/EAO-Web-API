using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class IncidentCategory
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Parent { get; set; }

    public int? Priority { get; set; }

    public bool? Active { get; set; }
}
