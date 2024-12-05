using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class AlertBroadcast
{
    public long Id { get; set; }

    public long AlertId { get; set; }

    public int UserId { get; set; }

    public DateTime? ReadAt { get; set; }

    public DateTime? CreatedAt { get; set; }
}
