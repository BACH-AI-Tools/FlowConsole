using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TMembershipLevel
{
    public int MembershipLevelId { get; set; }

    public string? Name { get; set; }

    public string? MembershipCode { get; set; }

    public int? Level { get; set; }
}
