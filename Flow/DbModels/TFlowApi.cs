using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TFlowApi
{
    public string ResourceId { get; set; } = null!;

    public int FlowId { get; set; }

    /// <summary>
    /// api的地址
    /// </summary>
    public string ApiUrl { get; set; } = null!;

    /// <summary>
    /// 请求参数，用于判断
    /// </summary>
    public string RequestParams { get; set; } = null!;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime UpdateTime { get; set; }

    /// <summary>
    /// 用户id
    /// </summary>
    public string FromUser { get; set; } = null!;

    /// <summary>
    /// 是否启用
    /// </summary>
    public bool? IsUsed { get; set; }

    public string? EndParams { get; set; }
}
