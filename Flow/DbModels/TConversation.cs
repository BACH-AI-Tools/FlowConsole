using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TConversation
{
    public string ConversationId { get; set; } = null!;

    public string? ConversationName { get; set; }

    /// <summary>
    /// 0=normal,1=调试
    /// </summary>
    public int Type { get; set; }

    public int Uid { get; set; }

    /// <summary>
    /// 0: single conversion,1:group conversion
    /// </summary>
    public int? ConversationType { get; set; }

    /// <summary>
    /// 启用追问：0：不启用；1：启用；
    /// </summary>
    public bool? EnableFollowUpQuestions { get; set; }

    /// <summary>
    /// 会话头像
    /// </summary>
    public string? Logo { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    /// <summary>
    /// 平台：0：bach；1：oneapp；2：wecom
    /// </summary>
    public int? Platform { get; set; }

    /// <summary>
    /// 工作区ID
    /// </summary>
    public int WorkSpaceId { get; set; }

    /// <summary>
    /// 会话颜色
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// 是否置顶
    /// </summary>
    public bool IsPin { get; set; }

    /// <summary>
    /// 置顶时间
    /// </summary>
    public DateTime? PinTime { get; set; }

    /// <summary>
    /// 是否启用Canvas模式: 0=不启用, 1=启用
    /// </summary>
    public bool EnableCanvas { get; set; }

    public virtual ICollection<TConversationKnowledgebaseMapping> TConversationKnowledgebaseMappings { get; set; } = new List<TConversationKnowledgebaseMapping>();

    public virtual ICollection<TConversationSurvey> TConversationSurveys { get; set; } = new List<TConversationSurvey>();
}
