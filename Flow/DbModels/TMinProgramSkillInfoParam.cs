using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TMinProgramSkillInfoParam
{
    public string Id { get; set; } = null!;

    public string MinProgramInfoId { get; set; } = null!;

    /// <summary>
    /// 1:input 2:output
    /// </summary>
    public int Type { get; set; }

    public string? Key { get; set; }

    public string? Value { get; set; }

    /// <summary>
    /// 唯一编号
    /// </summary>
    public long VariableId { get; set; }

    /// <summary>
    /// 参数类型，input，textarea
    /// </summary>
    public string? ParamType { get; set; }

    public string? Name { get; set; }

    public int? Step { get; set; }

    public virtual TMinProgramSkillInfo MinProgramInfo { get; set; } = null!;
}
