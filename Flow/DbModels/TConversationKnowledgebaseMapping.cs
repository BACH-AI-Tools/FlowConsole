using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TConversationKnowledgebaseMapping
{
    public int ConversationKnowledgebaseMappingId { get; set; }

    public string? ConversationId { get; set; }

    public string? KnowledgeBaseId { get; set; }

    public int? Role { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime UpdateTime { get; set; }

    /// <summary>
    /// 是否启用：0：否；1：是；
    /// </summary>
    public bool? Enable { get; set; }

    /// <summary>
    /// 0：文本查询；1：表格查询
    /// </summary>
    public int? SearchCategory { get; set; }

    /// <summary>
    /// 选择条件：0：文件名；1标签；2：路径
    /// </summary>
    public int? SearchFilterSelect { get; set; }

    /// <summary>
    /// 条件内容，数组
    /// </summary>
    public string? SearchFilterValue { get; set; }

    /// <summary>
    /// 全选状态：0：否；1：是；
    /// </summary>
    public int? SelectedDocumentStatus { get; set; }

    /// <summary>
    /// 启用查询用的文档id数组
    /// </summary>
    public string? EnableDocumentIds { get; set; }

    /// <summary>
    /// 启用查询用的数据表id数组
    /// </summary>
    public string? EnableTableIds { get; set; }

    /// <summary>
    /// table选择条件：0：文件名；1标签；2：路径
    /// </summary>
    public int? SearchTableFilterSelect { get; set; }

    /// <summary>
    /// table条件内容，数组
    /// </summary>
    public string? SearchTableFilterValue { get; set; }

    /// <summary>
    /// 全选状态：0：否；1：是；
    /// </summary>
    public int? SelectedTableStatus { get; set; }

    public virtual TConversation? Conversation { get; set; }
}
