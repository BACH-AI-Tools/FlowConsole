using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TConversationSurvey
{
    public int Id { get; set; }

    public string VariableName { get; set; } = null!;

    public string? VariableValue { get; set; }

    /// <summary>
    /// 变量描述
    /// </summary>
    public string VariableDescription { get; set; } = null!;

    /// <summary>
    /// 样例内容
    /// </summary>
    public string ExampleContent { get; set; } = null!;

    public string ConversationId { get; set; } = null!;

    public virtual TConversation Conversation { get; set; } = null!;
}
