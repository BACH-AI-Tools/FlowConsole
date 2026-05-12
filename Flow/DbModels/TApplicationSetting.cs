using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TApplicationSetting
{
    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Type { get; set; }

    public bool IsValid { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }
}
