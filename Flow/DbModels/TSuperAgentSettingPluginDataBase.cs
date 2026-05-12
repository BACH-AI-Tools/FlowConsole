using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 数据库插件当前数据库的信息
/// </summary>
public partial class TSuperAgentSettingPluginDataBase
{
    public int SuperAgentSettingPluginDataBaseId { get; set; }

    /// <summary>
    /// 智能体id
    /// </summary>
    public int? SuperAgentSettingId { get; set; }

    /// <summary>
    /// 插件id
    /// </summary>
    public int? PluginId { get; set; }

    /// <summary>
    /// 数据库id
    /// </summary>
    public int? DataBaseId { get; set; }

    /// <summary>
    /// 意图id
    /// </summary>
    public int? IntentionId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }
}
