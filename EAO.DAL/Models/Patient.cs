using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class Patient
{
    public long Id { get; set; }

    public long TicketId { get; set; }

    public long? ServiceId { get; set; }

    public string FullName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public int? Gender { get; set; }

    public int? Age { get; set; }

    public int Nationality { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Hospital1 { get; set; }

    public string? Hospital2 { get; set; }

    public string? Hospital3 { get; set; }

    public string? QAndA { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? TypeOfInjury { get; set; }

    public string? Passport { get; set; }

    public string? NationalityId { get; set; }

    public bool? Dead { get; set; }

    public bool? Injured { get; set; }

    public bool? MovedByPeople { get; set; }
}
