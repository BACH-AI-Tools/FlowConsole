using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TNotification
{
    public int NotificationId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public DateTime? ExpiredDate { get; set; }

    public int? IsDisabled { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }
}
