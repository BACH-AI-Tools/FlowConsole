using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TLlmConfig
{
    public int LlmConfigId { get; set; }

    /// <summary>
    /// 接入点名字
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 类型 0=Completion,1=Embedding,2=text_to_image
    /// </summary>
    public int LlmType { get; set; }

    /// <summary>
    /// 供应商
    /// 
    /// </summary>
    public int Provider { get; set; }

    public string Endpoint { get; set; } = null!;

    public string? Deployment { get; set; }

    /// <summary>
    /// 模型
    /// 
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// 钥匙
    /// </summary>
    public string? Key { get; set; }

    public string? TenantId { get; set; }

    public string? ClientId { get; set; }

    public string? ClientSecret { get; set; }
}
