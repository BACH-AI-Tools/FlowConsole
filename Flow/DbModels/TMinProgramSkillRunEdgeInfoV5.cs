using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TMinProgramSkillRunEdgeInfoV5
{
    public string Id { get; set; } = null!;

    /// <summary>
    /// 外键
    /// </summary>
    public string RunNodeId { get; set; } = null!;

    /// <summary>
    /// 线的唯一ID
    /// </summary>
    public string? EdgeId { get; set; }

    /// <summary>
    /// 真正要跑的
    /// </summary>
    public bool IsRealRuned { get; set; }

    /// <summary>
    /// 虚拟要跑的（分支才有）
    /// </summary>
    public bool IsFakeRuned { get; set; }

    /// <summary>
    /// 来源  都是node_id
    /// </summary>
    public string Source { get; set; } = null!;

    /// <summary>
    /// 去处  都是node_id
    /// </summary>
    public string Target { get; set; } = null!;

    /// <summary>
    /// 来源的名字
    /// </summary>
    public string SourceName { get; set; } = null!;

    /// <summary>
    /// 去除的名字
    /// </summary>
    public string TargetName { get; set; } = null!;

    /// <summary>
    /// 分支是-1,1,2,  其他都是999
    /// </summary>
    public int Index { get; set; }

    public DateTime? CreateTime { get; set; }

    public int FlowId { get; set; }
}
