using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentRelease
{
    public int PublishId { get; set; }

    /// <summary>
    /// agent id
    /// </summary>
    public int SuperAgentSettingId { get; set; }

    public string? SuperAgentConfig { get; set; }

    public string? Description { get; set; }

    public string? Version { get; set; }

    public string? VersionSpecialIdentification { get; set; }

    public string? Remark { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public virtual TSuperAgentSetting SuperAgentSetting { get; set; } = null!;
}
