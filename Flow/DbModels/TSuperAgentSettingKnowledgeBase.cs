using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentSettingKnowledgeBase
{
    public int SuperAgentSettingKnowledgeBaseId { get; set; }

    public int? SuperAgentSettingId { get; set; }

    public string? KnowledgeBaseId { get; set; }

    public string? KnowledgeBaseName { get; set; }

    public string? KnowledgeBaseDescription { get; set; }

    public string? KnowledgeBaseLogo { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    /// <summary>
    /// 知识库检索策略id
    /// </summary>
    public string? KnowledgeBaseSearchPolicyId { get; set; }
}
