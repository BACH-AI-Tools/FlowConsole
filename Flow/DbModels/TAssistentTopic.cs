using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TAssistentTopic
{
    public int AssistentTopicId { get; set; }

    public int? Uid { get; set; }

    /// <summary>
    /// 助理模型
    /// </summary>
    public int? AssistentLibraryId { get; set; }

    /// <summary>
    /// 话题
    /// </summary>
    public string? Topic { get; set; }

    /// <summary>
    /// 文档库ID
    /// </summary>
    public string? KnowledgeBaseId { get; set; }

    /// <summary>
    /// 文档库ID
    /// </summary>
    public string? KnowledgeBaseId2 { get; set; }

    /// <summary>
    /// 文档库ID
    /// </summary>
    public string? KnowledgeBaseId3 { get; set; }

    /// <summary>
    /// plugin id
    /// </summary>
    public string? Plugin { get; set; }

    /// <summary>
    /// plugin id
    /// </summary>
    public string? Plugin2 { get; set; }

    /// <summary>
    /// plugin id
    /// </summary>
    public string? Plugin3 { get; set; }

    /// <summary>
    /// 问卷ID
    /// </summary>
    public int? QuestionnaireId { get; set; }

    /// <summary>
    /// 温度
    /// </summary>
    public float? Temperature { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// 顺序
    /// </summary>
    public int? OrderIndex { get; set; }

    /// <summary>
    /// 当前系统消息
    /// </summary>
    public string? CurrentSystemMessage { get; set; }

    public int? IsDisabled { get; set; }

    public int? IsAccecptQuestionaire { get; set; }

    /// <summary>
    /// 会话头像
    /// </summary>
    public string? TopicLogo { get; set; }
}
