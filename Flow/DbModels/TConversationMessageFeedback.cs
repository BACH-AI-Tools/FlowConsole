using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TConversationMessageFeedback
{
    public int Id { get; set; }

    public int Uid { get; set; }

    public int ConversationMessageId { get; set; }

    public string ConversationDialogId { get; set; } = null!;

    public string? ConversationId { get; set; }

    /// <summary>
    /// 0=踩，1=赞
    /// </summary>
    public bool Category { get; set; }

    /// <summary>
    /// 反馈内容(标签)
    /// </summary>
    public string? FeedBackContent { get; set; }

    /// <summary>
    /// 原因/期望的结果
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// 智能体id
    /// </summary>
    public int? AgentId { get; set; }

    /// <summary>
    /// 智能体名称
    /// </summary>
    public string? AgentName { get; set; }

    /// <summary>
    /// 智能体技能
    /// </summary>
    public string? AgentSkill { get; set; }

    /// <summary>
    /// 智能体模型
    /// </summary>
    public string? AgentLlmConfig { get; set; }

    /// <summary>
    /// 知识库(个人关联文档)
    /// </summary>
    public string? KnowledgeBase { get; set; }

    /// <summary>
    /// 反馈时技能(对应的plugin,知识库，gpt兜底)
    /// </summary>
    public string? FeedBackSkill { get; set; }

    /// <summary>
    /// 对话上下文(前10条)
    /// </summary>
    public string? ConversationContext { get; set; }

    /// <summary>
    /// 智能体提示词(前10条)
    /// </summary>
    public string? AgentPrompt { get; set; }

    /// <summary>
    /// 反馈处理意图理解
    /// </summary>
    public string? IntentionUnderstanding { get; set; }

    /// <summary>
    /// 反馈处理生成内容
    /// </summary>
    public string? GeneratedContent { get; set; }

    /// <summary>
    /// 反馈处理备注
    /// </summary>
    public string? HandleRemark { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 原始prompt
    /// </summary>
    public string? OriginalPrompt { get; set; }

    /// <summary>
    /// 智能体创作用户id
    /// </summary>
    public int? AgentCreatorId { get; set; }

    public string? Error { get; set; }
}
