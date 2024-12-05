using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class SoothingHistory
{
    public long Id { get; set; }

    public DateOnly SoothingDate { get; set; }

    public string RawData { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
