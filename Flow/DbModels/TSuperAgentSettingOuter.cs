using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentSettingOuter
{
    public int SuperAgentSettingId { get; set; }

    /// <summary>
    /// agent类型；0：bach agent；1：founry agent
    /// </summary>
    public int? Category { get; set; }

    public string? Endpoint { get; set; }

    public string? TenantId { get; set; }

    public string? ClientId { get; set; }

    public string? ClientSecret { get; set; }

    public string? AgentName { get; set; }
}
