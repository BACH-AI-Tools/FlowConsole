using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 企业微信内部app的信息
/// </summary>
public partial class TCropAppInfo
{
    /// <summary>
    /// 企业微信app的编号
    /// </summary>
    public string Agentid { get; set; } = null!;

    /// <summary>
    /// app唯一的key
    /// </summary>
    public string AppKey { get; set; } = null!;

    /// <summary>
    /// api接受消息的token,企业微信自动生成(加密）
    /// </summary>
    public string? Token { get; set; }

    /// <summary>
    /// api接受消息的EncodingAESKey,企业微信自动生成（加密)
    /// </summary>
    public string? EncodingAesKey { get; set; }

    /// <summary>
    /// 描述信息
    /// </summary>
    public string? Description { get; set; }

    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// app_secret
    /// </summary>
    public string? AppSecret { get; set; }

    /// <summary>
    /// 1 上海锦得如
    /// </summary>
    public int Type { get; set; }
}
