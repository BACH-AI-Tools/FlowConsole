using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TQuestionnaire
{
    public int QuestionnaireId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    public int? IsDeleted { get; set; }
}
