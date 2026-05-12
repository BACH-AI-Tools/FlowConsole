using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 秘钥信息表
/// </summary>
public partial class TSecretInfo
{
    /// <summary>
    /// 主键
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// 系统名称
    /// </summary>
    public string SystemName { get; set; } = null!;

    /// <summary>
    /// 秘钥名称
    /// </summary>
    public string SecretKey { get; set; } = null!;

    /// <summary>
    /// 秘钥值(加密后的内容)
    /// </summary>
    public string SecretValue { get; set; } = null!;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime UpdateTime { get; set; }
}
