using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TMessage
{
    public int MessageId { get; set; }

    public int? MessageTopicId { get; set; }

    public int? FromUid { get; set; }

    public string? FromName { get; set; }

    public int? IsAdmin { get; set; }

    public string? Message { get; set; }

    public DateTime? CreatedTime { get; set; }
}
