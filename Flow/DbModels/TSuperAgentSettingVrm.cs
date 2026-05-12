using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentSettingVrm
{
    public string Id { get; set; } = null!;

    public int SuperAgentSettingId { get; set; }

    /// <summary>
    /// 大模型技能 ：1 知识库查询结果的总结：2
    /// </summary>
    public string VrmId { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public int? Sort { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }
}
