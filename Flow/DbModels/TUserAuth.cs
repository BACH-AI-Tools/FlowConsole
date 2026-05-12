using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TUserAuth
{
    /// <summary>
    /// 标识
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 内部用户编号
    /// </summary>
    public int? Uid { get; set; }

    /// <summary>
    /// 登录类型：bayer microsoft auth;
    /// </summary>
    public string? IdentityType { get; set; }

    /// <summary>
    /// 标识 (手机号/邮箱/用户名或第三方应用的唯一标识) 
    /// bayer cwid
    /// </summary>
    public string? Identifier { get; set; }

    /// <summary>
    /// 密码凭证 (站内的保存密码 , 站外的不保存或保存 token)
    /// </summary>
    public string? Credential { get; set; }

    /// <summary>
    /// 新建时间
    /// </summary>
    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }

    public virtual TUser? UidNavigation { get; set; }
}
