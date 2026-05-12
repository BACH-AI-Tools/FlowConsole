using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentSettingPlugin
{
    public int SuperAgentSettingPluginId { get; set; }

    public int? SuperAgentSettingId { get; set; }

    public int? PluginId { get; set; }

    public string? HeaderInfo { get; set; }

    public string? PluginDescription { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }
}
