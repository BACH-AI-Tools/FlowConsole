using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TPromptHistory
{
    public int PromptHistoryId { get; set; }

    public string? Prompt { get; set; }

    public string? Response { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }
}
