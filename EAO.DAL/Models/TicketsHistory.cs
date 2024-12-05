using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class TicketsHistory
{
    public long Id { get; set; }

    public long TicketId { get; set; }

    public string? Eaocode { get; set; }

    public int CallSource { get; set; }

    public int? Area { get; set; }

    public int Governorate { get; set; }

    public int CaseType { get; set; }

    public int CaseSubType { get; set; }

    public int Priority { get; set; }

    public string? DealingStatus { get; set; }

    public string IncidentLocation { get; set; } = null!;

    public int? NoticeStatus { get; set; }

    public bool? NoticeStatusEnd { get; set; }

    public int? CallerId { get; set; }

    public string? QAndA { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? CallConverted { get; set; }

    public string? CallConvertComment { get; set; }

    public int? CallConvertReason { get; set; }

    public int? DailySno { get; set; }

    public int? DisconnectCall { get; set; }

    public int? FollowUp { get; set; }
}
