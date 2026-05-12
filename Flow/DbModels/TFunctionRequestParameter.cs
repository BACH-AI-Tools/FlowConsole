using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TFunctionRequestParameter
{
    public int Id { get; set; }

    public int? FunctionId { get; set; }

    public string? Name { get; set; }

    public string? Variable { get; set; }

    public string? VariableType { get; set; }

    public int? Height { get; set; }

    public int? Step { get; set; }

    public string? StepName { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public string? Type { get; set; }

    public virtual TFunction? Function { get; set; }
}
