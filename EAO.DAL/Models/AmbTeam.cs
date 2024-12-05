using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class AmbTeam
{
    public long Id { get; set; }

    public int? EaoId { get; set; }

    public string FullName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Phone2 { get; set; }

    public int JobRole { get; set; }

    public int GovId { get; set; }

    public int DefaultCar { get; set; }

    public int? DefaultShift { get; set; }

    public int DayCar { get; set; }

    public int? DayShift { get; set; }

    public bool Active { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool DefMorningShift { get; set; }

    public bool DefEveningShift { get; set; }

    public bool DayMorningShift { get; set; }

    public bool DayEveningShift { get; set; }
}
