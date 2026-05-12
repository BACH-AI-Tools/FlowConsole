using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 参加本次考试的考生
/// </summary>
public partial class TTestManagerObject
{
    public string Id { get; set; } = null!;

    public string TestManagerId { get; set; } = null!;

    public string AgentId { get; set; } = null!;

    public string? AgentName { get; set; }

    /// <summary>
    /// 1:agent
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// agent 回答所有问题的总分
    /// </summary>
    public decimal? TotalScore { get; set; }

    /// <summary>
    /// 得分率
    /// </summary>
    public decimal? TotalScoringRate { get; set; }

    /// <summary>
    /// agent的所有信息
    /// </summary>
    public string? AgentFullInfo { get; set; }

    /// <summary>
    /// agent的版本号
    /// </summary>
    public string? AgentVersion { get; set; }

    /// <summary>
    /// kb的信息
    /// </summary>
    public string? AgentKbInfo { get; set; }

    /// <summary>
    /// 智能体绑定知识库的检索策略信息
    /// </summary>
    public string? AgentSearchPolicy { get; set; }

    public virtual ICollection<TTestRunTestInfoResult> TTestRunTestInfoResults { get; set; } = new List<TTestRunTestInfoResult>();

    public virtual TTestManager TestManager { get; set; } = null!;
}
