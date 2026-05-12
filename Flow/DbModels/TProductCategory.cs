using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TProductCategory
{
    public int ProductCategoryId { get; set; }

    public int? ParentProductCategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Cluster { get; set; }

    public int IsDisabled { get; set; }
}
