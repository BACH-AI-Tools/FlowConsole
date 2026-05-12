using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 小程序定时任务表
/// </summary>
public partial class TMinProgramScheduledTask
{
    public string Id { get; set; } = null!;

    /// <summary>
    /// 定时任务名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 所属小程序会话id
    /// </summary>
    public string? MinProgramManuallyId { get; set; }

    public int? FlowId { get; set; }

    /// <summary>
    /// 重复规则，0=每天某个时间点，1=每隔几个小时
    /// </summary>
    public int? RepeatType { get; set; }

    /// <summary>
    /// 重复规则内容
    /// </summary>
    public string? RepeatContent { get; set; }

    /// <summary>
    /// 重复结束时间
    /// </summary>
    public DateTime? EndTime { get; set; }

    /// <summary>
    /// 小程序第一步执行的参数
    /// </summary>
    public string? FirstStepParam { get; set; }

    /// <summary>
    /// 保存类型，0=保存到知识库，1=发送到会话
    /// </summary>
    public int? SaveType { get; set; }

    /// <summary>
    /// 保存内容
    /// </summary>
    public string? SaveContent { get; set; }

    /// <summary>
    /// 是否不再执行
    /// </summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// 创建人id
    /// </summary>
    public int? CreatedBy { get; set; }

    /// <summary>
    /// 创建人姓名
    /// </summary>
    public string? CreatedByName { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? LastUpdateTime { get; set; }

    public virtual TMinProgramSkillInfoManually? MinProgramManually { get; set; }
}
