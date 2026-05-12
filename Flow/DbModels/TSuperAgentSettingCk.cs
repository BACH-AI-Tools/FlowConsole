using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentSettingCk
{
    public int SuperAgentSettingId { get; set; }

    public int Similarity { get; set; }

    public int Limit { get; set; }

    public bool IsValid { get; set; }
}
