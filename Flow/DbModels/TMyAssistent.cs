using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TMyAssistent
{
    public int MyAssistentId { get; set; }

    public int? Uid { get; set; }

    public int? AssistentLibraryId { get; set; }

    public string? MyAssistentName { get; set; }

    public string? MyAssistentLogo { get; set; }

    public DateTime? CreatedOn { get; set; }
}
