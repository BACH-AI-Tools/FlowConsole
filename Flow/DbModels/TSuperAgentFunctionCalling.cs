using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentFunctionCalling
{
    public int FunctionCallId { get; set; }

    public string? ConversationId { get; set; }

    public string? DialogId { get; set; }

    public string? TaskNumber { get; set; }

    public string? FunctionName { get; set; }

    public string? FunctionInput { get; set; }

    public string? FunctionOutput { get; set; }

    public string? FunctionDescription { get; set; }

    public DateTime? CreatedTime { get; set; }
}
