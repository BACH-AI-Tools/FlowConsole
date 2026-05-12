using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSensitiveWord
{
    public string Id { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string? Word { get; set; }

    public bool? Enable { get; set; }
}
