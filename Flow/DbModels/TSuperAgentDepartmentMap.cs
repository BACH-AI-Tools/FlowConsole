using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 用户组与部门映射表
/// </summary>
public partial class TSuperAgentDepartmentMap
{
    public int Id { get; set; }

    /// <summary>
    /// 1=智能体，2=小程序
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// 智能体id/小程序id
    /// </summary>
    public int EntityId { get; set; }

    /// <summary>
    /// 部门编号
    /// </summary>
    public string DepartmentCode { get; set; } = null!;

    /// <summary>
    /// 权限类型：1=使用权限，2=编辑权限
    /// </summary>
    public int? PermissionType { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public string? CreateBy { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// 更新人
    /// </summary>
    public string? UpdateBy { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }
}
