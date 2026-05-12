using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TAgentCallback
{
    public string Id { get; set; } = null!;

    public string? Data { get; set; }

    public string? Signature { get; set; }

    public string? Timestamp { get; set; }

    /// <summary>
    /// 入库时间
    /// </summary>
    public DateTime? CreateTime { get; set; }
}
