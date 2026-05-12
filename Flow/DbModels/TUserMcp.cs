using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TUserMcp
{
    public int Uid { get; set; }

    public string UserCode { get; set; } = null!;

    public string UserKongAuthKey { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public DateTime UpdateTime { get; set; }
}
