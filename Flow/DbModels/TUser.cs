using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TUser
{
    public int Uid { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? IsAdmin { get; set; }

    public int? IsDisabled { get; set; }

    public string? InvitationCode { get; set; }

    public int? IsLv1Reseller { get; set; }

    public int? IsLv2Reseller { get; set; }

    public string? MyInvitationCode { get; set; }

    public int? InvitedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastLoginTime { get; set; }

    public int? IsCreator { get; set; }

    public string? Logo { get; set; }

    public string? UserCode { get; set; }

    public string? TimeFormat { get; set; }

    public bool IsApiUser { get; set; }

    /// <summary>
    /// 企业微信用户ID
    /// </summary>
    public string? CropUserId { get; set; }

    /// <summary>
    /// 组织/机构
    /// </summary>
    public string? Organization { get; set; }

    /// <summary>
    /// 部门编码
    /// </summary>
    public string? DepartmentCode { get; set; }

    /// <summary>
    /// 上次同步时间
    /// </summary>
    public DateTime? LastSyncTime { get; set; }

    /// <summary>
    /// 账号
    /// </summary>
    public string? Account { get; set; }

    public virtual ICollection<TUserAuth> TUserAuths { get; set; } = new List<TUserAuth>();
}
