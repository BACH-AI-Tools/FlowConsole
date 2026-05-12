using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TProduct
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public int? ProductCategoryId { get; set; }

    public string? Price { get; set; }

    public string? ProductLine { get; set; }

    public string? Brand { get; set; }

    public string? TargetUser { get; set; }

    public string? ProductSummary { get; set; }

    public int? IsAnalysised { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }
}
