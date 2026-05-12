using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TFunctionPromptExecution
{
    public int Id { get; set; }

    public double? Temperature { get; set; }

    public double? TopP { get; set; }

    public double? PresencePenalty { get; set; }

    public double? FrequencyPenalty { get; set; }

    public int? MaxTokens { get; set; }

    public string? StopSequences { get; set; }

    public int? ResultsPerPrompt { get; set; }

    public long? Seed { get; set; }

    /// <summary>
    /// &quot;json_object&quot;, &quot;text&quot;
    /// </summary>
    public string? ResponseFormat { get; set; }

    public string? ChatSystemPrompt { get; set; }

    public int? FuntionId { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual TFunction? Funtion { get; set; }
}
