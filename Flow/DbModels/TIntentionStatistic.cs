using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 意图统计
/// </summary>
public partial class TIntentionStatistic
{
    public int Id { get; set; }

    /// <summary>
    /// 智能体id
    /// </summary>
    public string AgentId { get; set; } = null!;

    /// <summary>
    /// 会话id
    /// </summary>
    public string ConversationId { get; set; } = null!;

    /// <summary>
    /// 对话id
    /// </summary>
    public string DialogId { get; set; } = null!;

    /// <summary>
    /// 技能类型
    /// </summary>
    public string SkillCategory { get; set; } = null!;

    /// <summary>
    /// 意图触发日期
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// 意图触发时间
    /// </summary>
    public DateTime CreateTime { get; set; }
}
