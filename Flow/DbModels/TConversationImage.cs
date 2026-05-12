using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TConversationImage
{
    public int Id { get; set; }

    public string? ConversationId { get; set; }

    public string? ImgName { get; set; }

    public string? ImgUrl { get; set; }

    public int? Uid { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }
}
