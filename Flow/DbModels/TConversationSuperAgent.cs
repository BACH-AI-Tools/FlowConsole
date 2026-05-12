using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TConversationSuperAgent
{
    public int ConversationSuperAgentsId { get; set; }

    public string ConversationId { get; set; } = null!;

    public int SuperAgentSettingId { get; set; }

    public string? SuperAgentVersion { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }
}
