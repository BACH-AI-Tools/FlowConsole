using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TOperationAuditLog
{
    /// <summary>
    /// 主键
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 模块编码，如 AGENT / MINI_PROGRAM
    /// </summary>
    public string ModuleCode { get; set; } = null!;

    /// <summary>
    /// 模块名称，如 智能体 / 小程序
    /// </summary>
    public string ModuleName { get; set; } = null!;

    /// <summary>
    /// 业务对象ID
    /// </summary>
    public string BizId { get; set; } = null!;

    /// <summary>
    /// 业务对象名称
    /// </summary>
    public string BizName { get; set; } = null!;

    /// <summary>
    /// 操作编码
    /// </summary>
    public string ActionCode { get; set; } = null!;

    /// <summary>
    /// 操作人ID
    /// </summary>
    public int OperatorId { get; set; }

    /// <summary>
    /// 操作时记录的配置快照
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 操作人姓名
    /// </summary>
    public string? OperatorName { get; set; }
}
