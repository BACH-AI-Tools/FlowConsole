using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TMinProgramSkillRunInfoV5
{
    public string Id { get; set; } = null!;

    public int FlowId { get; set; }

    /// <summary>
    /// 一次小程序执行唯一编号
    /// </summary>
    public string DialogId { get; set; } = null!;

    public string? ConversationId { get; set; }

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

    /// <summary>
    /// node_id
    /// </summary>
    public string? NodeId { get; set; }

    /// <summary>
    /// node名字
    /// </summary>
    public string? NodeName { get; set; }

    /// <summary>
    /// for的groupid，保证for内部index内的结果互不影响
    /// </summary>
    public string? ForGroupId { get; set; }

    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 是否跑过
    /// </summary>
    public bool IsRuned { get; set; }

    /// <summary>
    /// node的类型
    /// </summary>
    public string NodeType { get; set; } = null!;

    /// <summary>
    /// 每一步，block里面从1开始
    /// </summary>
    public int Step { get; set; }

    /// <summary>
    /// 自建ID，对应此表的id，只有for node 才有
    /// </summary>
    public string? BlockNodeId { get; set; }

    /// <summary>
    /// for的index
    /// </summary>
    public int? BlockIndex { get; set; }
}
