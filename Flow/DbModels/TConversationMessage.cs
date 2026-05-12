using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TConversationMessage
{
    public int MessageId { get; set; }

    public string ConversationId { get; set; } = null!;

    public string? DialogId { get; set; }

    public string? SenderId { get; set; }

    public string? SenderType { get; set; }

    public string? Message { get; set; }

    public string? MessageType { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    public string? SkLogId { get; set; }

    public string? Identification { get; set; }
}
