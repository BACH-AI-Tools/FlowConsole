using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TAssistentLibrary
{
    public int AssistentLibraryId { get; set; }

    public string? Name { get; set; }

    public string? Logo { get; set; }

    public string? Description { get; set; }

    public string? PromptContent { get; set; }

    public string? Category { get; set; }

    /// <summary>
    /// contextfull,rag,plugin
    /// </summary>
    public string? AssistentCapbilityCategory { get; set; }

    public int? IsAdvancedAssistent { get; set; }

    public string? Tags { get; set; }

    public int? IsDeleted { get; set; }

    public string? Tips { get; set; }

    public string? SystemKeyValue { get; set; }

    public string? KnowledgeBaseId { get; set; }

    public string? SystemPromptContent { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }
}
