using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TUserLoginHistory
{
    public int UserLoginHistoryId { get; set; }

    public string? Uid { get; set; }

    public string? Name { get; set; }

    public string? LoginIp { get; set; }

    public DateTime? LoginTime { get; set; }
}
