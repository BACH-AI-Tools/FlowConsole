using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TAssistentTopicMessage
{
    public int AssistentTopicMessageId { get; set; }

    public int? AssistentTopicId { get; set; }

    public int? QuestionId { get; set; }

    public string? Role { get; set; }

    public string? Message { get; set; }

    public string? ModelId { get; set; }

    public string? Metadata { get; set; }

    public string? Toolcall { get; set; }

    public string? CurrentChatId { get; set; }

    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// 类型：1=助理，2=AI
    /// </summary>
    public int? Type { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    public int? UseId { get; set; }

    /// <summary>
    /// 用户问的问题
    /// </summary>
    public string? Question { get; set; }

    /// <summary>
    /// 用于排序
    /// </summary>
    public int? Sort { get; set; }
}
