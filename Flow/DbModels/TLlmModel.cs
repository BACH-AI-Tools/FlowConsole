using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TLlmModel
{
    public int ModelId { get; set; }

    /// <summary>
    /// 模型名称
    /// </summary>
    public string Model { get; set; } = null!;

    /// <summary>
    /// GenAIProvider从枚举来 的
    /// </summary>
    public int Provider { get; set; }

    public string ProviderName { get; set; } = null!;

    /// <summary>
    /// 类型 0=Completion,1=Embedding,2=text_to_image
    /// </summary>
    public int Type { get; set; }

    public bool IsDefault { get; set; }

    /// <summary>
    /// 模型是否支持function calling
    /// </summary>
    public int? ModelIsSupportFunction { get; set; }

    /// <summary>
    /// 最大token输入
    /// </summary>
    public int? ModelMaxInputTokens { get; set; }

    /// <summary>
    /// 最大token输出
    /// </summary>
    public int? ModelMaxOutputTokens { get; set; }

    /// <summary>
    /// 模型是否支持Image2Text
    /// </summary>
    public int? ModelIsSupportImageInput { get; set; }

    /// <summary>
    /// Enabling this property will enforce the new max_completion_tokens parameter to be send the Azure OpenAI API
    /// </summary>
    public bool? SetNewMaxCompletionTokensEnabled { get; set; }

    /// <summary>
    /// 是否是推理模型
    /// </summary>
    public bool? IsReasoningModel { get; set; }

    /// <summary>
    /// LLM 输入窗口中 1 个字符折算多少 token。
    /// </summary>
    public decimal? CharacterToTokenRatio { get; set; }
}
