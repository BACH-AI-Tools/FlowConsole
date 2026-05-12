using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 小程序flowapi调用记录
/// </summary>
public partial class TMinProgramSkillInfoFlowApiInvokeRecordContext
{
    public string JobId { get; set; } = null!;

    /// <summary>
    /// 接口请求参数
    /// </summary>
    public string RequestParam { get; set; } = null!;

    /// <summary>
    /// 返回值
    /// </summary>
    public string? ResponseContext { get; set; }

    /// <summary>
    /// 小程序请求的值
    /// </summary>
    public string? MinniProgramProgram { get; set; }

    public virtual TMinProgramSkillInfoFlowApiInvokeRecord Job { get; set; } = null!;
}
