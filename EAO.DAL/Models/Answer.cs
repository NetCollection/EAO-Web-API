using System;
using System.Collections.Generic;

namespace EAO.DAL.Models;

public partial class Answer
{
    public long Id { get; set; }

    public int Qid { get; set; }

    public string Answer1 { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
