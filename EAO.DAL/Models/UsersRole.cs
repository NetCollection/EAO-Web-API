using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class UsersRole
{
    public long Id { get; set; }

    public string Role { get; set; } = null!;

    public string? Permissions { get; set; }
}
