using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentSettingApiPublish
{
    public int Id { get; set; }

    public int SuperAgentSettingId { get; set; }

    public int Uid { get; set; }

    public DateTime? CreateTime { get; set; }
}
