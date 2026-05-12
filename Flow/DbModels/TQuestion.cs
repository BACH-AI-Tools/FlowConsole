using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TQuestion
{
    public int QuestionId { get; set; }

    public int? QuestionnaireId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? OrderIndex { get; set; }

    public int? IsDeleted { get; set; }
}
