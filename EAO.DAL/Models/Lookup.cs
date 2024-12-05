using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class Lookup
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int? Parent { get; set; }

    public bool? Active { get; set; }
}
