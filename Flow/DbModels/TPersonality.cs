using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TPersonality
{
    public int PersonalityId { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }

    public bool? Isdelete { get; set; }
}
