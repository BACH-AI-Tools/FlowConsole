using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TCrop
{
    public int Id { get; set; }

    public string AppId { get; set; } = null!;

    /// <summary>
    ///  1：虫虫 2：星火
    /// </summary>
    public int Type { get; set; }

    public string Description { get; set; } = null!;
}
