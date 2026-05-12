using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TMinProgramSkillInfoForResult
{
    public string Id { get; set; } = null!;

    public int FlowId { get; set; }

    /// <summary>
    /// 一次小程序执行唯一编号
    /// </summary>
    public string DialogId { get; set; } = null!;

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
    public string NodeId { get; set; } = null!;

    public string Result { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 1:for
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// 第几个for的内容
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// for内部返回节点值的类型 array&lt;string&gt;,array&lt;object&gt;,object,string
    /// </summary>
    public string ResultType { get; set; } = null!;

    /// <summary>
    /// for的返回类型array&lt;string&gt;,array&lt;object&gt;
    /// </summary>
    public string ForNodeResultType { get; set; } = null!;
}
