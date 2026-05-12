using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TFlow
{
    public int FlowId { get; set; }

    /// <summary>
    /// flow名字
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 图标
    /// </summary>
    public string? Logo { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? UpdateTime { get; set; }

    public int? UpdateUid { get; set; }

    /// <summary>
    /// 是否已发布
    /// </summary>
    public bool IsPublish { get; set; }

    /// <summary>
    /// 发布时间
    /// </summary>
    public DateTime? PublishTime { get; set; }

    /// <summary>
    /// 取消发布时间
    /// </summary>
    public DateTime? CancelPublishTime { get; set; }

    /// <summary>
    /// 类别id
    /// </summary>
    public int? SuperAgentCategoryId { get; set; }

    /// <summary>
    /// 使用次数
    /// </summary>
    public int Count { get; set; }

    public string? Md5 { get; set; }

    /// <summary>
    /// 是否版本一样
    /// </summary>
    public bool IsVersionSame { get; set; }

    /// <summary>
    /// 1.普通，2专业
    /// </summary>
    public int Type { get; set; }

    public string Uuid { get; set; } = null!;

    public virtual ICollection<TFlowEdge> TFlowEdges { get; set; } = new List<TFlowEdge>();

    public virtual ICollection<TFlowNode> TFlowNodes { get; set; } = new List<TFlowNode>();

    public virtual ICollection<TFlowVariable> TFlowVariables { get; set; } = new List<TFlowVariable>();
}
