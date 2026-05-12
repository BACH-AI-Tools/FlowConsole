using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 员工部门表
/// </summary>
public partial class TDepartment
{
    public int DepartmentId { get; set; }

    /// <summary>
    /// 部门编号
    /// </summary>
    public string DepartmentCode { get; set; } = null!;

    /// <summary>
    /// 中文名
    /// </summary>
    public string? NameZhCn { get; set; }

    /// <summary>
    /// 英文名(暂时不用)
    /// </summary>
    public string? NameEnUs { get; set; }

    /// <summary>
    /// 上级部门编号
    /// </summary>
    public string? ParentCode { get; set; }

    /// <summary>
    /// 使用状态：true=有效，false=无效
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// 上次同步时间
    /// </summary>
    public DateTime? LastSyncTime { get; set; }

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
