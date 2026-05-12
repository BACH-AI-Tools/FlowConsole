using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TFlowNode
{
    public int Id { get; set; }

    public int? FlowId { get; set; }

    /// <summary>
    /// 步骤名字
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 步骤
    /// </summary>
    public int? Step { get; set; }

    /// <summary>
    /// 详情
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 大json
    /// </summary>
    public string? DesignParams { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? UpdateTime { get; set; }

    public int? UpdateUid { get; set; }

    /// <summary>
    /// 坐标位置
    /// </summary>
    public decimal? Left { get; set; }

    /// <summary>
    /// 坐标位置
    /// </summary>
    public decimal? Top { get; set; }

    /// <summary>
    /// 不是主键，前端显示用的
    /// </summary>
    public string? NodeId { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public string? NodeType { get; set; }

    /// <summary>
    /// prompt
    /// </summary>
    public string? Prompt { get; set; }

    /// <summary>
    /// action——type
    /// </summary>
    public string? Type { get; set; }

    public virtual TFlow? Flow { get; set; }

    public virtual ICollection<TFlowVariable> TFlowVariables { get; set; } = new List<TFlowVariable>();
}
