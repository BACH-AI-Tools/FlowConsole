using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TLlmGlobalVariable
{
    public int Id { get; set; }

    public string ScenarioName { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Provider { get; set; }

    /// <summary>
    /// 
    /// 
    /// 
    /// </summary>
    public string ConfigName { get; set; } = null!;

    public string? Description { get; set; }
}
