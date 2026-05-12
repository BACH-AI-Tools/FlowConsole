using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TSuperAgentSetting
{
    public int SuperAgentSettingId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Logo { get; set; }

    public string? SystemMessage { get; set; }

    public decimal? Temperature { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    public int? SuperAgentCategoryId { get; set; }

    public string? UserTag { get; set; }

    public string? WelcomeMessage { get; set; }

    /// <summary>
    /// 0:未发布；1：已发布；
    /// </summary>
    public bool? IsPublish { get; set; }

    /// <summary>
    /// 使用次数
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// 允许上传临时文档；0：不允许；1：允许；
    /// </summary>
    public bool? IsAllowUploadTempDocument { get; set; }

    /// <summary>
    /// 是否运行会话绑定个人知识库 0: 不允许 1： 运行
    /// </summary>
    public bool? IsAllowAttachPrivateKnowledgeBase { get; set; }

    /// <summary>
    /// 启用追问：0：不启用；1：启用；
    /// </summary>
    public bool? EnableFollowUpQuestions { get; set; }

    /// <summary>
    /// 选中知识库文档后，是否必定跟文档对话；0：否（走意图判断）；1：是
    /// </summary>
    public bool? IsSelectKnowledgeMustChatDoc { get; set; }

    /// <summary>
    /// 无引用资料的时候是否使用ai兜底
    /// </summary>
    public bool? UseFallbackAi { get; set; }

    /// <summary>
    /// 有没有发布api
    /// </summary>
    public bool IsPublishApi { get; set; }

    /// <summary>
    /// 启用3d虚拟人
    /// </summary>
    public bool? EnableVrm { get; set; }

    /// <summary>
    /// 最后修改人id
    /// </summary>
    public int? LastUpdateBy { get; set; }

    /// <summary>
    /// 发送历史（问题的top3）
    /// </summary>
    public bool? SendHistory { get; set; }

    /// <summary>
    /// 上下文轮数
    /// </summary>
    public int? HistoryCount { get; set; }

    /// <summary>
    /// agent类型；0：bach agent；1：founry agent
    /// </summary>
    public int? Category { get; set; }

    public bool IsRecommended { get; set; }

    public virtual ICollection<TSuperAgentQuickCommand> TSuperAgentQuickCommands { get; set; } = new List<TSuperAgentQuickCommand>();

    public virtual ICollection<TSuperAgentRelease> TSuperAgentReleases { get; set; } = new List<TSuperAgentRelease>();

    public virtual ICollection<TSuperAgentSettingVariable> TSuperAgentSettingVariables { get; set; } = new List<TSuperAgentSettingVariable>();
}
