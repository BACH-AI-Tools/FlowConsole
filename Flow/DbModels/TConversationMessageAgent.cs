using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TConversationMessageAgent
{
    public int Id { get; set; }

    public int MessageId { get; set; }

    public int SuperAgentSettingId { get; set; }

    public string SuperAgentVersion { get; set; } = null!;
}
