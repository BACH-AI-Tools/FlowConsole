using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TFlowApiPublish
{
    public int Id { get; set; }

    public int FlowId { get; set; }

    public int Uid { get; set; }

    public DateTime? CreateTime { get; set; }
}
