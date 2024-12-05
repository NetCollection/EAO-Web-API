using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class CallersBackup
{
    public long Id { get; set; }

    public string CallerName { get; set; } = null!;

    public string CallerPhone { get; set; } = null!;

    public string? CallerOtherPhones { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsSpam { get; set; }

    public string? CreatedBy { get; set; }
}
