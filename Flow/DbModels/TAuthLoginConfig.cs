using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TAuthLoginConfig
{
    public int Id { get; set; }

    /// <summary>
    /// 外键
    /// </summary>
    public int AuthLoginCategory { get; set; }

    /// <summary>
    /// config 的json
    /// </summary>
    public string ConfigJson { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public DateTime UpdateTime { get; set; }
}
