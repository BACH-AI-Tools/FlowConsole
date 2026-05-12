using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TConversationSuperAgentsSequence
{
    public int ConversationSuperAgentsSequenceId { get; set; }

    public string ConversationId { get; set; } = null!;

    /// <summary>
    /// -1 表示用户
    /// </summary>
    public int SuperAgentSettingFromId { get; set; }

    /// <summary>
    /// -1 表示用户
    /// </summary>
    public int SuperAgentSettingToId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }
}
