using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TUserOutlineDetail
{
    public int UserOutlineDetailId { get; set; }

    public int? UserOutlineId { get; set; }

    public int? NodeTemplateId { get; set; }

    public string? Features { get; set; }

    public int? OrderIndex { get; set; }
}
