using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentSettingFlow
{
    public int SuperAgentSettingFlowId { get; set; }

    public int SuperAgentSettingId { get; set; }

    public int FlowId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }
}
