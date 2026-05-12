using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 针对小程序单独的创建和执行的记录表
/// </summary>
public partial class TFlowLog
{
    public int Id { get; set; }

    public int FlowId { get; set; }

    public int Type { get; set; }

    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 创建人id
    /// </summary>
    public int? CreatedBy { get; set; }

    public int InvodeType { get; set; }

    public string? DialogId { get; set; }
}
