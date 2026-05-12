using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TPurpose
{
    public int PurposeId { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }

    public string? Cluster { get; set; }

    public bool? Isdelete { get; set; }
}
