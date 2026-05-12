using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TMinProgramScheduledTaskRecord
{
    public string Id { get; set; } = null!;

    /// <summary>
    /// 小程序定时任务id
    /// </summary>
    public string? MinProgramTaskId { get; set; }

    /// <summary>
    /// 执行来源，0=手工，1=自动
    /// </summary>
    public int? ExecType { get; set; }

    /// <summary>
    /// 开始执行时间
    /// </summary>
    public DateTime? StartExecTime { get; set; }

    /// <summary>
    /// 执行时长
    /// </summary>
    public int? ExecDuration { get; set; }

    /// <summary>
    /// 执行状态，0=执行中，500=执行失败，200=执行成功
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// 失败原因
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// 执行结果
    /// </summary>
    public string? Result { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreateTime { get; set; }
}
