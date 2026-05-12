using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 针对小程序单独的创建和执行的记录表
/// </summary>
public partial class TFlowProcessInfo
{
    public int Id { get; set; }

    public int FlowId { get; set; }

    public string? DialogId { get; set; }

    /// <summary>
    /// 过程的blob url地址
    /// </summary>
    public string BlobUrl { get; set; } = null!;

    public DateTime CreateTime { get; set; }
}
