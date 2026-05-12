using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TFlowNodeLog
{
    public int Id { get; set; }

    /// <summary>
    /// 请求参数
    /// </summary>
    public string? Request { get; set; }

    /// <summary>
    /// 返回值
    /// </summary>
    public string? Response { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// 用户
    /// </summary>
    public int? Uid { get; set; }

    /// <summary>
    /// node_id  可能会在 flow_node库里面没有，
    /// </summary>
    public int? NodeId { get; set; }

    public string? Prompt { get; set; }
}
