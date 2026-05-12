using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 测试集（试卷）
/// </summary>
public partial class TTestSet
{
    public string Id { get; set; } = null!;

    /// <summary>
    ///  名字
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 标签
    /// </summary>
    public string Tag { get; set; } = null!;

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public string FromUid { get; set; } = null!;

    public string FromUserName { get; set; } = null!;

    /// <summary>
    /// 总分
    /// </summary>
    public decimal? TotalScore { get; set; }

    public string? UpdateUid { get; set; }

    public DateTime? UpdateTime { get; set; }

    public string? UpdateUserName { get; set; }

    public virtual ICollection<TTestSetQuestion> TTestSetQuestions { get; set; } = new List<TTestSetQuestion>();
}
