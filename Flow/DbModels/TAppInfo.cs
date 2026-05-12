using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TAppInfo
{
    public string AppCode { get; set; } = null!;

    public string? AppName { get; set; }

    /// <summary>
    /// Consumer 后跳到网站主页
    /// </summary>
    public string? RedirectUrl { get; set; }

    /// <summary>
    /// 跳到微信的鉴权页面
    /// </summary>
    public string? WxcomRedirectUrl { get; set; }

    public string? Logo { get; set; }

    public virtual ICollection<TAppInfoUserGroup> TAppInfoUserGroups { get; set; } = new List<TAppInfoUserGroup>();
}
