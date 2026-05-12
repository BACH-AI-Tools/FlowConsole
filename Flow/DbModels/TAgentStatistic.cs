using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// agent 各种统计表
/// </summary>
public partial class TAgentStatistic
{
    public int Id { get; set; }

    public int AgentId { get; set; }

    /// <summary>
    /// 时间
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    public decimal Data { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// 添加时间
    /// </summary>
    public DateTime CreateOn { get; set; }
}
