using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TUserApiSet
{
    public string Id { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime? CreateTime { get; set; }

    public string ControllerName { get; set; } = null!;

    public string PathUrl { get; set; } = null!;

    public string BachApiSetId { get; set; } = null!;
}
