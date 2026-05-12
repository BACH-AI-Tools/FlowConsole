using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 小程序flowapi调用记录
/// </summary>
public partial class TMinProgramSkillInfoFlowApiInvokeRecord
{
    public string JobId { get; set; } = null!;

    public int FlowId { get; set; }

    /// <summary>
    /// 状态值
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 调用时间
    /// </summary>
    public DateTime InvokeTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    public DateTime? FinishTime { get; set; }

    /// <summary>
    /// 资源ID
    /// </summary>
    public string ResourceId { get; set; } = null!;

    public virtual TMinProgramSkillInfoFlowApiInvokeRecordContext? TMinProgramSkillInfoFlowApiInvokeRecordContext { get; set; }
}
