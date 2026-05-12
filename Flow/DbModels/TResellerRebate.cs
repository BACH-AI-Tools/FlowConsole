using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TResellerRebate
{
    public int ResellerRebateId { get; set; }

    public int? ServiceOrderId { get; set; }

    public float? ServiceOrderPaidAmount { get; set; }

    public int? ResellerUid { get; set; }

    public float? RebateRate { get; set; }

    public float? RebateAmount { get; set; }

    public DateTime? CreatedTime { get; set; }

    public int? WithdrawalStatus { get; set; }

    public string? WithdrawalOrderNumber { get; set; }
}
