using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 测试管理--考试
/// </summary>
public partial class TTestManager
{
    /// <summary>
    /// 表的唯一标识，用于区分不同的记录
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// 测试的名称，简要描述该测试的主题
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 关联的测试集的唯一标识，用于确定该测试所属的测试集
    /// </summary>
    public string TestSetId { get; set; } = null!;

    /// <summary>
    /// 该测试的详细简介，包括测试目的、范围等信息
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// 1
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 进行该测试的具体时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    public DateTime UpdateTime { get; set; }

    public string FromUid { get; set; } = null!;

    public string FromUserName { get; set; } = null!;

    public string Token { get; set; } = null!;

    public int TotalCount { get; set; }

    public int SuccessCount { get; set; }

    public int FailCount { get; set; }

    /// <summary>
    /// 大模型语言
    /// </summary>
    public string LlmModelName { get; set; } = null!;

    /// <summary>
    /// 来源
    /// </summary>
    public int LlmProvider { get; set; }

    /// <summary>
    /// 配置的名字
    /// </summary>
    public string? LlmSettingName { get; set; }

    /// <summary>
    /// 用来测试的试卷信息
    /// </summary>
    public string? TestSetQuestionFullInfo { get; set; }

    /// <summary>
    /// 错误信息
    /// </summary>
    public string? ErrMsg { get; set; }

    public virtual ICollection<TTestManagerObject> TTestManagerObjects { get; set; } = new List<TTestManagerObject>();

    public virtual ICollection<TTestRunTestInfoResult> TTestRunTestInfoResults { get; set; } = new List<TTestRunTestInfoResult>();
}
