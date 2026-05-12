using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 助理的快捷指令
/// </summary>
public partial class TSuperAgentSettingQuickInstruction
{
    public int SuperAgentSettingQuickInstructionId { get; set; }

    public int SuperAgentSettingId { get; set; }

    /// <summary>
    /// 快捷指令名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 快捷指令类型：1=快速输入，2=AI小程序
    /// </summary>
    public int? Type { get; set; }

    /// <summary>
    /// 快捷输入内容
    /// </summary>
    public string? QuickInputContent { get; set; }

    public int? FlowId { get; set; }

    /// <summary>
    /// 小程序的第一步的输入卡片
    /// </summary>
    public string? FlowCard { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }
}
