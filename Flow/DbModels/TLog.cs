using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TLog
{
    public string Id { get; set; } = null!;

    public string? Request { get; set; }

    public string? Responseq { get; set; }
}
