using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TCompose
{
    public int ComposeId { get; set; }

    public int? ProductCategoryId { get; set; }

    public int? ProductId { get; set; }

    public int? PurposeId { get; set; }

    public int? PersonalityId { get; set; }

    public int? PlatformId { get; set; }

    public int? LanguageId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Title { get; set; }

    public string? FinnalContent { get; set; }

    public int? ComposeStatus { get; set; }

    public int? ConsumedOrderId { get; set; }

    public string? KnowledgeBaseId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }
}
