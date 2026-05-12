using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TAnswer
{
    public int AnswerId { get; set; }

    public int? QuestionId { get; set; }

    public string? Sn { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Score { get; set; }
}
