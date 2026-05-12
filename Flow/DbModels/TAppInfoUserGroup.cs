using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// OneApp应用-用户组关联表
/// </summary>
public partial class TAppInfoUserGroup
{
    /// <summary>
    /// 主键ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 应用编码（关联 t_app_info.app_code）
    /// </summary>
    public string AppCode { get; set; } = null!;

    /// <summary>
    /// 用户组ID（对应 t_super_agent_category 表中 type=5 的管理标签）
    /// </summary>
    public int UserGroupId { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// 创建人ID
    /// </summary>
    public int? CreatedBy { get; set; }

    /// <summary>
    /// 创建人名称
    /// </summary>
    public string? CreatedByName { get; set; }

    public virtual TAppInfo AppCodeNavigation { get; set; } = null!;

    public virtual TSuperAgentCategory UserGroup { get; set; } = null!;
}
