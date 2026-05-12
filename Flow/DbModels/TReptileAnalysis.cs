using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TReptileAnalysis
{
    public int Id { get; set; }

    /// <summary>
    /// 需要分析的网址
    /// </summary>
    public string Url { get; set; } = null!;

    /// <summary>
    /// 深度 最少一层
    /// </summary>
    public int Depth { get; set; }

    /// <summary>
    /// 分析进度
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 报错信息
    /// </summary>
    public string? Msg { get; set; }

    /// <summary>
    /// 知识库id
    /// </summary>
    public string? LibraryId { get; set; }

    /// <summary>
    /// 是否删除1.删除  0.可用
    /// </summary>
    public bool? IsDelete { get; set; }

    /// <summary>
    /// 是否是每天更新，1.是，0不是
    /// </summary>
    public bool? IsEveryDayUpdate { get; set; }

    public int? Role { get; set; }

    public string? UserId { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreatedTime { get; set; }

    /// <summary>
    /// 标签
    /// </summary>
    public string? Tags { get; set; }

    public virtual ICollection<TReptileAnalysisResult> TReptileAnalysisResults { get; set; } = new List<TReptileAnalysisResult>();
}
