using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TLearning
{
    public int LearningId { get; set; }

    public int ProductCategoryId { get; set; }

    public int? PurposeId { get; set; }

    public string? Name { get; set; }

    public string? Brand { get; set; }

    public string? Content { get; set; }

    public int? IsSystem { get; set; }

    public string? LearningResult { get; set; }

    public string? LearningStatus { get; set; }

    public string? LearningMessage { get; set; }

    public string? KnowledgeBaseId { get; set; }

    public string? DocumentId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }
}
