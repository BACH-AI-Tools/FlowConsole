using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// ai小程序管理标签
/// </summary>
public partial class TFlowManageLable
{
    public int FlowManageLableId { get; set; }

    public int FlowId { get; set; }

    /// <summary>
    /// 管理标签id
    /// </summary>
    public int SuperAgentCategoryId { get; set; }

    /// <summary>
    /// 权限类型：1=使用权限，2=编辑权限
    /// </summary>
    public int? PermissionType { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }
}
