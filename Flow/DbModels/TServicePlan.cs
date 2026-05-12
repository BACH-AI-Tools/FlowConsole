using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TServicePlan
{
    public int ServicePlanId { get; set; }

    public string? Name { get; set; }

    public int? WordCount { get; set; }

    public int? ComposeCount { get; set; }

    public string? Description { get; set; }

    public string? PlanType { get; set; }

    public string? MembershipCode { get; set; }

    public decimal? Price { get; set; }

    public string? SalesProgram { get; set; }

    public int? EffectiveMonth { get; set; }

    public float? ResellerLv1RebateRate { get; set; }

    public float? ResellerLv2RebateRate { get; set; }
}
