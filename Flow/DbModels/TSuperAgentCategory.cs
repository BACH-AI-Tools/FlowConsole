using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentCategory
{
    public int SuperAgentCategoryId { get; set; }

    /// <summary>
    /// 代码号
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    public string? DisplayName { get; set; }

    public string? Name { get; set; }

    /// <summary>
    /// 分区，1=agent,2=plugin,3=ai小程序,4=知识库,5=管理标签,6=文档标签；7：用户反馈标签；8：敏感词；
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public string? Category { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int? Sort { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Description { get; set; }

    public virtual ICollection<TAppInfoUserGroup> TAppInfoUserGroups { get; set; } = new List<TAppInfoUserGroup>();
}
