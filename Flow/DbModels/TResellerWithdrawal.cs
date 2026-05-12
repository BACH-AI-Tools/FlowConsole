using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TResellerWithdrawal
{
    public int ResellerWithdrawalId { get; set; }

    public string? WithdrawalOrderNumber { get; set; }

    public int? WithdrawalPaymentStatus { get; set; }

    public float? WithdrawalTotalAmount { get; set; }

    public string? Comments { get; set; }

    public DateTime? CreatedTime { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }
}
