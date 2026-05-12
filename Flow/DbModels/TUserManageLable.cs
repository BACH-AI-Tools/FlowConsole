using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 用户管理标签
/// </summary>
public partial class TUserManageLable
{
    public int UserManageLableId { get; set; }

    /// <summary>
    /// 用户id
    /// </summary>
    public int Uid { get; set; }

    /// <summary>
    /// 管理标签id
    /// </summary>
    public int SuperAgentCategoryId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }
}
