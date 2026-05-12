using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TMembershipBenefit
{
    public int MembershipBenefitId { get; set; }

    public string? Name { get; set; }

    public string? MembershipCode { get; set; }

    public string? BenefitCode { get; set; }

    public string? Description { get; set; }
}
