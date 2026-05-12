using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 对话技能绑定关联表
/// </summary>
public partial class TConversationPlugin
{
    public int Id { get; set; }

    public string ConversationId { get; set; } = null!;

    public int PluginId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }
}
