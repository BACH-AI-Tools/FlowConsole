using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TLanguage
{
    public int LanguageId { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }

    public string? OrderIndex { get; set; }

    public string? LogoUrl { get; set; }
}
