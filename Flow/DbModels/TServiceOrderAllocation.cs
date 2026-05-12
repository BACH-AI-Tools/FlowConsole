using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TServiceOrderAllocation
{
    public int ServiceOrderAllocationId { get; set; }

    public int? ServiceOrderId { get; set; }

    public string? Phone { get; set; }

    public int? Uid { get; set; }

    public int? Count { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }
}
