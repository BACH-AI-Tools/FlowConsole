using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TInvitation
{
    public int InvitationId { get; set; }

    public string? Code { get; set; }

    public string? Channel { get; set; }

    public int? LimitedCount { get; set; }
}
