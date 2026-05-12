using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentSettingVariableExample
{
    public int Id { get; set; }

    public int SuperAgentSettingVariableId { get; set; }

    /// <summary>
    /// 样例内容
    /// </summary>
    public string ExampleContent { get; set; } = null!;

    public DateTime? CreatedTime { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public int? UpdateBy { get; set; }

    public int? Sort { get; set; }

    public virtual TSuperAgentSettingVariable SuperAgentSettingVariable { get; set; } = null!;
}
