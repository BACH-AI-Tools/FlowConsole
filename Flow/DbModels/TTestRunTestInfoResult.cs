using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 测试运行测试信息结果表（考试结果）
/// </summary>
public partial class TTestRunTestInfoResult
{
    /// <summary>
    /// 记录唯一标识
    /// </summary>
    public string Id { get; set; } = null!;

    public string TTestManagerId { get; set; } = null!;

    /// <summary>
    /// 测试时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 问题
    /// </summary>
    public string Question { get; set; } = null!;

    public string QuestionId { get; set; } = null!;

    /// <summary>
    /// 回答
    /// </summary>
    public string? Answer { get; set; }

    public string? AgentId { get; set; }

    /// <summary>
    /// 智能体实例ID，关联t_test_manager_object.id
    /// </summary>
    public string? AgentInstanceId { get; set; }

    /// <summary>
    /// 如果出错只有这个
    /// </summary>
    public string? ErrMsg { get; set; }

    /// <summary>
    /// 1
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// AI打分
    /// </summary>
    public decimal? AiScore { get; set; }

    /// <summary>
    /// AI打分依据
    /// </summary>
    public string? AiReason { get; set; }

    /// <summary>
    /// 人为打分
    /// </summary>
    public decimal? PersonScore { get; set; }

    /// <summary>
    /// 人为打分依据
    /// </summary>
    public string? PersonReason { get; set; }

    /// <summary>
    /// 得分
    /// </summary>
    public decimal? Score { get; set; }

    /// <summary>
    /// 得分率
    /// </summary>
    public decimal? ScoringRate { get; set; }

    /// <summary>
    /// 问题分数
    /// </summary>
    public decimal? QuestionScore { get; set; }

    /// <summary>
    /// 会话ID-用于追踪对话详情
    /// </summary>
    public string? ConversationId { get; set; }

    /// <summary>
    /// 对话ID-用于追踪单轮对话
    /// </summary>
    public string? DialogId { get; set; }

    public virtual TTestManagerObject? AgentInstance { get; set; }

    public virtual TTestManager TTestManager { get; set; } = null!;
}
