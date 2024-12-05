using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class Region
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string NameAr { get; set; } = null!;
}
