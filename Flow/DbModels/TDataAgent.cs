using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TDataAgent
{
    public int DataAgentId { get; set; }

    public string ConnectKey { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public int Uid { get; set; }
}
