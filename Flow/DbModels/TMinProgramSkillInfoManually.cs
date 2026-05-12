using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 小程序手动执行的flow记录，
/// 执行步骤在t_min_program_skill_info，这里只记录列表
/// </summary>
public partial class TMinProgramSkillInfoManually
{
    public string Id { get; set; } = null!;

    public int FlowId { get; set; }

    /// <summary>
    /// 一次小程序执行唯一编号
    /// </summary>
    public string FlowName { get; set; } = null!;

    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// 用户id
    /// </summary>
    public string FromId { get; set; } = null!;

    /// <summary>
    /// 调用类型
    ///  /// &lt;summary&gt;
    ///       /// 会话
    ///       /// &lt;/summary&gt;
    ///       Conversation = 1,
    /// 
    ///       /// &lt;summary&gt;
    ///       /// AI小程序单独执行
    ///       /// &lt;/summary&gt;
    ///       SingleAI=2,
    /// 
    ///       /// &lt;summary&gt;
    ///       /// AI小程序测试
    ///       /// &lt;/summary&gt;
    ///       AITest=3,
    /// </summary>
    public int InvodeType { get; set; }

    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 工作区ID
    /// </summary>
    public int WorkSpaceId { get; set; }

    /// <summary>
    /// 背景颜色
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// 是否置顶
    /// </summary>
    public bool IsPin { get; set; }

    /// <summary>
    /// 置顶时间
    /// </summary>
    public DateTime? PinTime { get; set; }

    /// <summary>
    /// 用户端显示的小程序名称
    /// </summary>
    public string? ManuallyName { get; set; }

    public virtual ICollection<TMinProgramScheduledTask> TMinProgramScheduledTasks { get; set; } = new List<TMinProgramScheduledTask>();
}
