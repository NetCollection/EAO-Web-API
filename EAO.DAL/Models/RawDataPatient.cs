using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class RawDataPatient
{
    public long? ServiceId { get; set; }

    public long? TicketId { get; set; }

    public long? CarId { get; set; }

    public int? CarCode { get; set; }

    public long PatientId { get; set; }

    public int? DriverId { get; set; }

    public int? ParamedicId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? CarGov { get; set; }

    public int? CallSource { get; set; }

    public int? Area { get; set; }

    public int? TicketGov { get; set; }

    public int? Ct { get; set; }

    public int? Cst { get; set; }

    public int? Priority { get; set; }

    public string? TicketDealing { get; set; }

    public string? IncidentLocation { get; set; }

    public int? TicketStatusEnd { get; set; }

    public int? TicketStatus { get; set; }

    public int? CallerId { get; set; }

    public DateTime? TicketCreation { get; set; }

    public DateTime? TicketLastUpd { get; set; }

    public string? CallerName { get; set; }

    public string? CallerPhone { get; set; }

    public string? CallerOtherPhones { get; set; }

    public long? ReceiptNo { get; set; }

    public int? TransType { get; set; }

    public int? CollectorId { get; set; }

    public int? FeesStatus { get; set; }

    public double? ServiceFees { get; set; }

    public int? TransDistination { get; set; }

    public string? TransDistinationAddr { get; set; }

    public string? DriverName { get; set; }

    public string PatientName { get; set; } = null!;

    public int? Gender { get; set; }

    public int? Age { get; set; }

    public int Nationality { get; set; }

    public string? Phone { get; set; }

    public string? ParamedicName { get; set; }
}
