using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 企业信息表
/// </summary>
public partial class TEnterpriseInfo
{
    public int Id { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    public string? Logo { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// 创建人id
    /// </summary>
    public int? CreatedBy { get; set; }

    /// <summary>
    /// 启用水印：0 未启用；1已启用；
    /// </summary>
    public bool? UseWatermark { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 更新人id
    /// </summary>
    public int? UpdateBy { get; set; }
}
