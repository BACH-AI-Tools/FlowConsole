using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentTaskDocument
{
    public int DocumentId { get; set; }

    /// <summary>
    /// 文档名称
    /// </summary>
    public string? DocumentName { get; set; }

    public string? ConversationId { get; set; }

    public string? DialogId { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }
}
