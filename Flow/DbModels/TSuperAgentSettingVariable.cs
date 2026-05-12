using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentSettingVariable
{
    public int Id { get; set; }

    public int SuperAgentSettingId { get; set; }

    /// <summary>
    /// 变量名称
    /// </summary>
    public string VariableName { get; set; } = null!;

    /// <summary>
    /// 变量描述
    /// </summary>
    public string VariableDescription { get; set; } = null!;

    public DateTime? CreatedTime { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public int? UpdateBy { get; set; }

    public int? Sort { get; set; }

    public virtual TSuperAgentSetting SuperAgentSetting { get; set; } = null!;

    public virtual ICollection<TSuperAgentSettingVariableExample> TSuperAgentSettingVariableExamples { get; set; } = new List<TSuperAgentSettingVariableExample>();
}
