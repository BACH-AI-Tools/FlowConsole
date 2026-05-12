using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// agent的模型选择
/// 
/// </summary>
public partial class TSuperAgentSettingLlm
{
    public int Id { get; set; }

    public int SuperAgentSettingId { get; set; }

    /// <summary>
    /// 大模型技能 ：1 知识库查询结果的总结：2
    /// </summary>
    public int Type { get; set; }

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

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    /// <summary>
    /// 模型是否支持function calling
    /// </summary>
    public int? ModelIsSupportFunction { get; set; }
}
