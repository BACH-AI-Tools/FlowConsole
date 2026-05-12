using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentSettingPresetQuestion
{
    public int Id { get; set; }

    public int SuperAgentSettingId { get; set; }

    /// <summary>
    /// 预设问题
    /// </summary>
    public string? PresetQuestion { get; set; }

    public int Sort { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }
}
