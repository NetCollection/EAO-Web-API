using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class User
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string ArName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public int RoleId { get; set; }

    public int GovId { get; set; }

    public bool? Active { get; set; }

    public int? RegionId { get; set; }
}
