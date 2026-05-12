using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 
/// 小程序执行的步骤
/// </summary>
public partial class TMinProgramSkillInfo
{
    public string Id { get; set; } = null!;

    public int FlowId { get; set; }

    /// <summary>
    /// 一次小程序执行唯一编号
    /// </summary>
    public string DialogId { get; set; } = null!;

    public string? ConversationId { get; set; }

    public int Step { get; set; }

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

    public bool IsFinish { get; set; }

    /// <summary>
    /// node_id
    /// </summary>
    public string? NodeId { get; set; }

    /// <summary>
    /// 执行的值
    /// 0 for节点之外的，包含for
    /// 1 for节点之内的，不包含for
    /// </summary>
    public int Index { get; set; }

    public string? Version { get; set; }

    /// <summary>
    /// for的groupid，保证for内部index内的结果互不影响
    /// </summary>
    public string? ForGroupId { get; set; }

    /// <summary>
    /// 自关联，如果执行的是子流程，这里记录的是调用子流程的主流程小程序的id
    /// </summary>
    public string? MainProcessId { get; set; }

    /// <summary>
    /// 主流程的dialog_id
    /// </summary>
    public string? MainDialogId { get; set; }

    /// <summary>
    /// 节点消耗时间
    /// </summary>
    public decimal? TimeConsuming { get; set; }

    public virtual ICollection<TMinProgramSkillInfoParam> TMinProgramSkillInfoParams { get; set; } = new List<TMinProgramSkillInfoParam>();
}
