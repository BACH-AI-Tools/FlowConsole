using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 编辑者信息
/// </summary>
public partial class TEditorInfo
{
    public int Id { get; set; }

    /// <summary>
    /// 类型：1=智能体，2=小程序
    /// </summary>
    public int? Type { get; set; }

    /// <summary>
    /// 对应的表id
    /// </summary>
    public string? TableId { get; set; }

    /// <summary>
    /// 编辑者id
    /// </summary>
    public int? EditorUid { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreateTime { get; set; }
}
