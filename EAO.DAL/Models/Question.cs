using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class Question
{
    public long Id { get; set; }

    public string Question1 { get; set; } = null!;

    public int ApplicableFor { get; set; }

    public string Format { get; set; } = null!;

    public string? Instructions { get; set; }

    public bool? AllowMultiple { get; set; }

    public string? Condition { get; set; }

    public DateTime? DeletedAt { get; set; }
}
