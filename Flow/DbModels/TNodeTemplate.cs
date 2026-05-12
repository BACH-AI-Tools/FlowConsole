using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TNodeTemplate
{
    public int NodeTemplateId { get; set; }

    public int? NodeType { get; set; }

    public int? ProductCategoryId { get; set; }

    public int? PointOrderIndex { get; set; }

    public int? PurposeId { get; set; }

    public int IsSystem { get; set; }

    public string? Point { get; set; }

    public string? PointDescription { get; set; }

    public int? LearningId { get; set; }

    public DateTime? EffectiveTime { get; set; }

    public DateTime? ExpiredTime { get; set; }

    public string? Filters { get; set; }

    public int? IsDisabled { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateOn { get; set; }

    public int? LastUpdateBy { get; set; }

    public string? LastUpdateByName { get; set; }
}
