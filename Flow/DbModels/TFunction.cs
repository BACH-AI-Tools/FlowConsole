using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TFunction
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Prompt { get; set; }

    public int? Step { get; set; }

    public string? Module { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public int? Uid { get; set; }

    public virtual ICollection<TFunctionPromptExecution> TFunctionPromptExecutions { get; set; } = new List<TFunctionPromptExecution>();

    public virtual ICollection<TFunctionRequestParameter> TFunctionRequestParameters { get; set; } = new List<TFunctionRequestParameter>();

    public virtual ICollection<TFunctionResponseParameter> TFunctionResponseParameters { get; set; } = new List<TFunctionResponseParameter>();
}
