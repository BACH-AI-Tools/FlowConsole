using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TReptileAnalysisResult
{
    public int Id { get; set; }

    /// <summary>
    /// 分析结果的url
    /// </summary>
    public string Url { get; set; } = null!;

    /// <summary>
    /// 标题
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreatedTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 报错信息
    /// </summary>
    public string? Msg { get; set; }

    public int ReptileAnalysisId { get; set; }

    public virtual TReptileAnalysis ReptileAnalysis { get; set; } = null!;
}
