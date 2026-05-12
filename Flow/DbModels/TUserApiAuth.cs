using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TUserApiAuth
{
    public int Uid { get; set; }

    public string AppCode { get; set; } = null!;

    public string AppSecret { get; set; } = null!;

    public int ExpirationTime { get; set; }
}
