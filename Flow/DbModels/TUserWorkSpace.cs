using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 工作区
/// </summary>
public partial class TUserWorkSpace
{
    public int Id { get; set; }

    /// <summary>
    /// 工作区名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 工作区顺序
    /// </summary>
    public int? Sort { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// 创建人ID
    /// </summary>
    public int? CreatedBy { get; set; }

    /// <summary>
    /// 创建人姓名
    /// </summary>
    public string? CreatedByName { get; set; }

    /// <summary>
    /// 最后更新时间
    /// </summary>
    public DateTime? LastUpdateTime { get; set; }
}
