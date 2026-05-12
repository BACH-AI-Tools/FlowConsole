using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// API日志表
/// </summary>
public partial class TFlowApiLog
{
    /// <summary>
    /// 主键
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// 1=SSE,2=CALLBACK
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// 推送地址
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// POST,GET
    /// </summary>
    public string? Method { get; set; }

    /// <summary>
    /// 请求参数
    /// </summary>
    public string? RequestParam { get; set; }

    /// <summary>
    /// 返回参数
    /// </summary>
    public string? ResponseParam { get; set; }

    /// <summary>
    /// 状态码
    /// </summary>
    public string? HttpStatus { get; set; }

    /// <summary>
    /// 1：成功  2：失败
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// 失败原因
    /// </summary>
    public string? Error { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
}
