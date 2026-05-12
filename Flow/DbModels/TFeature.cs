using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TFeature
{
    public int FeatureId { get; set; }

    public int? NodeTemplateId { get; set; }

    public int? PurposeId { get; set; }

    public string? Feature { get; set; }

    public int? IsSystem { get; set; }

    public string? SourceType { get; set; }

    public int? SourceId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? LastModifyBy { get; set; }

    public DateTime? LastModifyOn { get; set; }
}
