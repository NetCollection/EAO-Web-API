using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class VFee
{
    public long FeesId { get; set; }

    public long TicketId { get; set; }

    public long ServiceId { get; set; }

    public long? ReceiptNo { get; set; }

    public int? TransType { get; set; }

    public int? CollectorId { get; set; }

    public int? FeesStatus { get; set; }

    public double? ServiceFees { get; set; }

    public int? TransDistination { get; set; }

    public string? TransDistinationAddr { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? TicketGov { get; set; }

    public int? CarCode { get; set; }

    public long? CarId { get; set; }

    public int? CarGov { get; set; }

    public DateTime? ServiceStartAt { get; set; }

    public DateTime? ServiceEndedAt { get; set; }

    public long? CounterStart { get; set; }

    public long? CounterEnd { get; set; }

    public string? DriverName { get; set; }
}
