using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TPromptTemplateConfig
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Prompt { get; set; }

    public int? Category { get; set; }

    public int? Uid { get; set; }

    public int? Sort { get; set; }

    public DateTime? CreateTime { get; set; }
}
