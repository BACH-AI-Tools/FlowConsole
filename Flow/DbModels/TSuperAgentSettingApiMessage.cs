using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentSettingApiMessage
{
    public string Id { get; set; } = null!;

    public string ConversationId { get; set; } = null!;

    public string FromId { get; set; } = null!;

    public string? DialogId { get; set; }

    /// <summary>
    /// 问题
    /// </summary>
    public string? Ask { get; set; }

    /// <summary>
    /// 回答
    /// </summary>
    public string? Answer { get; set; }

    /// <summary>
    /// 引用
    /// </summary>
    public string? Reference { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime UpdateTime { get; set; }

    public int Status { get; set; }
}
