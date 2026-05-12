using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TUserOutline
{
    public int UserOutlineId { get; set; }

    public int? ProductCategoryId { get; set; }

    public int? PurposeId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateOn { get; set; }
}
