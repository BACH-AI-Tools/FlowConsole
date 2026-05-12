using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TServiceOrder
{
    public int ServiceOrderId { get; set; }

    public int? Uid { get; set; }

    public int? ServicePlanId { get; set; }

    public int? ServicePlanCount { get; set; }

    public string? OrderNumber { get; set; }

    public string? OrderChannel { get; set; }

    public int? OrderStatus { get; set; }

    public string? PaymentLastError { get; set; }

    public int? IsDisabled { get; set; }

    public string? Remark { get; set; }

    public float? TotalOrderAmount { get; set; }

    public int? TotalOrderWordQuota { get; set; }

    public int? TotalOrderComposeQuota { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }
}
