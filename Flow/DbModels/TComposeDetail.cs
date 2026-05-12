using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TComposeDetail
{
    public int ComposeDetailId { get; set; }

    public int ComposeId { get; set; }

    public int? NodeTemplateId { get; set; }

    public string? NodeName { get; set; }

    public string? NodeDescription { get; set; }

    public int? PersonalityId { get; set; }

    public string? Features { get; set; }

    public int? PreferGeneratedLength { get; set; }

    public string? GeneratedContent { get; set; }

    public int? GenerateCount { get; set; }

    public int? OrderIndex { get; set; }

    public int? ParentComposeDetailId { get; set; }
}
