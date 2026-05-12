using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TLlmModelPromotMapping
{
    public string Id { get; set; } = null!;

    public int LlmPromptSettingId { get; set; }

    public int LlmModelId { get; set; }

    public bool? IsValid { get; set; }

    public DateTime CreateTime { get; set; }
}
