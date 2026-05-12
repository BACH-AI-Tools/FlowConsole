using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TFlowPublish
{
    public string Id { get; set; } = null!;

    public string Version { get; set; } = null!;

    public int FlowId { get; set; }

    public string Context { get; set; } = null!;

    /// <summary>
    /// 前端要的文本格式
    /// </summary>
    public string FrontContext { get; set; } = null!;

    /// <summary>
    /// 修改时间
    /// </summary>
    public DateTime MergeTime { get; set; }

    public string? Md5 { get; set; }

    /// <summary>
    /// 使用
    /// </summary>
    public bool IsUsed { get; set; }

    /// <summary>
    /// 发布者id
    /// </summary>
    public int? PublishUid { get; set; }

    /// <summary>
    /// 发布历史名称
    /// </summary>
    public string? PublishTitle { get; set; }
}
