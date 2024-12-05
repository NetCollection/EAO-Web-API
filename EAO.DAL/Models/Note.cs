using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class Note
{
    public long Id { get; set; }

    public string Note1 { get; set; } = null!;

    public string NoteType { get; set; } = null!;

    public long TicketId { get; set; }

    public long? RelId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
