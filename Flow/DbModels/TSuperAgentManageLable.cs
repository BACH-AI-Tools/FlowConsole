using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 智能体管理标签
/// </summary>
public partial class TSuperAgentManageLable
{
    public int AgentManageLableId { get; set; }

    /// <summary>
    /// 智能体id
    /// </summary>
    public int SuperAgentSettingId { get; set; }

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
