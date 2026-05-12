using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TConsumption
{
    public int ConsumptionId { get; set; }

    public int? ComposeId { get; set; }

    public int? NodeTemplateId { get; set; }

    public int? Uid { get; set; }

    public string? Name { get; set; }

    public int? Action { get; set; }

    public int? WordCount { get; set; }

    public DateTime? CreatedOn { get; set; }
}
