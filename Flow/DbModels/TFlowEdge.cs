using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TFlowEdge
{
    public int Id { get; set; }

    public int? FlowId { get; set; }

    public string? SourceNode { get; set; }

    public string? TargetNode { get; set; }

    public string? Source { get; set; }

    /// <summary>
    /// 坐标位置
    /// </summary>
    public string? Target { get; set; }

    /// <summary>
    /// 坐标位置
    /// </summary>
    public string? Variable { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? CreateUid { get; set; }

    /// <summary>
    /// 上面的都不用了。只用下面的
    /// </summary>
    public string? Text { get; set; }

    public virtual TFlow? Flow { get; set; }
}
