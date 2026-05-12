using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TMessageTopic
{
    public int MessageTopicId { get; set; }

    public int? SessionOwner { get; set; }

    public int? IsReplay { get; set; }

    public string? LastMessage { get; set; }

    public DateTime? LastUpdatedTime { get; set; }
}
