using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TUserMembership
{
    public int Uid { get; set; }

    public string? MembershipCode { get; set; }

    public string? MembershipName { get; set; }

    public int? MembershipLevel { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public DateTime? ExpiredDate { get; set; }

    public int? QuotaWord { get; set; }

    public int? QuotaCompose { get; set; }

    public int? UsedWord { get; set; }

    public int? UsedCompose { get; set; }
}
