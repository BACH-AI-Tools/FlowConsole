using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TAuthLoginCategory
{
    /// <summary>
    /// 1:saml 2:ldap 3:phone 4:email
    /// </summary>
    public int AuthType { get; set; }

    /// <summary>
    /// 提供平台 1：microsoft 2：google
    /// </summary>
    public int? AuthProvider { get; set; }

    /// <summary>
    /// 是否需要配置
    /// </summary>
    public bool IsConfig { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public bool IsEnable { get; set; }

    public string Description { get; set; } = null!;

    public DateTime? CreateTime { get; set; }
}
