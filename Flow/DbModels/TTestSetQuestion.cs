using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 测试集问题（考题）
/// </summary>
public partial class TTestSetQuestion
{
    /// <summary>
    /// 问题的唯一标识
    /// </summary>
    public string QuestionId { get; set; } = null!;

    /// <summary>
    /// 关联t_test_set表的id，用于确定所属的测试集
    /// </summary>
    public string TestSetId { get; set; } = null!;

    /// <summary>
    /// 问题
    /// </summary>
    public string Question { get; set; } = null!;

    /// <summary>
    /// 用于表示问题的顺序
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// 用于对问题进行分组归类
    /// </summary>
    public string Group { get; set; } = null!;

    /// <summary>
    /// 问题的详细解答内容
    /// </summary>
    public string? ForwardAnswer { get; set; }

    /// <summary>
    /// 1:可用 0：禁用
    /// </summary>
    public bool IsValid { get; set; }

    /// <summary>
    /// 评分标准提示词
    /// </summary>
    public string? ScoringCriteriaPrompt { get; set; }

    /// <summary>
    /// 满分
    /// </summary>
    public decimal? Score { get; set; }

    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 更新uid
    /// </summary>
    public string? UpdateUid { get; set; }

    /// <summary>
    /// 更新者名字
    /// </summary>
    public string? UpdateUserName { get; set; }

    /// <summary>
    /// 记录问题创建的时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 创建者uid
    /// </summary>
    public string? CreateUid { get; set; }

    /// <summary>
    /// 创建者名字
    /// </summary>
    public string? CreateUserName { get; set; }

    public virtual TTestSet TestSet { get; set; } = null!;
}
