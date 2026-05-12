using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TVrm
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Md5 { get; set; }

    public DateTime? CreateTime { get; set; }

    public string? FilePath { get; set; }

    public string? CoverPath { get; set; }

    public string? Voice { get; set; }
}
