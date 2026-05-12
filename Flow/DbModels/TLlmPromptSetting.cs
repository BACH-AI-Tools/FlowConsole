using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TLlmPromptSetting
{
    public int PromptSettingId { get; set; }

    /// <summary>
    /// 配置名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Describe { get; set; }

    /// <summary>
    /// 随机性
    /// </summary>
    public double? Temperature { get; set; }

    /// <summary>
    /// topP
    /// </summary>
    public double? TopP { get; set; }

    /// <summary>
    /// 最长长度
    /// </summary>
    public double? TopK { get; set; }

    /// <summary>
    /// 最长回复
    /// </summary>
    public int MaxTokens { get; set; }

    /// <summary>
    /// 1删除的  0未删除
    /// </summary>
    public bool IsDelete { get; set; }
}
