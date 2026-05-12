using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentQuickCommand
{
    public int QuickCommandId { get; set; }

    public string? Name { get; set; }

    public string? Tip { get; set; }

    public int? Category { get; set; }

    public string? Prompt { get; set; }

    public int SuperAgentSettingId { get; set; }

    public string? JsonEx1 { get; set; }

    public int Sort { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual TSuperAgentSetting SuperAgentSetting { get; set; } = null!;
}
