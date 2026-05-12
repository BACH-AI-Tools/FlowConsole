using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentTask
{
    public int TaskId { get; set; }

    public string? ConversationId { get; set; }

    public string? DialogId { get; set; }

    public int? TaskGeneration { get; set; }

    public string? TaskNumber { get; set; }

    public string? ParentTaskNumber { get; set; }

    /// <summary>
    /// 0: User , 1 Agent
    /// </summary>
    public int? TaskType { get; set; }

    public string? Objective { get; set; }

    public string? Task { get; set; }

    /// <summary>
    /// 0, Not Start, 1, Exectuing, 2 Complete
    /// </summary>
    public int? TaskStatus { get; set; }

    /// <summary>
    /// task owner
    /// </summary>
    public string? Owner { get; set; }

    public string? OwnerName { get; set; }

    public string? TaskResult { get; set; }

    public string? TaskResultFormatRequirement { get; set; }

    public string? TaskResultEvaluation { get; set; }

    public int? TaskResultQualityScore { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public int? IsDeleted { get; set; }

    public string? ResourceType { get; set; }

    public string? ResourceAction { get; set; }

    public string? ResourceId { get; set; }

    public string? ResourceName { get; set; }
}
