using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 小程序的寻路算法归档表
/// </summary>
public partial class TMinProgramSkillPathfindingArchive
{
    public string Id { get; set; } = null!;

    /// <summary>
    /// 小程序id
    /// </summary>
    public int FlowId { get; set; }

    /// <summary>
    /// 对话id
    /// </summary>
    public string DialogId { get; set; } = null!;

    /// <summary>
    /// blob的地址
    /// </summary>
    public string BlobUrl { get; set; } = null!;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
}
