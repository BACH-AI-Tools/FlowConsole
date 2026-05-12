using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 环境变量配置表（企业配置）
/// </summary>
public partial class TEnvironmentVariable
{
    /// <summary>
    /// 主键ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 企业域名
    /// </summary>
    public string? Host { get; set; }

    /// <summary>
    /// 浅色Logo URL
    /// </summary>
    public string? LightLogo { get; set; }

    /// <summary>
    /// 深色Logo URL
    /// </summary>
    public string? DarkLogo { get; set; }

    /// <summary>
    /// 站点标题
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }
}
