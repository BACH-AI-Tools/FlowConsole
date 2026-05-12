using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TCustomTag
{
    public string Id { get; set; } = null!;

    /// <summary>
    /// 标签，以逗号(,)分割
    /// </summary>
    public string Tag { get; set; } = null!;

    /// <summary>
    /// 类型
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// 第三方ID，用于查询
    /// </summary>
    public string ThirdId { get; set; } = null!;

    public int CreatedBy { get; set; }

    public string CreatedByName { get; set; } = null!;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? MergeTime { get; set; }
}
