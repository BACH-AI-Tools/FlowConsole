using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TBachApiSet
{
    public string Id { get; set; } = null!;

    public string PathUrl { get; set; } = null!;

    public string Method { get; set; } = null!;

    public string? Controller { get; set; }

    public string? Summary { get; set; }

    public string? Description { get; set; }

    public bool IsApiUser { get; set; }
}
