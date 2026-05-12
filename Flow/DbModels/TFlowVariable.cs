using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TFlowVariable
{
    public int VariableId { get; set; }

    /// <summary>
    /// 参数名字
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 字段key
    /// </summary>
    public string? Variable { get; set; }

    /// <summary>
    /// 字段value
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// 前端对应存的值
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// 高度
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    /// 步骤数
    /// </summary>
    public int? Step { get; set; }

    /// <summary>
    /// 前端使用的 类型，input/output
    /// </summary>
    public string? VariableType { get; set; }

    public int? NodeId { get; set; }

    public int? FlowId { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? CreateUid { get; set; }

    public DateTime? UpdateTime { get; set; }

    public int? UpdateUid { get; set; }

    /// <summary>
    /// 后端使用的，输入类型 类型，input/output
    /// </summary>
    public string? FlowVariableType { get; set; }

    public virtual TFlow? Flow { get; set; }

    public virtual TFlowNode? Node { get; set; }
}
