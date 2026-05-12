using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TPlatform
{
    public int PlatformId { get; set; }

    public string? Name { get; set; }

    public string? LogoUrl { get; set; }

    public int? OrderIndex { get; set; }
}
