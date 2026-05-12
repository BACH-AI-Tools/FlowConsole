using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TLlmSkLog
{
    public string SkLogId { get; set; } = null!;

    public string? UserId { get; set; }

    public string? UserName { get; set; }

    public int? ScenarioType { get; set; }

    public string? ScenarioDescription { get; set; }

    public string? Prompt { get; set; }

    public string? Completion { get; set; }

    public string? Function { get; set; }

    public string? FunctionArguments { get; set; }

    public string? FunctionResult { get; set; }

    public int? Provider { get; set; }

    public string? Model { get; set; }

    public int? UsedPromptToken { get; set; }

    public int? UsedCompletionToken { get; set; }

    public int? UsedTotalToken { get; set; }

    public DateTime? CreatedTime { get; set; }

    public bool? IsPassedPromptCheck { get; set; }

    public bool? IsPassedCompletionCheck { get; set; }

    public string? PromptCheckFailReason { get; set; }

    public string? CompletionCheckFailReason { get; set; }

    public string? Identification { get; set; }

    public string? PromptId { get; set; }

    public DateTime? CompletionTime { get; set; }

    public DateTime? InputTime { get; set; }

    public string? ConversationId { get; set; }
}
