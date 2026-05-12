using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Flow.DbModels;

public partial class FlowDbContext : DbContext
{
    public FlowDbContext(DbContextOptions<FlowDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TAgentCallback> TAgentCallbacks { get; set; }

    public virtual DbSet<TAgentStatistic> TAgentStatistics { get; set; }

    public virtual DbSet<TAnswer> TAnswers { get; set; }

    public virtual DbSet<TAppInfo> TAppInfos { get; set; }

    public virtual DbSet<TAppInfoUserGroup> TAppInfoUserGroups { get; set; }

    public virtual DbSet<TApplicationSetting> TApplicationSettings { get; set; }

    public virtual DbSet<TAssistentLibrary> TAssistentLibraries { get; set; }

    public virtual DbSet<TAssistentTopic> TAssistentTopics { get; set; }

    public virtual DbSet<TAssistentTopicAgentConversionFlow> TAssistentTopicAgentConversionFlows { get; set; }

    public virtual DbSet<TAssistentTopicMessage> TAssistentTopicMessages { get; set; }

    public virtual DbSet<TAuthLoginCategory> TAuthLoginCategories { get; set; }

    public virtual DbSet<TAuthLoginConfig> TAuthLoginConfigs { get; set; }

    public virtual DbSet<TBachApiSet> TBachApiSets { get; set; }

    public virtual DbSet<TCompose> TComposes { get; set; }

    public virtual DbSet<TComposeDetail> TComposeDetails { get; set; }

    public virtual DbSet<TConsumption> TConsumptions { get; set; }

    public virtual DbSet<TConversation> TConversations { get; set; }

    public virtual DbSet<TConversationImage> TConversationImages { get; set; }

    public virtual DbSet<TConversationKnowledgebaseMapping> TConversationKnowledgebaseMappings { get; set; }

    public virtual DbSet<TConversationMessage> TConversationMessages { get; set; }

    public virtual DbSet<TConversationMessageAgent> TConversationMessageAgents { get; set; }

    public virtual DbSet<TConversationMessageFeedback> TConversationMessageFeedbacks { get; set; }

    public virtual DbSet<TConversationPlugin> TConversationPlugins { get; set; }

    public virtual DbSet<TConversationSuperAgent> TConversationSuperAgents { get; set; }

    public virtual DbSet<TConversationSuperAgentsSequence> TConversationSuperAgentsSequences { get; set; }

    public virtual DbSet<TConversationSurvey> TConversationSurveys { get; set; }

    public virtual DbSet<TCrop> TCrops { get; set; }

    public virtual DbSet<TCropAppInfo> TCropAppInfos { get; set; }

    public virtual DbSet<TCustomTag> TCustomTags { get; set; }

    public virtual DbSet<TDataAgent> TDataAgents { get; set; }

    public virtual DbSet<TDepartment> TDepartments { get; set; }

    public virtual DbSet<TEditorInfo> TEditorInfos { get; set; }

    public virtual DbSet<TEnterpriseInfo> TEnterpriseInfos { get; set; }

    public virtual DbSet<TEnvironmentVariable> TEnvironmentVariables { get; set; }

    public virtual DbSet<TFeature> TFeatures { get; set; }

    public virtual DbSet<TFlow> TFlows { get; set; }

    public virtual DbSet<TFlowApi> TFlowApis { get; set; }

    public virtual DbSet<TFlowApiLog> TFlowApiLogs { get; set; }

    public virtual DbSet<TFlowApiPublish> TFlowApiPublishes { get; set; }

    public virtual DbSet<TFlowEdge> TFlowEdges { get; set; }

    public virtual DbSet<TFlowExportInfo> TFlowExportInfos { get; set; }

    public virtual DbSet<TFlowLog> TFlowLogs { get; set; }

    public virtual DbSet<TFlowManageLable> TFlowManageLables { get; set; }

    public virtual DbSet<TFlowNode> TFlowNodes { get; set; }

    public virtual DbSet<TFlowNodeLog> TFlowNodeLogs { get; set; }

    public virtual DbSet<TFlowProcessInfo> TFlowProcessInfos { get; set; }

    public virtual DbSet<TFlowPublish> TFlowPublishes { get; set; }

    public virtual DbSet<TFlowVariable> TFlowVariables { get; set; }

    public virtual DbSet<TFunction> TFunctions { get; set; }

    public virtual DbSet<TFunctionPromptExecution> TFunctionPromptExecutions { get; set; }

    public virtual DbSet<TFunctionRequestParameter> TFunctionRequestParameters { get; set; }

    public virtual DbSet<TFunctionResponseParameter> TFunctionResponseParameters { get; set; }

    public virtual DbSet<TIntentionStatistic> TIntentionStatistics { get; set; }

    public virtual DbSet<TInvitation> TInvitations { get; set; }

    public virtual DbSet<TLanguage> TLanguages { get; set; }

    public virtual DbSet<TLearning> TLearnings { get; set; }

    public virtual DbSet<TLlmConfig> TLlmConfigs { get; set; }

    public virtual DbSet<TLlmGlobalVariable> TLlmGlobalVariables { get; set; }

    public virtual DbSet<TLlmModel> TLlmModels { get; set; }

    public virtual DbSet<TLlmModelPromotMapping> TLlmModelPromotMappings { get; set; }

    public virtual DbSet<TLlmPromptSetting> TLlmPromptSettings { get; set; }

    public virtual DbSet<TLlmSkLog> TLlmSkLogs { get; set; }

    public virtual DbSet<TLog> TLogs { get; set; }

    public virtual DbSet<TMembershipBenefit> TMembershipBenefits { get; set; }

    public virtual DbSet<TMembershipLevel> TMembershipLevels { get; set; }

    public virtual DbSet<TMessage> TMessages { get; set; }

    public virtual DbSet<TMessageTopic> TMessageTopics { get; set; }

    public virtual DbSet<TMinProgramScheduledTask> TMinProgramScheduledTasks { get; set; }

    public virtual DbSet<TMinProgramScheduledTaskRecord> TMinProgramScheduledTaskRecords { get; set; }

    public virtual DbSet<TMinProgramSkillInfo> TMinProgramSkillInfos { get; set; }

    public virtual DbSet<TMinProgramSkillInfoFlowApiInvokeRecord> TMinProgramSkillInfoFlowApiInvokeRecords { get; set; }

    public virtual DbSet<TMinProgramSkillInfoFlowApiInvokeRecordContext> TMinProgramSkillInfoFlowApiInvokeRecordContexts { get; set; }

    public virtual DbSet<TMinProgramSkillInfoForResult> TMinProgramSkillInfoForResults { get; set; }

    public virtual DbSet<TMinProgramSkillInfoManually> TMinProgramSkillInfoManuallies { get; set; }

    public virtual DbSet<TMinProgramSkillInfoManuallyDetail> TMinProgramSkillInfoManuallyDetails { get; set; }

    public virtual DbSet<TMinProgramSkillInfoParam> TMinProgramSkillInfoParams { get; set; }

    public virtual DbSet<TMinProgramSkillPathfindingArchive> TMinProgramSkillPathfindingArchives { get; set; }

    public virtual DbSet<TMinProgramSkillRunEdgeInfoV5> TMinProgramSkillRunEdgeInfoV5s { get; set; }

    public virtual DbSet<TMinProgramSkillRunInfoV5> TMinProgramSkillRunInfoV5s { get; set; }

    public virtual DbSet<TMyAssistent> TMyAssistents { get; set; }

    public virtual DbSet<TNodeTemplate> TNodeTemplates { get; set; }

    public virtual DbSet<TNotification> TNotifications { get; set; }

    public virtual DbSet<TOperationAuditLog> TOperationAuditLogs { get; set; }

    public virtual DbSet<TPersonality> TPersonalities { get; set; }

    public virtual DbSet<TPlatform> TPlatforms { get; set; }

    public virtual DbSet<TPlugin> TPlugins { get; set; }

    public virtual DbSet<TPluginCopy1> TPluginCopy1s { get; set; }

    public virtual DbSet<TProduct> TProducts { get; set; }

    public virtual DbSet<TProductCategory> TProductCategories { get; set; }

    public virtual DbSet<TPromptHistory> TPromptHistories { get; set; }

    public virtual DbSet<TPromptTemplateConfig> TPromptTemplateConfigs { get; set; }

    public virtual DbSet<TPurpose> TPurposes { get; set; }

    public virtual DbSet<TQuestion> TQuestions { get; set; }

    public virtual DbSet<TQuestionnaire> TQuestionnaires { get; set; }

    public virtual DbSet<TQuestionnaireFeedback> TQuestionnaireFeedbacks { get; set; }

    public virtual DbSet<TReptileAnalysis> TReptileAnalyses { get; set; }

    public virtual DbSet<TReptileAnalysisResult> TReptileAnalysisResults { get; set; }

    public virtual DbSet<TResellerRebate> TResellerRebates { get; set; }

    public virtual DbSet<TResellerWithdrawal> TResellerWithdrawals { get; set; }

    public virtual DbSet<TSecretInfo> TSecretInfos { get; set; }

    public virtual DbSet<TSensitiveWord> TSensitiveWords { get; set; }

    public virtual DbSet<TServiceOrder> TServiceOrders { get; set; }

    public virtual DbSet<TServiceOrderAllocation> TServiceOrderAllocations { get; set; }

    public virtual DbSet<TServicePlan> TServicePlans { get; set; }

    public virtual DbSet<TSuperAgentCategory> TSuperAgentCategories { get; set; }

    public virtual DbSet<TSuperAgentDepartmentMap> TSuperAgentDepartmentMaps { get; set; }

    public virtual DbSet<TSuperAgentFunctionCalling> TSuperAgentFunctionCallings { get; set; }

    public virtual DbSet<TSuperAgentManageLable> TSuperAgentManageLables { get; set; }

    public virtual DbSet<TSuperAgentQuickCommand> TSuperAgentQuickCommands { get; set; }

    public virtual DbSet<TSuperAgentRelease> TSuperAgentReleases { get; set; }

    public virtual DbSet<TSuperAgentSetting> TSuperAgentSettings { get; set; }

    public virtual DbSet<TSuperAgentSettingApiMessage> TSuperAgentSettingApiMessages { get; set; }

    public virtual DbSet<TSuperAgentSettingApiPublish> TSuperAgentSettingApiPublishes { get; set; }

    public virtual DbSet<TSuperAgentSettingCk> TSuperAgentSettingCks { get; set; }

    public virtual DbSet<TSuperAgentSettingFlow> TSuperAgentSettingFlows { get; set; }

    public virtual DbSet<TSuperAgentSettingKnowledgeBase> TSuperAgentSettingKnowledgeBases { get; set; }

    public virtual DbSet<TSuperAgentSettingLlm> TSuperAgentSettingLlms { get; set; }

    public virtual DbSet<TSuperAgentSettingOuter> TSuperAgentSettingOuters { get; set; }

    public virtual DbSet<TSuperAgentSettingPermission> TSuperAgentSettingPermissions { get; set; }

    public virtual DbSet<TSuperAgentSettingPlugin> TSuperAgentSettingPlugins { get; set; }

    public virtual DbSet<TSuperAgentSettingPluginDataBase> TSuperAgentSettingPluginDatabases { get; set; }

    public virtual DbSet<TSuperAgentSettingPluginDataBaseRelease> TSuperAgentSettingPluginDataBaseReleases { get; set; }

    public virtual DbSet<TSuperAgentSettingPresetQuestion> TSuperAgentSettingPresetQuestions { get; set; }

    public virtual DbSet<TSuperAgentSettingQuickInstruction> TSuperAgentSettingQuickInstructions { get; set; }

    public virtual DbSet<TSuperAgentSettingVariable> TSuperAgentSettingVariables { get; set; }

    public virtual DbSet<TSuperAgentSettingVariableExample> TSuperAgentSettingVariableExamples { get; set; }

    public virtual DbSet<TSuperAgentSettingVrm> TSuperAgentSettingVrms { get; set; }

    public virtual DbSet<TSuperAgentTask> TSuperAgentTasks { get; set; }

    public virtual DbSet<TSuperAgentTaskDocument> TSuperAgentTaskDocuments { get; set; }

    public virtual DbSet<TSuperAgentUserMap> TSuperAgentUserMaps { get; set; }

    public virtual DbSet<TTestManager> TTestManagers { get; set; }

    public virtual DbSet<TTestManagerObject> TTestManagerObjects { get; set; }

    public virtual DbSet<TTestRunTestInfoResult> TTestRunTestInfoResults { get; set; }

    public virtual DbSet<TTestSet> TTestSets { get; set; }

    public virtual DbSet<TTestSetQuestion> TTestSetQuestions { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    public virtual DbSet<TUserApiAuth> TUserApiAuths { get; set; }

    public virtual DbSet<TUserApiSet> TUserApiSets { get; set; }

    public virtual DbSet<TUserAuth> TUserAuths { get; set; }

    public virtual DbSet<TUserLoginHistory> TUserLoginHistories { get; set; }

    public virtual DbSet<TUserManageLable> TUserManageLables { get; set; }

    public virtual DbSet<TUserMcp> TUserMcps { get; set; }

    public virtual DbSet<TUserMembership> TUserMemberships { get; set; }

    public virtual DbSet<TUserOutline> TUserOutlines { get; set; }

    public virtual DbSet<TUserOutlineDetail> TUserOutlineDetails { get; set; }

    public virtual DbSet<TUserWorkSpace> TUserWorkSpaces { get; set; }

    public virtual DbSet<TVrm> TVrms { get; set; }

    public virtual DbSet<TempChunk> TempChunks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TAgentCallback>(entity =>
        {
            entity.ToTable("t_agent_callback");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasComment("入库时间")
                .HasColumnName("create_time");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Signature)
                .HasMaxLength(50)
                .HasColumnName("signature");
            entity.Property(e => e.Timestamp)
                .HasMaxLength(50)
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<TAgentStatistic>(entity =>
        {
            entity.ToTable("t_agent_statistics", tb => tb.HasComment("agent 各种统计表"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgentId).HasColumnName("agent_id");
            entity.Property(e => e.CreateOn)
                .HasComment("添加时间")
                .HasColumnName("create_on");
            entity.Property(e => e.Data)
                .HasComment("数据")
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("data");
            entity.Property(e => e.Time)
                .HasComment("时间")
                .HasColumnName("time");
            entity.Property(e => e.Type)
                .HasComment("类型")
                .HasColumnName("type");
        });

        modelBuilder.Entity<TAnswer>(entity =>
        {
            entity.HasKey(e => e.AnswerId);

            entity.ToTable("t_answer");

            entity.Property(e => e.AnswerId).HasColumnName("answer_id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.Sn)
                .HasMaxLength(10)
                .HasColumnName("sn");
        });

        modelBuilder.Entity<TAppInfo>(entity =>
        {
            entity.HasKey(e => e.AppCode);

            entity.ToTable("t_app_info");

            entity.Property(e => e.AppCode)
                .HasMaxLength(50)
                .HasColumnName("app_code");
            entity.Property(e => e.AppName)
                .HasMaxLength(255)
                .HasColumnName("app_name");
            entity.Property(e => e.Logo)
                .HasMaxLength(500)
                .HasColumnName("logo");
            entity.Property(e => e.RedirectUrl)
                .HasMaxLength(500)
                .HasComment("Consumer 后跳到网站主页")
                .HasColumnName("redirect_url");
            entity.Property(e => e.WxcomRedirectUrl)
                .HasMaxLength(500)
                .HasComment("跳到微信的鉴权页面")
                .HasColumnName("wxcomRedirectUrl");
        });

        modelBuilder.Entity<TAppInfoUserGroup>(entity =>
        {
            entity.ToTable("t_app_info_user_group", tb => tb.HasComment("OneApp应用-用户组关联表"));

            entity.HasIndex(e => e.AppCode, "idx_app_code");

            entity.HasIndex(e => e.UserGroupId, "idx_user_group_id");

            entity.Property(e => e.Id)
                .HasComment("主键ID")
                .HasColumnName("id");
            entity.Property(e => e.AppCode)
                .HasMaxLength(50)
                .HasComment("应用编码（关联 t_app_info.app_code）")
                .HasColumnName("app_code");
            entity.Property(e => e.CreatedBy)
                .HasComment("创建人ID")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(100)
                .HasComment("创建人名称")
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn)
                .HasComment("创建时间")
                .HasColumnName("created_on");
            entity.Property(e => e.UserGroupId)
                .HasComment("用户组ID（对应 t_super_agent_category 表中 type=5 的管理标签）")
                .HasColumnName("user_group_id");

            entity.HasOne(d => d.AppCodeNavigation).WithMany(p => p.TAppInfoUserGroups)
                .HasForeignKey(d => d.AppCode)
                .HasConstraintName("fk_app_info_user_group_app");

            entity.HasOne(d => d.UserGroup).WithMany(p => p.TAppInfoUserGroups)
                .HasForeignKey(d => d.UserGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_app_info_user_group_category");
        });

        modelBuilder.Entity<TApplicationSetting>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.ToTable("t_application_setting");

            entity.HasIndex(e => e.Key, "idx_t_application_setting_key").IsUnique();

            entity.HasIndex(e => e.Type, "idx_t_application_setting_type");

            entity.Property(e => e.Key)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("key");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IsValid).HasColumnName("is_valid");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
            entity.Property(e => e.Value)
                .HasMaxLength(4000)
                .HasColumnName("value");
        });

        modelBuilder.Entity<TAssistentLibrary>(entity =>
        {
            entity.HasKey(e => e.AssistentLibraryId);

            entity.ToTable("t_assistent_library");

            entity.Property(e => e.AssistentLibraryId).HasColumnName("assistent_library_id");
            entity.Property(e => e.AssistentCapbilityCategory)
                .HasMaxLength(10)
                .HasComment("contextfull,rag,plugin")
                .HasColumnName("assistent_capbility_category");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.IsAdvancedAssistent).HasColumnName("is_advanced_assistent");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.KnowledgeBaseId)
                .HasMaxLength(50)
                .HasColumnName("knowledge_base_id");
            entity.Property(e => e.Logo).HasColumnName("logo");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PromptContent)
                .HasMaxLength(1000)
                .HasColumnName("prompt_content");
            entity.Property(e => e.SystemKeyValue)
                .HasMaxLength(1000)
                .HasColumnName("system_key_value");
            entity.Property(e => e.SystemPromptContent)
                .HasMaxLength(1000)
                .HasColumnName("system_prompt_content");
            entity.Property(e => e.Tags)
                .HasMaxLength(2000)
                .HasColumnName("tags");
            entity.Property(e => e.Tips)
                .HasMaxLength(500)
                .HasColumnName("tips");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<TAssistentTopic>(entity =>
        {
            entity.HasKey(e => e.AssistentTopicId);

            entity.ToTable("t_assistent_topic");

            entity.Property(e => e.AssistentTopicId).HasColumnName("assistent_topic_id");
            entity.Property(e => e.AssistentLibraryId)
                .HasComment("助理模型")
                .HasColumnName("assistent_library_id");
            entity.Property(e => e.CreatedOn)
                .HasComment("创建时间")
                .HasColumnName("created_on");
            entity.Property(e => e.CurrentSystemMessage)
                .HasMaxLength(2000)
                .HasComment("当前系统消息")
                .HasColumnName("current_system_message");
            entity.Property(e => e.IsAccecptQuestionaire).HasColumnName("is_accecpt_questionaire");
            entity.Property(e => e.IsDisabled).HasColumnName("is_disabled");
            entity.Property(e => e.KnowledgeBaseId)
                .HasMaxLength(50)
                .HasComment("文档库ID")
                .HasColumnName("knowledge_base_id");
            entity.Property(e => e.KnowledgeBaseId2)
                .HasMaxLength(50)
                .HasComment("文档库ID")
                .HasColumnName("knowledge_base_id_2");
            entity.Property(e => e.KnowledgeBaseId3)
                .HasMaxLength(50)
                .HasComment("文档库ID")
                .HasColumnName("knowledge_base_id_3");
            entity.Property(e => e.OrderIndex)
                .HasComment("顺序")
                .HasColumnName("order_index");
            entity.Property(e => e.Plugin)
                .HasMaxLength(50)
                .HasComment("plugin id")
                .HasColumnName("plugin");
            entity.Property(e => e.Plugin2)
                .HasMaxLength(50)
                .HasComment("plugin id")
                .HasColumnName("plugin_2");
            entity.Property(e => e.Plugin3)
                .HasMaxLength(50)
                .HasComment("plugin id")
                .HasColumnName("plugin_3");
            entity.Property(e => e.QuestionnaireId)
                .HasComment("问卷ID")
                .HasColumnName("questionnaire_id");
            entity.Property(e => e.Temperature)
                .HasComment("温度")
                .HasColumnName("temperature");
            entity.Property(e => e.Topic)
                .HasMaxLength(500)
                .HasComment("话题")
                .HasColumnName("topic");
            entity.Property(e => e.TopicLogo)
                .HasMaxLength(500)
                .HasComment("会话头像")
                .HasColumnName("topic_logo");
            entity.Property(e => e.Uid).HasColumnName("uid");
        });

        modelBuilder.Entity<TAssistentTopicAgentConversionFlow>(entity =>
        {
            entity.HasKey(e => e.AssistentTopicId);

            entity.ToTable("t_assistent_topic_agent_conversion_flow");

            entity.Property(e => e.AssistentTopicId).HasColumnName("assistent_topic_id");
            entity.Property(e => e.AssistentLibraryId)
                .HasComment("助理模型")
                .HasColumnName("assistent_library_id");
            entity.Property(e => e.CreatedOn)
                .HasComment("创建时间")
                .HasColumnName("created_on");
            entity.Property(e => e.CurrentSystemMessage)
                .HasMaxLength(2000)
                .HasComment("当前系统消息")
                .HasColumnName("current_system_message");
            entity.Property(e => e.IsAccecptQuestionaire).HasColumnName("is_accecpt_questionaire");
            entity.Property(e => e.IsDisabled).HasColumnName("is_disabled");
            entity.Property(e => e.KnowledgeBaseId)
                .HasMaxLength(50)
                .HasComment("文档库ID")
                .HasColumnName("knowledge_base_id");
            entity.Property(e => e.KnowledgeBaseId2)
                .HasMaxLength(50)
                .HasComment("文档库ID")
                .HasColumnName("knowledge_base_id_2");
            entity.Property(e => e.KnowledgeBaseId3)
                .HasMaxLength(50)
                .HasComment("文档库ID")
                .HasColumnName("knowledge_base_id_3");
            entity.Property(e => e.OrderIndex)
                .HasComment("顺序")
                .HasColumnName("order_index");
            entity.Property(e => e.Plugin)
                .HasMaxLength(50)
                .HasComment("plugin id")
                .HasColumnName("plugin");
            entity.Property(e => e.Plugin2)
                .HasMaxLength(50)
                .HasComment("plugin id")
                .HasColumnName("plugin_2");
            entity.Property(e => e.Plugin3)
                .HasMaxLength(50)
                .HasComment("plugin id")
                .HasColumnName("plugin_3");
            entity.Property(e => e.QuestionnaireId)
                .HasComment("问卷ID")
                .HasColumnName("questionnaire_id");
            entity.Property(e => e.Temperature)
                .HasComment("温度")
                .HasColumnName("temperature");
            entity.Property(e => e.Topic)
                .HasMaxLength(500)
                .HasComment("话题")
                .HasColumnName("topic");
            entity.Property(e => e.TopicLogo)
                .HasMaxLength(500)
                .HasComment("会话头像")
                .HasColumnName("topic_logo");
            entity.Property(e => e.Uid).HasColumnName("uid");
        });

        modelBuilder.Entity<TAssistentTopicMessage>(entity =>
        {
            entity.HasKey(e => e.AssistentTopicMessageId);

            entity.ToTable("t_assistent_topic_message");

            entity.Property(e => e.AssistentTopicMessageId).HasColumnName("assistent_topic_message_id");
            entity.Property(e => e.AssistentTopicId).HasColumnName("assistent_topic_id");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.CurrentChatId)
                .HasMaxLength(50)
                .HasColumnName("current_chat_id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Metadata)
                .HasMaxLength(1000)
                .HasColumnName("metadata");
            entity.Property(e => e.ModelId)
                .HasMaxLength(50)
                .HasColumnName("model_id");
            entity.Property(e => e.Question)
                .HasComment("用户问的问题")
                .HasColumnName("question");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.Sort)
                .HasComment("用于排序")
                .HasColumnName("sort");
            entity.Property(e => e.Toolcall)
                .HasMaxLength(1000)
                .HasColumnName("toolcall");
            entity.Property(e => e.Type)
                .HasComment("类型：1=助理，2=AI")
                .HasColumnName("type");
            entity.Property(e => e.UseId)
                .HasComment("用户ID")
                .HasColumnName("use_id");
        });

        modelBuilder.Entity<TAuthLoginCategory>(entity =>
        {
            entity.HasKey(e => e.AuthType);

            entity.ToTable("t_auth_login_category");

            entity.Property(e => e.AuthType)
                .ValueGeneratedNever()
                .HasComment("1:saml 2:ldap 3:phone 4:email")
                .HasColumnName("auth_type");
            entity.Property(e => e.AuthProvider)
                .HasComment("提供平台 1：microsoft 2：google")
                .HasColumnName("auth_provider");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IsConfig)
                .HasComment("是否需要配置")
                .HasColumnName("is_config");
            entity.Property(e => e.IsEnable)
                .HasComment("是否启用")
                .HasColumnName("is_enable");
        });

        modelBuilder.Entity<TAuthLoginConfig>(entity =>
        {
            entity.ToTable("t_auth_login_config");

            entity.HasIndex(e => e.AuthLoginCategory, "idx_t_auth_login_saml_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthLoginCategory)
                .HasComment("外键")
                .HasColumnName("auth_login_category");
            entity.Property(e => e.ConfigJson)
                .HasComment("config 的json")
                .HasColumnName("config_json");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<TBachApiSet>(entity =>
        {
            entity.ToTable("t_bach_api_set");

            entity.HasIndex(e => e.Id, "INDEX_t_bach_api_set_ID").IsUnique();

            entity.HasIndex(e => e.PathUrl, "INDEX_t_bach_api_set_URL");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Controller)
                .HasMaxLength(500)
                .HasColumnName("controller");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");
            entity.Property(e => e.IsApiUser).HasColumnName("is_api_user");
            entity.Property(e => e.Method)
                .HasMaxLength(255)
                .HasColumnName("method");
            entity.Property(e => e.PathUrl)
                .HasMaxLength(1000)
                .HasColumnName("path_url");
            entity.Property(e => e.Summary)
                .HasMaxLength(2000)
                .HasColumnName("summary");
        });

        modelBuilder.Entity<TCompose>(entity =>
        {
            entity.HasKey(e => e.ComposeId);

            entity.ToTable("t_compose");

            entity.Property(e => e.ComposeId).HasColumnName("compose_id");
            entity.Property(e => e.ComposeStatus).HasColumnName("compose_status");
            entity.Property(e => e.ConsumedOrderId).HasColumnName("consumed_order_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.FinnalContent).HasColumnName("finnal_content");
            entity.Property(e => e.KnowledgeBaseId)
                .HasMaxLength(50)
                .HasColumnName("knowledge_base_id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.PersonalityId).HasColumnName("personality_id");
            entity.Property(e => e.PlatformId).HasColumnName("platform_id");
            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(200)
                .HasColumnName("product_name");
            entity.Property(e => e.PurposeId).HasColumnName("purpose_id");
            entity.Property(e => e.Title)
                .HasMaxLength(1000)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TComposeDetail>(entity =>
        {
            entity.HasKey(e => e.ComposeDetailId);

            entity.ToTable("t_compose_detail");

            entity.Property(e => e.ComposeDetailId).HasColumnName("compose_detail_id");
            entity.Property(e => e.ComposeId).HasColumnName("compose_id");
            entity.Property(e => e.Features).HasColumnName("features");
            entity.Property(e => e.GenerateCount).HasColumnName("generate_count");
            entity.Property(e => e.GeneratedContent).HasColumnName("generated_content");
            entity.Property(e => e.NodeDescription)
                .HasMaxLength(500)
                .HasColumnName("node_description");
            entity.Property(e => e.NodeName)
                .HasMaxLength(100)
                .HasColumnName("node_name");
            entity.Property(e => e.NodeTemplateId).HasColumnName("node_template_id");
            entity.Property(e => e.OrderIndex).HasColumnName("order_index");
            entity.Property(e => e.ParentComposeDetailId).HasColumnName("parent_compose_detail_id");
            entity.Property(e => e.PersonalityId).HasColumnName("personality_id");
            entity.Property(e => e.PreferGeneratedLength).HasColumnName("prefer_generated_length");
        });

        modelBuilder.Entity<TConsumption>(entity =>
        {
            entity.HasKey(e => e.ConsumptionId);

            entity.ToTable("t_consumption");

            entity.Property(e => e.ConsumptionId).HasColumnName("consumption_id");
            entity.Property(e => e.Action).HasColumnName("action");
            entity.Property(e => e.ComposeId).HasColumnName("compose_id");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.NodeTemplateId).HasColumnName("node_template_id");
            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.WordCount).HasColumnName("word_count");
        });

        modelBuilder.Entity<TConversation>(entity =>
        {
            entity.HasKey(e => e.ConversationId);

            entity.ToTable("t_conversation");

            entity.Property(e => e.ConversationId)
                .HasMaxLength(50)
                .HasColumnName("conversation_id");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .HasDefaultValue("0")
                .HasComment("会话颜色")
                .HasColumnName("color");
            entity.Property(e => e.ConversationName)
                .HasMaxLength(255)
                .HasColumnName("conversation_name");
            entity.Property(e => e.ConversationType)
                .HasComment("0: single conversion,1:group conversion")
                .HasColumnName("conversation_type");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.EnableCanvas)
                .HasComment("是否启用Canvas模式: 0=不启用, 1=启用")
                .HasColumnName("enable_canvas");
            entity.Property(e => e.EnableFollowUpQuestions)
                .HasComment("启用追问：0：不启用；1：启用；")
                .HasColumnName("enable_follow_up_questions");
            entity.Property(e => e.IsPin)
                .HasComment("是否置顶")
                .HasColumnName("is_pin");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.Logo)
                .HasMaxLength(500)
                .HasComment("会话头像")
                .HasColumnName("logo");
            entity.Property(e => e.PinTime)
                .HasComment("置顶时间")
                .HasColumnName("pin_time");
            entity.Property(e => e.Platform)
                .HasComment("平台：0：bach；1：oneapp；2：wecom")
                .HasColumnName("platform");
            entity.Property(e => e.Type)
                .HasComment("0=normal,1=调试")
                .HasColumnName("type");
            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.WorkSpaceId)
                .HasComment("工作区ID")
                .HasColumnName("work_space_id");
        });

        modelBuilder.Entity<TConversationImage>(entity =>
        {
            entity.ToTable("t_conversation_image");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(50)
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.ImgName)
                .HasMaxLength(50)
                .HasColumnName("img_name");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(255)
                .HasColumnName("img_url");
            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
        });

        modelBuilder.Entity<TConversationKnowledgebaseMapping>(entity =>
        {
            entity.HasKey(e => e.ConversationKnowledgebaseMappingId);

            entity.ToTable("t_conversation_knowledgebase_mapping");

            entity.Property(e => e.ConversationKnowledgebaseMappingId).HasColumnName("conversation_knowledgebase_mapping_id");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(50)
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("('1')")
                .HasComment("是否启用：0：否；1：是；")
                .HasColumnName("enable");
            entity.Property(e => e.EnableDocumentIds)
                .HasComment("启用查询用的文档id数组")
                .HasColumnName("enable_document_ids");
            entity.Property(e => e.EnableTableIds)
                .HasComment("启用查询用的数据表id数组")
                .HasColumnName("enable_table_ids");
            entity.Property(e => e.KnowledgeBaseId)
                .HasMaxLength(50)
                .HasColumnName("knowledge_base_id");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.SearchCategory)
                .HasDefaultValueSql("('0')")
                .HasComment("0：文本查询；1：表格查询")
                .HasColumnName("search_category");
            entity.Property(e => e.SearchFilterSelect)
                .HasDefaultValueSql("('0')")
                .HasComment("选择条件：0：文件名；1标签；2：路径")
                .HasColumnName("search_filter_select");
            entity.Property(e => e.SearchFilterValue)
                .HasComment("条件内容，数组")
                .HasColumnName("search_filter_value");
            entity.Property(e => e.SearchTableFilterSelect)
                .HasDefaultValueSql("('0')")
                .HasComment("table选择条件：0：文件名；1标签；2：路径")
                .HasColumnName("search_table_filter_select");
            entity.Property(e => e.SearchTableFilterValue)
                .HasComment("table条件内容，数组")
                .HasColumnName("search_table_filter_value");
            entity.Property(e => e.SelectedDocumentStatus)
                .HasDefaultValueSql("('1')")
                .HasComment("全选状态：0：否；1：是；")
                .HasColumnName("selected_document_status");
            entity.Property(e => e.SelectedTableStatus)
                .HasDefaultValueSql("('1')")
                .HasComment("全选状态：0：否；1：是；")
                .HasColumnName("selected_table_status");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");

            entity.HasOne(d => d.Conversation).WithMany(p => p.TConversationKnowledgebaseMappings)
                .HasForeignKey(d => d.ConversationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("t_conversation_knowledgebase_mapping_ibfk_1");
        });

        modelBuilder.Entity<TConversationMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId);

            entity.ToTable("t_conversation_message");

            entity.HasIndex(e => e.DialogId, "INDEX_conversation_message");

            entity.HasIndex(e => new { e.ConversationId, e.CreatedOn }, "idx_conversation_id");

            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(50)
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.DialogId)
                .HasMaxLength(50)
                .HasColumnName("dialog_id");
            entity.Property(e => e.Identification).HasMaxLength(36);
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.MessageType)
                .HasMaxLength(50)
                .HasColumnName("message_type");
            entity.Property(e => e.SenderId)
                .HasMaxLength(10)
                .HasColumnName("sender_id");
            entity.Property(e => e.SenderType)
                .HasMaxLength(10)
                .HasColumnName("sender_type");
            entity.Property(e => e.SkLogId)
                .HasMaxLength(50)
                .HasColumnName("sk_log_id");
        });

        modelBuilder.Entity<TConversationMessageAgent>(entity =>
        {
            entity.ToTable("t_conversation_message_agent");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.SuperAgentSettingId).HasColumnName("super_agent_setting_id");
            entity.Property(e => e.SuperAgentVersion)
                .HasMaxLength(255)
                .HasColumnName("super_agent_version");
        });

        modelBuilder.Entity<TConversationMessageFeedback>(entity =>
        {
            entity.ToTable("t_conversation_message_feedback");

            entity.HasIndex(e => e.ConversationMessageId, "conversation_message_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgentCreatorId)
                .HasComment("智能体创作用户id")
                .HasColumnName("agent_creator_id");
            entity.Property(e => e.AgentId)
                .HasComment("智能体id")
                .HasColumnName("agent_id");
            entity.Property(e => e.AgentLlmConfig)
                .HasComment("智能体模型")
                .HasColumnName("agent_llm_config");
            entity.Property(e => e.AgentName)
                .HasMaxLength(200)
                .HasComment("智能体名称")
                .HasColumnName("agent_name");
            entity.Property(e => e.AgentPrompt)
                .HasComment("智能体提示词(前10条)")
                .HasColumnName("agent_prompt");
            entity.Property(e => e.AgentSkill)
                .HasComment("智能体技能")
                .HasColumnName("agent_skill");
            entity.Property(e => e.Category)
                .HasComment("0=踩，1=赞")
                .HasColumnName("category");
            entity.Property(e => e.ConversationContext)
                .HasComment("对话上下文(前10条)")
                .HasColumnName("conversation_context");
            entity.Property(e => e.ConversationDialogId)
                .HasMaxLength(50)
                .HasColumnName("conversation_dialog_id");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(50)
                .HasColumnName("conversation_id");
            entity.Property(e => e.ConversationMessageId).HasColumnName("conversation_message_id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.Error).HasColumnName("error");
            entity.Property(e => e.FeedBackContent)
                .HasMaxLength(2000)
                .HasComment("反馈内容(标签)")
                .HasColumnName("feed_back_content");
            entity.Property(e => e.FeedBackSkill)
                .HasComment("反馈时技能(对应的plugin,知识库，gpt兜底)")
                .HasColumnName("feed_back_skill");
            entity.Property(e => e.GeneratedContent)
                .HasMaxLength(255)
                .HasComment("反馈处理生成内容")
                .HasColumnName("generated_content");
            entity.Property(e => e.HandleRemark)
                .HasComment("反馈处理备注")
                .HasColumnName("handle_remark");
            entity.Property(e => e.IntentionUnderstanding)
                .HasMaxLength(255)
                .HasComment("反馈处理意图理解")
                .HasColumnName("intention_understanding");
            entity.Property(e => e.KnowledgeBase)
                .HasComment("知识库(个人关联文档)")
                .HasColumnName("knowledge_base");
            entity.Property(e => e.OriginalPrompt)
                .HasComment("原始prompt")
                .HasColumnName("original_prompt");
            entity.Property(e => e.Reason)
                .HasComment("原因/期望的结果")
                .HasColumnName("reason");
            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
        });

        modelBuilder.Entity<TConversationPlugin>(entity =>
        {
            entity.ToTable("t_conversation_plugin", tb => tb.HasComment("对话技能绑定关联表"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(36)
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.PluginId).HasColumnName("plugin_id");
        });

        modelBuilder.Entity<TConversationSuperAgent>(entity =>
        {
            entity.HasKey(e => e.ConversationSuperAgentsId);

            entity.ToTable("t_conversation_super_agents");

            entity.Property(e => e.ConversationSuperAgentsId).HasColumnName("conversation_super_agents_id");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(50)
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.SuperAgentSettingId).HasColumnName("super_agent_setting_id");
            entity.Property(e => e.SuperAgentVersion)
                .HasMaxLength(255)
                .HasColumnName("super_agent_version");
        });

        modelBuilder.Entity<TConversationSuperAgentsSequence>(entity =>
        {
            entity.HasKey(e => e.ConversationSuperAgentsSequenceId);

            entity.ToTable("t_conversation_super_agents_sequence");

            entity.Property(e => e.ConversationSuperAgentsSequenceId).HasColumnName("conversation_super_agents_sequence_id");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(50)
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.SuperAgentSettingFromId)
                .HasComment("-1 表示用户")
                .HasColumnName("super_agent_setting_from_id");
            entity.Property(e => e.SuperAgentSettingToId)
                .HasComment("-1 表示用户")
                .HasColumnName("super_agent_setting_to_id");
        });

        modelBuilder.Entity<TConversationSurvey>(entity =>
        {
            entity.ToTable("t_conversation_survey");

            entity.HasIndex(e => e.ConversationId, "conversation_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(50)
                .HasColumnName("conversation_id");
            entity.Property(e => e.ExampleContent)
                .HasMaxLength(2000)
                .HasComment("样例内容")
                .HasColumnName("example_content");
            entity.Property(e => e.VariableDescription)
                .HasMaxLength(2000)
                .HasComment("变量描述")
                .HasColumnName("variable_description");
            entity.Property(e => e.VariableName)
                .HasMaxLength(100)
                .HasColumnName("variable_name");
            entity.Property(e => e.VariableValue)
                .HasMaxLength(2000)
                .HasColumnName("variable_value");

            entity.HasOne(d => d.Conversation).WithMany(p => p.TConversationSurveys)
                .HasForeignKey(d => d.ConversationId)
                .HasConstraintName("t_conversation_survey_ibfk_1");
        });

        modelBuilder.Entity<TCrop>(entity =>
        {
            entity.ToTable("t_crop");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppId)
                .HasMaxLength(55)
                .HasColumnName("app_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Type)
                .HasComment(" 1：虫虫 2：星火")
                .HasColumnName("type");
        });

        modelBuilder.Entity<TCropAppInfo>(entity =>
        {
            entity.HasKey(e => e.Agentid);

            entity.ToTable("t_crop_app_info", tb => tb.HasComment("企业微信内部app的信息"));

            entity.Property(e => e.Agentid)
                .HasComment("企业微信app的编号")
                .HasColumnName("agentid");
            entity.Property(e => e.AppKey)
                .HasMaxLength(255)
                .HasComment("app唯一的key")
                .HasColumnName("app_key");
            entity.Property(e => e.AppSecret)
                .HasMaxLength(255)
                .HasComment("app_secret")
                .HasColumnName("app_secret");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasComment("描述信息")
                .HasColumnName("description");
            entity.Property(e => e.EncodingAesKey)
                .HasMaxLength(255)
                .HasComment("api接受消息的EncodingAESKey,企业微信自动生成（加密)")
                .HasColumnName("encoding_aes_key");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .HasComment("api接受消息的token,企业微信自动生成(加密）")
                .HasColumnName("token");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("('1')")
                .HasComment("1 上海锦得如")
                .HasColumnName("type");
        });

        modelBuilder.Entity<TCustomTag>(entity =>
        {
            entity.ToTable("t_custom_tag");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.MergeTime)
                .HasComment("更新时间")
                .HasColumnName("merge_time");
            entity.Property(e => e.Tag)
                .HasComment("标签，以逗号(,)分割")
                .HasColumnName("tag");
            entity.Property(e => e.ThirdId)
                .HasMaxLength(255)
                .HasComment("第三方ID，用于查询")
                .HasColumnName("third_id");
            entity.Property(e => e.Type)
                .HasComment("类型")
                .HasColumnName("type");
        });

        modelBuilder.Entity<TDataAgent>(entity =>
        {
            entity.HasKey(e => e.DataAgentId);

            entity.ToTable("t_data_agent");

            entity.Property(e => e.DataAgentId).HasColumnName("data_agent_id");
            entity.Property(e => e.ConnectKey)
                .HasMaxLength(255)
                .HasColumnName("connect_key");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.Uid).HasColumnName("uid");
        });

        modelBuilder.Entity<TDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId);

            entity.ToTable("t_department", tb => tb.HasComment("员工部门表"));

            entity.HasIndex(e => e.DepartmentId, "idx_department_id").IsUnique();

            entity.HasIndex(e => e.DepartmentCode, "idx_department_org_code").IsUnique();

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(50)
                .HasComment("创建人")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");
            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(50)
                .HasComment("部门编号")
                .HasColumnName("department_code");
            entity.Property(e => e.LastSyncTime)
                .HasComment("上次同步时间")
                .HasColumnName("last_sync_time");
            entity.Property(e => e.NameEnUs)
                .HasMaxLength(255)
                .HasComment("英文名(暂时不用)")
                .HasColumnName("name_en_us");
            entity.Property(e => e.NameZhCn)
                .HasMaxLength(255)
                .HasComment("中文名")
                .HasColumnName("name_zh_cn");
            entity.Property(e => e.ParentCode)
                .HasMaxLength(50)
                .HasComment("上级部门编号")
                .HasColumnName("parent_code");
            entity.Property(e => e.Status)
                .HasComment("使用状态：true=有效，false=无效")
                .HasColumnName("status");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(50)
                .HasComment("更新人")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<TEditorInfo>(entity =>
        {
            entity.ToTable("t_editor_info", tb => tb.HasComment("编辑者信息"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");
            entity.Property(e => e.EditorUid)
                .HasComment("编辑者id")
                .HasColumnName("editor_uid");
            entity.Property(e => e.TableId)
                .HasMaxLength(255)
                .HasComment("对应的表id")
                .HasColumnName("table_id");
            entity.Property(e => e.Type)
                .HasComment("类型：1=智能体，2=小程序")
                .HasColumnName("type");
        });

        modelBuilder.Entity<TEnterpriseInfo>(entity =>
        {
            entity.ToTable("t_enterprise_info", tb => tb.HasComment("企业信息表"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasComment("创建人id")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasComment("创建时间")
                .HasColumnName("created_on");
            entity.Property(e => e.Logo)
                .HasMaxLength(255)
                .HasComment("头像")
                .HasColumnName("logo");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasComment("标题")
                .HasColumnName("title");
            entity.Property(e => e.UpdateBy)
                .HasComment("更新人id")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnName("update_time");
            entity.Property(e => e.UseWatermark)
                .HasComment("启用水印：0 未启用；1已启用；")
                .HasColumnName("use_watermark");
        });

        modelBuilder.Entity<TEnvironmentVariable>(entity =>
        {
            entity.ToTable("t_environment_variable", tb => tb.HasComment("环境变量配置表（企业配置）"));

            entity.HasIndex(e => e.CreateTime, "idx_create_time");

            entity.HasIndex(e => e.Host, "idx_host")
                .IsUnique()
                .HasFilter("([host] IS NOT NULL)");

            entity.Property(e => e.Id)
                .HasComment("主键ID")
                .HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");
            entity.Property(e => e.DarkLogo)
                .HasMaxLength(500)
                .HasComment("深色Logo URL")
                .HasColumnName("dark_logo");
            entity.Property(e => e.Host)
                .HasMaxLength(191)
                .HasComment("企业域名")
                .HasColumnName("host");
            entity.Property(e => e.LightLogo)
                .HasMaxLength(500)
                .HasComment("浅色Logo URL")
                .HasColumnName("light_logo");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasComment("站点标题")
                .HasColumnName("title");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<TFeature>(entity =>
        {
            entity.HasKey(e => e.FeatureId);

            entity.ToTable("t_feature");

            entity.Property(e => e.FeatureId).HasColumnName("feature_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.Feature)
                .HasMaxLength(500)
                .HasColumnName("feature");
            entity.Property(e => e.IsSystem).HasColumnName("is_system");
            entity.Property(e => e.LastModifyBy).HasColumnName("last_modify_by");
            entity.Property(e => e.LastModifyOn).HasColumnName("last_modify_on");
            entity.Property(e => e.NodeTemplateId).HasColumnName("node_template_id");
            entity.Property(e => e.PurposeId).HasColumnName("purpose_id");
            entity.Property(e => e.SourceId).HasColumnName("source_id");
            entity.Property(e => e.SourceType)
                .HasMaxLength(10)
                .HasColumnName("source_type");
        });

        modelBuilder.Entity<TFlow>(entity =>
        {
            entity.HasKey(e => e.FlowId);

            entity.ToTable("t_flow");

            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.CancelPublishTime)
                .HasComment("取消发布时间")
                .HasColumnName("cancel_publish_time");
            entity.Property(e => e.Count)
                .HasComment("使用次数")
                .HasColumnName("count");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.Description)
                .HasComment("描述")
                .HasColumnName("description");
            entity.Property(e => e.IsPublish)
                .HasComment("是否已发布")
                .HasColumnName("is_publish");
            entity.Property(e => e.IsVersionSame)
                .HasComment("是否版本一样")
                .HasColumnName("is_version_same");
            entity.Property(e => e.Logo)
                .HasMaxLength(500)
                .HasComment("图标")
                .HasColumnName("logo");
            entity.Property(e => e.Md5)
                .HasMaxLength(255)
                .HasColumnName("MD5");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment("flow名字")
                .HasColumnName("name");
            entity.Property(e => e.PublishTime)
                .HasComment("发布时间")
                .HasColumnName("publish_time");
            entity.Property(e => e.SuperAgentCategoryId)
                .HasComment("类别id")
                .HasColumnName("super_agent_category_id");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("('1')")
                .HasComment("1.普通，2专业")
                .HasColumnName("type");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
            entity.Property(e => e.UpdateUid).HasColumnName("update_uid");
            entity.Property(e => e.Uuid)
                .HasMaxLength(36)
                .HasColumnName("uuid");
        });

        modelBuilder.Entity<TFlowApi>(entity =>
        {
            entity.HasKey(e => e.ResourceId);

            entity.ToTable("t_flow_api");

            entity.Property(e => e.ResourceId)
                .HasMaxLength(36)
                .HasColumnName("resource_id");
            entity.Property(e => e.ApiUrl)
                .HasMaxLength(1000)
                .HasComment("api的地址")
                .HasColumnName("api_url");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");
            entity.Property(e => e.EndParams).HasColumnName("end_params");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.FromUser)
                .HasMaxLength(255)
                .HasComment("用户id")
                .HasColumnName("from_user");
            entity.Property(e => e.IsUsed)
                .IsRequired()
                .HasDefaultValueSql("('1')")
                .HasComment("是否启用")
                .HasColumnName("is_used");
            entity.Property(e => e.RequestParams)
                .HasMaxLength(2000)
                .HasComment("请求参数，用于判断")
                .HasColumnName("request_params");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<TFlowApiLog>(entity =>
        {
            entity.ToTable("t_flow_api_log", tb => tb.HasComment("API日志表"));

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");
            entity.Property(e => e.Error)
                .HasMaxLength(2000)
                .HasComment("失败原因")
                .HasColumnName("error");
            entity.Property(e => e.HttpStatus)
                .HasMaxLength(255)
                .HasComment("状态码")
                .HasColumnName("http_status");
            entity.Property(e => e.Method)
                .HasMaxLength(30)
                .HasComment("POST,GET")
                .HasColumnName("method");
            entity.Property(e => e.RequestParam)
                .HasComment("请求参数")
                .HasColumnName("request_param");
            entity.Property(e => e.ResponseParam)
                .HasComment("返回参数")
                .HasColumnName("response_param");
            entity.Property(e => e.Status)
                .HasComment("1：成功  2：失败")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasComment("1=SSE,2=CALLBACK")
                .HasColumnName("type");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasComment("推送地址")
                .HasColumnName("url");
        });

        modelBuilder.Entity<TFlowApiPublish>(entity =>
        {
            entity.ToTable("t_flow_api_publish");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.Uid).HasColumnName("uid");
        });

        modelBuilder.Entity<TFlowEdge>(entity =>
        {
            entity.ToTable("t_flow_edge");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.Source)
                .HasMaxLength(255)
                .HasColumnName("source");
            entity.Property(e => e.SourceNode)
                .HasMaxLength(255)
                .HasColumnName("source_node");
            entity.Property(e => e.Target)
                .HasMaxLength(255)
                .HasComment("坐标位置")
                .HasColumnName("target");
            entity.Property(e => e.TargetNode)
                .HasMaxLength(255)
                .HasColumnName("target_node");
            entity.Property(e => e.Text)
                .HasComment("上面的都不用了。只用下面的")
                .HasColumnName("text");
            entity.Property(e => e.Variable)
                .HasMaxLength(255)
                .HasComment("坐标位置")
                .HasColumnName("variable");

            entity.HasOne(d => d.Flow).WithMany(p => p.TFlowEdges)
                .HasForeignKey(d => d.FlowId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("t_flow_edge_ibfk_1");
        });

        modelBuilder.Entity<TFlowExportInfo>(entity =>
        {
            entity.ToTable("t_flow_export_info");

            entity.HasIndex(e => e.Id, "idx_unique_tflow_flowexport_id_copy1").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.BlobUrl)
                .HasMaxLength(2000)
                .HasComment("blob的地址")
                .HasColumnName("blob_url");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.ProcessContent).HasColumnName("process_content");
            entity.Property(e => e.Status)
                .HasComment("状态：1：正在处理，2：成功，9：失败")
                .HasColumnName("status");
            entity.Property(e => e.Strategy)
                .HasComment("导出 0：一个  1：多个\n导入 0：全新   1：覆盖")
                .HasColumnName("strategy");
            entity.Property(e => e.Type)
                .HasComment("1：导出，2：导入")
                .HasColumnName("type");
            entity.Property(e => e.Uid)
                .HasComment("操作人")
                .HasColumnName("uid");
            entity.Property(e => e.Uuid)
                .HasMaxLength(36)
                .HasComment("唯一编号,为了导出，其他是否都用flowid")
                .HasColumnName("uuid");
        });

        modelBuilder.Entity<TFlowLog>(entity =>
        {
            entity.ToTable("t_flow_log", tb => tb.HasComment("针对小程序单独的创建和执行的记录表"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.CreatedBy)
                .HasComment("创建人id")
                .HasColumnName("created_by");
            entity.Property(e => e.DialogId)
                .HasMaxLength(255)
                .HasColumnName("dialog_id");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.InvodeType).HasColumnName("invode_type");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<TFlowManageLable>(entity =>
        {
            entity.HasKey(e => e.FlowManageLableId);

            entity.ToTable("t_flow_manage_lable", tb => tb.HasComment("ai小程序管理标签"));

            entity.Property(e => e.FlowManageLableId).HasColumnName("flow_manage_lable_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.PermissionType)
                .HasComment("权限类型：1=使用权限，2=编辑权限")
                .HasColumnName("permission_type");
            entity.Property(e => e.SuperAgentCategoryId)
                .HasComment("管理标签id")
                .HasColumnName("super_agent_category_id");
        });

        modelBuilder.Entity<TFlowNode>(entity =>
        {
            entity.ToTable("t_flow_node");

            entity.HasIndex(e => e.FlowId, "flow_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.Description)
                .HasComment("详情")
                .HasColumnName("description");
            entity.Property(e => e.DesignParams)
                .HasComment("大json")
                .HasColumnName("design_params");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.Left)
                .HasComment("坐标位置")
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("left");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment("步骤名字")
                .HasColumnName("name");
            entity.Property(e => e.NodeId)
                .HasMaxLength(255)
                .HasComment("不是主键，前端显示用的")
                .HasColumnName("node_id");
            entity.Property(e => e.NodeType)
                .HasMaxLength(255)
                .HasComment("类型")
                .HasColumnName("node_type");
            entity.Property(e => e.Prompt)
                .HasComment("prompt")
                .HasColumnName("prompt");
            entity.Property(e => e.Step)
                .HasComment("步骤")
                .HasColumnName("step");
            entity.Property(e => e.Top)
                .HasComment("坐标位置")
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("top");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasComment("action——type")
                .HasColumnName("type");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
            entity.Property(e => e.UpdateUid).HasColumnName("update_uid");

            entity.HasOne(d => d.Flow).WithMany(p => p.TFlowNodes)
                .HasForeignKey(d => d.FlowId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("t_flow_node_ibfk_1");
        });

        modelBuilder.Entity<TFlowNodeLog>(entity =>
        {
            entity.ToTable("t_flow_node_log");

            entity.HasIndex(e => e.NodeId, "index_t_flow_node_log_node_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");
            entity.Property(e => e.NodeId)
                .HasComment("node_id  可能会在 flow_node库里面没有，")
                .HasColumnName("node_id");
            entity.Property(e => e.Prompt).HasColumnName("prompt");
            entity.Property(e => e.Request)
                .HasComment("请求参数")
                .HasColumnName("request");
            entity.Property(e => e.Response)
                .HasComment("返回值")
                .HasColumnName("response");
            entity.Property(e => e.Uid)
                .HasComment("用户")
                .HasColumnName("uid");
        });

        modelBuilder.Entity<TFlowProcessInfo>(entity =>
        {
            entity.ToTable("t_flow_process_info", tb => tb.HasComment("针对小程序单独的创建和执行的记录表"));

            entity.HasIndex(e => e.DialogId, "idx_dialog_id");

            entity.HasIndex(e => new { e.FlowId, e.DialogId }, "idx_flow_dialog");

            entity.HasIndex(e => e.FlowId, "idx_flow_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BlobUrl)
                .HasMaxLength(1000)
                .HasComment("过程的blob url地址")
                .HasColumnName("blob_url");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.DialogId).HasColumnName("dialog_id");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
        });

        modelBuilder.Entity<TFlowPublish>(entity =>
        {
            entity.ToTable("t_flow_publish");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Context).HasColumnName("context");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.FrontContext)
                .HasComment("前端要的文本格式")
                .HasColumnName("front_context");
            entity.Property(e => e.IsUsed)
                .HasComment("使用")
                .HasColumnName("is_used");
            entity.Property(e => e.Md5)
                .HasMaxLength(255)
                .HasColumnName("MD5");
            entity.Property(e => e.MergeTime)
                .HasComment("修改时间")
                .HasColumnName("merge_time");
            entity.Property(e => e.PublishTitle)
                .HasMaxLength(255)
                .HasComment("发布历史名称")
                .HasColumnName("publish_title");
            entity.Property(e => e.PublishUid)
                .HasComment("发布者id")
                .HasColumnName("publish_uid");
            entity.Property(e => e.Version)
                .HasMaxLength(55)
                .HasColumnName("version");
        });

        modelBuilder.Entity<TFlowVariable>(entity =>
        {
            entity.HasKey(e => e.VariableId);

            entity.ToTable("t_flow_variable");

            entity.HasIndex(e => e.NodeId, "node_id");

            entity.HasIndex(e => e.FlowId, "t_flow_variable_ibfk_2");

            entity.Property(e => e.VariableId).HasColumnName("variable_id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.FlowVariableType)
                .HasMaxLength(255)
                .HasComment("后端使用的，输入类型 类型，input/output")
                .HasColumnName("flow_variable_type");
            entity.Property(e => e.Height)
                .HasComment("高度")
                .HasColumnName("height");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment("参数名字")
                .HasColumnName("name");
            entity.Property(e => e.NodeId).HasColumnName("node_id");
            entity.Property(e => e.Step)
                .HasComment("步骤数")
                .HasColumnName("step");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasComment("字段value")
                .HasColumnName("type");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
            entity.Property(e => e.UpdateUid).HasColumnName("update_uid");
            entity.Property(e => e.Value)
                .HasMaxLength(4000)
                .HasComment("前端对应存的值")
                .HasColumnName("value");
            entity.Property(e => e.Variable)
                .HasMaxLength(255)
                .HasComment("字段key")
                .HasColumnName("variable");
            entity.Property(e => e.VariableType)
                .HasMaxLength(50)
                .HasComment("前端使用的 类型，input/output")
                .HasColumnName("variable_type");

            entity.HasOne(d => d.Flow).WithMany(p => p.TFlowVariables)
                .HasForeignKey(d => d.FlowId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("t_flow_variable_ibfk_2");

            entity.HasOne(d => d.Node).WithMany(p => p.TFlowVariables)
                .HasForeignKey(d => d.NodeId)
                .HasConstraintName("t_flow_variable_ibfk_3");
        });

        modelBuilder.Entity<TFunction>(entity =>
        {
            entity.ToTable("t_function");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Module)
                .HasMaxLength(255)
                .HasColumnName("module");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Prompt).HasColumnName("prompt");
            entity.Property(e => e.Step).HasColumnName("step");
            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
        });

        modelBuilder.Entity<TFunctionPromptExecution>(entity =>
        {
            entity.ToTable("t_function_prompt_execution");

            entity.HasIndex(e => e.FuntionId, "funtion_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChatSystemPrompt)
                .HasMaxLength(1000)
                .HasColumnName("chat_system_prompt");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.FrequencyPenalty).HasColumnName("frequency_penalty");
            entity.Property(e => e.FuntionId).HasColumnName("funtion_id");
            entity.Property(e => e.MaxTokens).HasColumnName("max_tokens");
            entity.Property(e => e.PresencePenalty).HasColumnName("presence_penalty");
            entity.Property(e => e.ResponseFormat)
                .HasMaxLength(50)
                .HasComment("\"json_object\", \"text\"")
                .HasColumnName("response_format");
            entity.Property(e => e.ResultsPerPrompt).HasColumnName("results_per_prompt");
            entity.Property(e => e.Seed).HasColumnName("seed");
            entity.Property(e => e.StopSequences)
                .HasMaxLength(1000)
                .HasColumnName("stop_sequences");
            entity.Property(e => e.Temperature).HasColumnName("temperature");
            entity.Property(e => e.TopP).HasColumnName("top_p");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");

            entity.HasOne(d => d.Funtion).WithMany(p => p.TFunctionPromptExecutions)
                .HasForeignKey(d => d.FuntionId)
                .HasConstraintName("t_function_prompt_execution_ibfk_1");
        });

        modelBuilder.Entity<TFunctionRequestParameter>(entity =>
        {
            entity.ToTable("t_function_request_parameter");

            entity.HasIndex(e => e.FunctionId, "t_function_request_parameter_funcationid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.FunctionId).HasColumnName("function_id");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Step).HasColumnName("step");
            entity.Property(e => e.StepName)
                .HasMaxLength(255)
                .HasColumnName("step_name");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
            entity.Property(e => e.Variable)
                .HasMaxLength(1000)
                .HasColumnName("variable");
            entity.Property(e => e.VariableType)
                .HasMaxLength(255)
                .HasColumnName("variable_type");

            entity.HasOne(d => d.Function).WithMany(p => p.TFunctionRequestParameters)
                .HasForeignKey(d => d.FunctionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("t_function_request_parameter_ibfk_1");
        });

        modelBuilder.Entity<TFunctionResponseParameter>(entity =>
        {
            entity.ToTable("t_function_response_parameter");

            entity.HasIndex(e => e.FunctionId, "INDX_FUNCTION_funtion_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.FunctionId).HasColumnName("function_id");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Step).HasColumnName("step");
            entity.Property(e => e.StepName)
                .HasMaxLength(255)
                .HasColumnName("step_name");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
            entity.Property(e => e.Variable)
                .HasMaxLength(1000)
                .HasColumnName("variable");
            entity.Property(e => e.VariableType)
                .HasMaxLength(255)
                .HasColumnName("variable_type");

            entity.HasOne(d => d.Function).WithMany(p => p.TFunctionResponseParameters)
                .HasForeignKey(d => d.FunctionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("t_function_response_parameter_ibfk_1");
        });

        modelBuilder.Entity<TIntentionStatistic>(entity =>
        {
            entity.ToTable("t_intention_statistics", tb => tb.HasComment("意图统计"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgentId)
                .HasMaxLength(50)
                .HasComment("智能体id")
                .HasColumnName("agent_id");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(50)
                .HasComment("会话id")
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreateDate)
                .HasComment("意图触发日期")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateTime)
                .HasComment("意图触发时间")
                .HasColumnName("create_time");
            entity.Property(e => e.DialogId)
                .HasMaxLength(50)
                .HasComment("对话id")
                .HasColumnName("dialog_id");
            entity.Property(e => e.SkillCategory)
                .HasMaxLength(50)
                .HasComment("技能类型")
                .HasColumnName("skill_category");
        });

        modelBuilder.Entity<TInvitation>(entity =>
        {
            entity.HasKey(e => e.InvitationId);

            entity.ToTable("t_invitation");

            entity.Property(e => e.InvitationId).HasColumnName("invitation_id");
            entity.Property(e => e.Channel)
                .HasMaxLength(200)
                .HasColumnName("channel");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.LimitedCount).HasColumnName("limited_count");
        });

        modelBuilder.Entity<TLanguage>(entity =>
        {
            entity.HasKey(e => e.LanguageId);

            entity.ToTable("t_language");

            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.Content)
                .HasMaxLength(200)
                .HasColumnName("content");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(200)
                .HasColumnName("logo_url");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.OrderIndex)
                .HasMaxLength(200)
                .HasColumnName("order_index");
        });

        modelBuilder.Entity<TLearning>(entity =>
        {
            entity.HasKey(e => e.LearningId);

            entity.ToTable("t_learning");

            entity.Property(e => e.LearningId).HasColumnName("learning_id");
            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .HasColumnName("brand");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.DocumentId)
                .HasMaxLength(50)
                .HasColumnName("document_id");
            entity.Property(e => e.IsSystem).HasColumnName("is_system");
            entity.Property(e => e.KnowledgeBaseId)
                .HasMaxLength(50)
                .HasColumnName("knowledge_base_id");
            entity.Property(e => e.LearningMessage)
                .HasMaxLength(500)
                .HasColumnName("learning_message");
            entity.Property(e => e.LearningResult).HasColumnName("learning_result");
            entity.Property(e => e.LearningStatus)
                .HasMaxLength(50)
                .HasColumnName("learning_status");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.PurposeId).HasColumnName("purpose_id");
        });

        modelBuilder.Entity<TLlmConfig>(entity =>
        {
            entity.HasKey(e => e.LlmConfigId);

            entity.ToTable("t_llm_config");

            entity.Property(e => e.LlmConfigId).HasColumnName("llm_config_id");
            entity.Property(e => e.ClientId)
                .HasMaxLength(200)
                .HasColumnName("client_id");
            entity.Property(e => e.ClientSecret)
                .HasMaxLength(500)
                .HasColumnName("client_secret");
            entity.Property(e => e.Deployment)
                .HasMaxLength(100)
                .HasColumnName("deployment");
            entity.Property(e => e.Endpoint)
                .HasMaxLength(500)
                .HasColumnName("endpoint");
            entity.Property(e => e.Key)
                .HasMaxLength(200)
                .HasComment("钥匙")
                .HasColumnName("key");
            entity.Property(e => e.LlmType)
                .HasComment("类型 0=Completion,1=Embedding,2=text_to_image")
                .HasColumnName("llm_type");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasComment("模型\n")
                .HasColumnName("model");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment("接入点名字")
                .HasColumnName("name");
            entity.Property(e => e.Provider)
                .HasComment("供应商\n")
                .HasColumnName("provider");
            entity.Property(e => e.TenantId)
                .HasMaxLength(100)
                .HasColumnName("tenant_id");
        });

        modelBuilder.Entity<TLlmGlobalVariable>(entity =>
        {
            entity.ToTable("t_llm_global_variable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConfigName)
                .HasMaxLength(255)
                .HasComment("\r\n\r\n")
                .HasColumnName("config_name");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
            entity.Property(e => e.Provider).HasColumnName("provider");
            entity.Property(e => e.ScenarioName)
                .HasMaxLength(255)
                .HasColumnName("scenario_name");
        });

        modelBuilder.Entity<TLlmModel>(entity =>
        {
            entity.HasKey(e => e.ModelId);

            entity.ToTable("t_llm_model");

            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.CharacterToTokenRatio)
                .HasComment("LLM 输入窗口中 1 个字符折算多少 token。")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("character_to_token_ratio");
            entity.Property(e => e.IsDefault).HasColumnName("is_default");
            entity.Property(e => e.IsReasoningModel)
                .HasDefaultValueSql("('0')")
                .HasComment("是否是推理模型")
                .HasColumnName("is_reasoning_model");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasComment("模型名称")
                .HasColumnName("model");
            entity.Property(e => e.ModelIsSupportFunction)
                .HasComment("模型是否支持function calling")
                .HasColumnName("model_is_support_function");
            entity.Property(e => e.ModelIsSupportImageInput)
                .HasComment("模型是否支持Image2Text")
                .HasColumnName("model_is_support_image_input");
            entity.Property(e => e.ModelMaxInputTokens)
                .HasComment("最大token输入")
                .HasColumnName("model_max_input_tokens");
            entity.Property(e => e.ModelMaxOutputTokens)
                .HasComment("最大token输出")
                .HasColumnName("model_max_output_tokens");
            entity.Property(e => e.Provider)
                .HasComment("GenAIProvider从枚举来 的")
                .HasColumnName("provider");
            entity.Property(e => e.ProviderName)
                .HasMaxLength(255)
                .HasColumnName("provider_name");
            entity.Property(e => e.SetNewMaxCompletionTokensEnabled)
                .HasDefaultValueSql("('0')")
                .HasComment("Enabling this property will enforce the new max_completion_tokens parameter to be send the Azure OpenAI API")
                .HasColumnName("set_new_max_completion_tokens_enabled");
            entity.Property(e => e.Type)
                .HasComment("类型 0=Completion,1=Embedding,2=text_to_image")
                .HasColumnName("type");
        });

        modelBuilder.Entity<TLlmModelPromotMapping>(entity =>
        {
            entity.ToTable("t_llm_model_promot_mapping");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.IsValid)
                .IsRequired()
                .HasDefaultValueSql("('1')")
                .HasColumnName("is_valid");
            entity.Property(e => e.LlmModelId).HasColumnName("llm_model_id");
            entity.Property(e => e.LlmPromptSettingId).HasColumnName("llm_prompt_setting_id");
        });

        modelBuilder.Entity<TLlmPromptSetting>(entity =>
        {
            entity.HasKey(e => e.PromptSettingId);

            entity.ToTable("t_llm_prompt_setting");

            entity.HasIndex(e => e.Name, "INDEX_LLM_PROMOT_SETTING_name")
                .IsUnique()
                .HasFilter("([name] IS NOT NULL)");

            entity.Property(e => e.PromptSettingId).HasColumnName("prompt_setting_id");
            entity.Property(e => e.Describe)
                .HasMaxLength(255)
                .HasComment("描述")
                .HasColumnName("describe");
            entity.Property(e => e.IsDelete)
                .HasComment("1删除的  0未删除")
                .HasColumnName("is_delete");
            entity.Property(e => e.MaxTokens)
                .HasComment("最长回复")
                .HasColumnName("max_tokens");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasComment("配置名称")
                .HasColumnName("name");
            entity.Property(e => e.Temperature)
                .HasComment("随机性")
                .HasColumnName("temperature");
            entity.Property(e => e.TopK)
                .HasComment("最长长度")
                .HasColumnName("top_k");
            entity.Property(e => e.TopP)
                .HasComment("topP")
                .HasColumnName("top_p");
        });

        modelBuilder.Entity<TLlmSkLog>(entity =>
        {
            entity.HasKey(e => e.SkLogId);

            entity.ToTable("t_llm_sk_logs");

            entity.Property(e => e.SkLogId)
                .HasMaxLength(50)
                .HasColumnName("sk_log_id");
            entity.Property(e => e.Completion).HasColumnName("completion");
            entity.Property(e => e.CompletionCheckFailReason)
                .HasMaxLength(1000)
                .HasColumnName("completion_check_fail_reason");
            entity.Property(e => e.CompletionTime).HasColumnName("completion_time");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(36)
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.Function)
                .HasMaxLength(500)
                .HasColumnName("function");
            entity.Property(e => e.FunctionArguments).HasColumnName("function_arguments");
            entity.Property(e => e.FunctionResult).HasColumnName("function_result");
            entity.Property(e => e.Identification)
                .HasMaxLength(36)
                .HasColumnName("identification");
            entity.Property(e => e.InputTime).HasColumnName("input_time");
            entity.Property(e => e.IsPassedCompletionCheck).HasColumnName("is_passed_completion_check");
            entity.Property(e => e.IsPassedPromptCheck).HasColumnName("is_passed_prompt_check");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");
            entity.Property(e => e.Prompt).HasColumnName("prompt");
            entity.Property(e => e.PromptCheckFailReason)
                .HasMaxLength(1000)
                .HasColumnName("prompt_check_fail_reason");
            entity.Property(e => e.PromptId)
                .HasMaxLength(500)
                .HasColumnName("prompt_id");
            entity.Property(e => e.Provider).HasColumnName("provider");
            entity.Property(e => e.ScenarioDescription)
                .HasMaxLength(500)
                .HasColumnName("scenario_description");
            entity.Property(e => e.ScenarioType).HasColumnName("scenario_type");
            entity.Property(e => e.UsedCompletionToken).HasColumnName("used_completion_token");
            entity.Property(e => e.UsedPromptToken).HasColumnName("used_prompt_token");
            entity.Property(e => e.UsedTotalToken).HasColumnName("used_total_token");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<TLog>(entity =>
        {
            entity.ToTable("t_log");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Request).HasColumnName("request");
            entity.Property(e => e.Responseq).HasColumnName("responseq");
        });

        modelBuilder.Entity<TMembershipBenefit>(entity =>
        {
            entity.HasKey(e => e.MembershipBenefitId);

            entity.ToTable("t_membership_benefit");

            entity.Property(e => e.MembershipBenefitId).HasColumnName("membership_benefit_id");
            entity.Property(e => e.BenefitCode)
                .HasMaxLength(50)
                .HasColumnName("benefit_code");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.MembershipCode)
                .HasMaxLength(50)
                .HasColumnName("membership_code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TMembershipLevel>(entity =>
        {
            entity.HasKey(e => e.MembershipLevelId);

            entity.ToTable("t_membership_level");

            entity.Property(e => e.MembershipLevelId).HasColumnName("membership_level_id");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.MembershipCode)
                .HasMaxLength(50)
                .HasColumnName("membership_code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId);

            entity.ToTable("t_message");

            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.FromName)
                .HasMaxLength(50)
                .HasColumnName("from_name");
            entity.Property(e => e.FromUid).HasColumnName("from_uid");
            entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
            entity.Property(e => e.Message)
                .HasMaxLength(1000)
                .HasColumnName("message");
            entity.Property(e => e.MessageTopicId).HasColumnName("message_topic_id");
        });

        modelBuilder.Entity<TMessageTopic>(entity =>
        {
            entity.HasKey(e => e.MessageTopicId);

            entity.ToTable("t_message_topic");

            entity.Property(e => e.MessageTopicId).HasColumnName("message_topic_id");
            entity.Property(e => e.IsReplay).HasColumnName("is_replay");
            entity.Property(e => e.LastMessage)
                .HasMaxLength(1000)
                .HasColumnName("last_message");
            entity.Property(e => e.LastUpdatedTime).HasColumnName("last_updated_time");
            entity.Property(e => e.SessionOwner).HasColumnName("session_owner");
        });

        modelBuilder.Entity<TMinProgramScheduledTask>(entity =>
        {
            entity.ToTable("t_min_program_scheduled_task", tb => tb.HasComment("小程序定时任务表"));

            entity.HasIndex(e => e.MinProgramManuallyId, "fk_min_program_manually_id");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasComment("创建人id")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasComment("创建人姓名")
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn)
                .HasComment("创建时间")
                .HasColumnName("created_on");
            entity.Property(e => e.EndTime)
                .HasComment("重复结束时间")
                .HasColumnName("end_time");
            entity.Property(e => e.FirstStepParam)
                .HasComment("小程序第一步执行的参数")
                .HasColumnName("first_step_param");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.IsDisabled)
                .HasComment("是否不再执行")
                .HasColumnName("is_disabled");
            entity.Property(e => e.LastUpdateTime)
                .HasComment("更新时间")
                .HasColumnName("last_update_time");
            entity.Property(e => e.MinProgramManuallyId)
                .HasMaxLength(36)
                .HasComment("所属小程序会话id")
                .HasColumnName("min_program_manually_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment("定时任务名称")
                .HasColumnName("name");
            entity.Property(e => e.RepeatContent)
                .HasMaxLength(255)
                .HasComment("重复规则内容")
                .HasColumnName("repeat_content");
            entity.Property(e => e.RepeatType)
                .HasComment("重复规则，0=每天某个时间点，1=每隔几个小时")
                .HasColumnName("repeat_type");
            entity.Property(e => e.SaveContent)
                .HasMaxLength(255)
                .HasComment("保存内容")
                .HasColumnName("save_content");
            entity.Property(e => e.SaveType)
                .HasComment("保存类型，0=保存到知识库，1=发送到会话")
                .HasColumnName("save_type");

            entity.HasOne(d => d.MinProgramManually).WithMany(p => p.TMinProgramScheduledTasks)
                .HasForeignKey(d => d.MinProgramManuallyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_min_program_manually_id");
        });

        modelBuilder.Entity<TMinProgramScheduledTaskRecord>(entity =>
        {
            entity.ToTable("t_min_program_scheduled_task_record");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");
            entity.Property(e => e.ErrorMessage)
                .HasComment("失败原因")
                .HasColumnName("error_message");
            entity.Property(e => e.ExecDuration)
                .HasComment("执行时长")
                .HasColumnName("exec_duration");
            entity.Property(e => e.ExecType)
                .HasComment("执行来源，0=手工，1=自动")
                .HasColumnName("exec_type");
            entity.Property(e => e.MinProgramTaskId)
                .HasMaxLength(36)
                .HasComment("小程序定时任务id")
                .HasColumnName("min_program_task_id");
            entity.Property(e => e.Result)
                .HasComment("执行结果")
                .HasColumnName("result");
            entity.Property(e => e.StartExecTime)
                .HasComment("开始执行时间")
                .HasColumnName("start_exec_time");
            entity.Property(e => e.Status)
                .HasComment("执行状态，0=执行中，500=执行失败，200=执行成功")
                .HasColumnName("status");
        });

        modelBuilder.Entity<TMinProgramSkillInfo>(entity =>
        {
            entity.ToTable("t_min_program_skill_info", tb => tb.HasComment("\r\n小程序执行的步骤"));

            entity.HasIndex(e => e.FlowId, "index_t_min_program_skill_info_flowid");

            entity.HasIndex(e => e.DialogId, "index_t_min_program_skill_info_groupid");

            entity.HasIndex(e => e.Id, "index_t_min_program_skill_info_id").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(255)
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.DialogId)
                .HasMaxLength(50)
                .HasComment("一次小程序执行唯一编号")
                .HasColumnName("dialog_id");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.ForGroupId)
                .HasMaxLength(36)
                .HasComment("for的groupid，保证for内部index内的结果互不影响")
                .HasColumnName("for_group_id");
            entity.Property(e => e.FromId)
                .HasMaxLength(255)
                .HasComment("用户id")
                .HasColumnName("from_id");
            entity.Property(e => e.Index)
                .HasComment("执行的值\r\n0 for节点之外的，包含for\r\n1 for节点之内的，不包含for")
                .HasColumnName("index");
            entity.Property(e => e.InvodeType)
                .HasComment("调用类型\r\n /// <summary>\n      /// 会话\n      /// </summary>\n      Conversation = 1,\n\n      /// <summary>\n      /// AI小程序单独执行\n      /// </summary>\n      SingleAI=2,\n\n      /// <summary>\n      /// AI小程序测试\n      /// </summary>\n      AITest=3,")
                .HasColumnName("invode_type");
            entity.Property(e => e.IsFinish).HasColumnName("is_finish");
            entity.Property(e => e.MainDialogId)
                .HasMaxLength(36)
                .HasComment("主流程的dialog_id")
                .HasColumnName("main_dialog_id");
            entity.Property(e => e.MainProcessId)
                .HasMaxLength(36)
                .HasComment("自关联，如果执行的是子流程，这里记录的是调用子流程的主流程小程序的id")
                .HasColumnName("main_process_id");
            entity.Property(e => e.NodeId)
                .HasMaxLength(255)
                .HasComment("node_id")
                .HasColumnName("node_id");
            entity.Property(e => e.Step).HasColumnName("step");
            entity.Property(e => e.TimeConsuming)
                .HasComment("节点消耗时间")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("time_consuming");
            entity.Property(e => e.Version)
                .HasMaxLength(255)
                .HasColumnName("version");
        });

        modelBuilder.Entity<TMinProgramSkillInfoFlowApiInvokeRecord>(entity =>
        {
            entity.HasKey(e => e.JobId);

            entity.ToTable("t_min_program_skill_info_flow_api_invoke_record", tb => tb.HasComment("小程序flowapi调用记录"));

            entity.HasIndex(e => e.JobId, "t_min_program_skill_in_resourceId_xfdsafasxxx").IsUnique();

            entity.Property(e => e.JobId)
                .HasMaxLength(36)
                .HasColumnName("job_id");
            entity.Property(e => e.FinishTime)
                .HasComment("结束时间")
                .HasColumnName("finish_time");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.InvokeTime)
                .HasComment("调用时间")
                .HasColumnName("invoke_time");
            entity.Property(e => e.ResourceId)
                .HasMaxLength(36)
                .HasComment("资源ID")
                .HasColumnName("resource_id");
            entity.Property(e => e.Status)
                .HasComment("状态值")
                .HasColumnName("status");
        });

        modelBuilder.Entity<TMinProgramSkillInfoFlowApiInvokeRecordContext>(entity =>
        {
            entity.HasKey(e => e.JobId);

            entity.ToTable("t_min_program_skill_info_flow_api_invoke_record_context", tb => tb.HasComment("小程序flowapi调用记录"));

            entity.HasIndex(e => e.JobId, "t_min_program_skill_in_resourceId_xfdsafas").IsUnique();

            entity.Property(e => e.JobId)
                .HasMaxLength(36)
                .HasColumnName("job_id");
            entity.Property(e => e.MinniProgramProgram)
                .HasComment("小程序请求的值")
                .HasColumnName("minni_program_program");
            entity.Property(e => e.RequestParam)
                .HasMaxLength(2000)
                .HasComment("接口请求参数")
                .HasColumnName("request_param");
            entity.Property(e => e.ResponseContext)
                .HasComment("返回值")
                .HasColumnName("response_context");

            entity.HasOne(d => d.Job).WithOne(p => p.TMinProgramSkillInfoFlowApiInvokeRecordContext)
                .HasForeignKey<TMinProgramSkillInfoFlowApiInvokeRecordContext>(d => d.JobId)
                .HasConstraintName("Fk_t_min_program_skill_info_fl_dsfasdfas");
        });

        modelBuilder.Entity<TMinProgramSkillInfoForResult>(entity =>
        {
            entity.ToTable("t_min_program_skill_info_for_result");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.DialogId)
                .HasMaxLength(50)
                .HasComment("一次小程序执行唯一编号")
                .HasColumnName("dialog_id");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.ForNodeResultType)
                .HasMaxLength(255)
                .HasComment("for的返回类型array<string>,array<object>")
                .HasColumnName("for_node_result_type");
            entity.Property(e => e.FromId)
                .HasMaxLength(255)
                .HasComment("用户id")
                .HasColumnName("from_id");
            entity.Property(e => e.Index)
                .HasComment("第几个for的内容")
                .HasColumnName("index");
            entity.Property(e => e.InvodeType)
                .HasComment("调用类型\r\n /// <summary>\n      /// 会话\n      /// </summary>\n      Conversation = 1,\n\n      /// <summary>\n      /// AI小程序单独执行\n      /// </summary>\n      SingleAI=2,\n\n      /// <summary>\n      /// AI小程序测试\n      /// </summary>\n      AITest=3,")
                .HasColumnName("invode_type");
            entity.Property(e => e.NodeId)
                .HasMaxLength(255)
                .HasComment("node_id")
                .HasColumnName("node_id");
            entity.Property(e => e.Result)
                .HasMaxLength(1000)
                .HasColumnName("result");
            entity.Property(e => e.ResultType)
                .HasMaxLength(255)
                .HasComment("for内部返回节点值的类型 array<string>,array<object>,object,string")
                .HasColumnName("result_type");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("('1')")
                .HasComment("1:for")
                .HasColumnName("type");
        });

        modelBuilder.Entity<TMinProgramSkillInfoManually>(entity =>
        {
            entity.ToTable("t_min_program_skill_info_manually", tb => tb.HasComment("小程序手动执行的flow记录，\r\n执行步骤在t_min_program_skill_info，这里只记录列表"));

            entity.HasIndex(e => e.FlowId, "index_t_min_program_skill_info_flowid");

            entity.HasIndex(e => e.FlowName, "index_t_min_program_skill_info_groupid");

            entity.HasIndex(e => e.Id, "index_t_min_program_skill_info_id").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .HasComment("背景颜色")
                .HasColumnName("color");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.FlowName)
                .HasMaxLength(50)
                .HasComment("一次小程序执行唯一编号")
                .HasColumnName("flow_name");
            entity.Property(e => e.FromId)
                .HasMaxLength(255)
                .HasComment("用户id")
                .HasColumnName("from_id");
            entity.Property(e => e.InvodeType)
                .HasComment("调用类型\r\n /// <summary>\n      /// 会话\n      /// </summary>\n      Conversation = 1,\n\n      /// <summary>\n      /// AI小程序单独执行\n      /// </summary>\n      SingleAI=2,\n\n      /// <summary>\n      /// AI小程序测试\n      /// </summary>\n      AITest=3,")
                .HasColumnName("invode_type");
            entity.Property(e => e.IsPin)
                .HasComment("是否置顶")
                .HasColumnName("is_pin");
            entity.Property(e => e.ManuallyName)
                .HasMaxLength(255)
                .HasComment("用户端显示的小程序名称")
                .HasColumnName("manually_name");
            entity.Property(e => e.PinTime)
                .HasComment("置顶时间")
                .HasColumnName("pin_time");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
            entity.Property(e => e.WorkSpaceId)
                .HasComment("工作区ID")
                .HasColumnName("work_space_id");
        });

        modelBuilder.Entity<TMinProgramSkillInfoManuallyDetail>(entity =>
        {
            entity.ToTable("t_min_program_skill_info_manually_detail");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(36)
                .HasColumnName("conversation_id");
            entity.Property(e => e.MinProgramSkillInfoManuallyId)
                .HasMaxLength(36)
                .HasColumnName("min_program_skill_info_manually_id");
        });

        modelBuilder.Entity<TMinProgramSkillInfoParam>(entity =>
        {
            entity.ToTable("t_min_program_skill_info_param");

            entity.HasIndex(e => e.Id, "index_t_min_program_skill_info_param_id").IsUnique();

            entity.HasIndex(e => e.MinProgramInfoId, "index_t_min_program_skill_info_param_xxxxxsiek");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Key)
                .HasMaxLength(255)
                .HasColumnName("key");
            entity.Property(e => e.MinProgramInfoId)
                .HasMaxLength(36)
                .HasColumnName("min_program_info_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ParamType)
                .HasMaxLength(255)
                .HasComment("参数类型，input，textarea")
                .HasColumnName("param_type");
            entity.Property(e => e.Step).HasColumnName("step");
            entity.Property(e => e.Type)
                .HasComment("1:input 2:output")
                .HasColumnName("type");
            entity.Property(e => e.Value)
                .HasMaxLength(1000)
                .HasColumnName("value");
            entity.Property(e => e.VariableId)
                .HasComment("唯一编号")
                .HasColumnName("variableId");

            entity.HasOne(d => d.MinProgramInfo).WithMany(p => p.TMinProgramSkillInfoParams)
                .HasForeignKey(d => d.MinProgramInfoId)
                .HasConstraintName("FK_t_min_program_skill_info_PRAM_XXXXXX");
        });

        modelBuilder.Entity<TMinProgramSkillPathfindingArchive>(entity =>
        {
            entity.ToTable("t_min_program_skill_pathfinding_archive", tb => tb.HasComment("小程序的寻路算法归档表"));

            entity.HasIndex(e => e.FlowId, "IDX_pathfinding_archive_FLOW_ID");

            entity.HasIndex(e => e.Id, "IDX_pathfinding_archive_ID").IsUnique();

            entity.HasIndex(e => e.DialogId, "IDX_pathfinding_archive_dialog_id");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.BlobUrl)
                .HasMaxLength(500)
                .HasComment("blob的地址")
                .HasColumnName("blob_url");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.DialogId)
                .HasMaxLength(200)
                .HasComment("对话id")
                .HasColumnName("dialog_id");
            entity.Property(e => e.FlowId)
                .HasComment("小程序id")
                .HasColumnName("flow_id");
        });

        modelBuilder.Entity<TMinProgramSkillRunEdgeInfoV5>(entity =>
        {
            entity.ToTable("t_min_program_skill_run_edge_info_v5");

            entity.HasIndex(e => e.EdgeId, "index_t_min_program_skill_info_edge_edgeid");

            entity.HasIndex(e => e.Id, "index_t_min_program_skill_info_edge_id").IsUnique();

            entity.HasIndex(e => e.RunNodeId, "index_t_min_program_skill_info_edge_runNOdeid");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.EdgeId)
                .HasComment("线的唯一ID")
                .HasColumnName("edge_id");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.Index)
                .HasDefaultValueSql("('999')")
                .HasComment("分支是-1,1,2,  其他都是999")
                .HasColumnName("index");
            entity.Property(e => e.IsFakeRuned)
                .HasComment("虚拟要跑的（分支才有）")
                .HasColumnName("is_fake_runed");
            entity.Property(e => e.IsRealRuned)
                .HasComment("真正要跑的")
                .HasColumnName("is_real_runed");
            entity.Property(e => e.RunNodeId)
                .HasMaxLength(36)
                .HasComment("外键")
                .HasColumnName("run_node_id");
            entity.Property(e => e.Source)
                .HasMaxLength(1000)
                .HasComment("来源  都是node_id")
                .HasColumnName("source");
            entity.Property(e => e.SourceName)
                .HasMaxLength(1000)
                .HasComment("来源的名字")
                .HasColumnName("source_name");
            entity.Property(e => e.Target)
                .HasMaxLength(1000)
                .HasComment("去处  都是node_id")
                .HasColumnName("target");
            entity.Property(e => e.TargetName)
                .HasMaxLength(1000)
                .HasComment("去除的名字")
                .HasColumnName("target_name");
        });

        modelBuilder.Entity<TMinProgramSkillRunInfoV5>(entity =>
        {
            entity.ToTable("t_min_program_skill_run_info_v5");

            entity.HasIndex(e => new { e.DialogId, e.ConversationId, e.FlowId, e.InvodeType, e.FromId, e.BlockIndex }, "IX_run_info_v5_block_index");

            entity.HasIndex(e => new { e.DialogId, e.ConversationId, e.FlowId, e.InvodeType, e.FromId, e.ForGroupId }, "IX_run_info_v5_for_group");

            entity.HasIndex(e => new { e.DialogId, e.ConversationId, e.FlowId, e.InvodeType, e.FromId }, "IX_run_info_v5_main");

            entity.HasIndex(e => e.DialogId, "index_t_min_program_skill_info_XXdialog_id");

            entity.HasIndex(e => e.FlowId, "index_t_min_program_skill_info_XXflowid");

            entity.HasIndex(e => e.Id, "index_t_min_program_skill_info_XXid").IsUnique();

            entity.HasIndex(e => e.ConversationId, "index_t_min_program_skill_info_conversation_id");

            entity.HasIndex(e => e.FromId, "index_t_min_program_skill_info_from_id");

            entity.HasIndex(e => e.ForGroupId, "index_t_min_program_skill_info_group_id");

            entity.HasIndex(e => e.InvodeType, "index_t_min_program_skill_info_invode_type");

            entity.HasIndex(e => e.NodeId, "index_t_min_program_skill_info_node_id");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.BlockIndex)
                .HasComment("for的index")
                .HasColumnName("block_index");
            entity.Property(e => e.BlockNodeId)
                .HasMaxLength(255)
                .HasComment("自建ID，对应此表的id，只有for node 才有")
                .HasColumnName("block_node_id");
            entity.Property(e => e.ConversationId).HasColumnName("conversation_id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.DialogId)
                .HasMaxLength(50)
                .HasComment("一次小程序执行唯一编号")
                .HasColumnName("dialog_id");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.ForGroupId)
                .HasMaxLength(36)
                .HasComment("for的groupid，保证for内部index内的结果互不影响")
                .HasColumnName("for_group_id");
            entity.Property(e => e.FromId)
                .HasComment("用户id")
                .HasColumnName("from_id");
            entity.Property(e => e.InvodeType)
                .HasComment("调用类型\r\n /// <summary>\n      /// 会话\n      /// </summary>\n      Conversation = 1,\n\n      /// <summary>\n      /// AI小程序单独执行\n      /// </summary>\n      SingleAI=2,\n\n      /// <summary>\n      /// AI小程序测试\n      /// </summary>\n      AITest=3,")
                .HasColumnName("invode_type");
            entity.Property(e => e.IsRuned)
                .HasComment("是否跑过")
                .HasColumnName("is_runed");
            entity.Property(e => e.NodeId)
                .HasComment("node_id")
                .HasColumnName("node_id");
            entity.Property(e => e.NodeName)
                .HasMaxLength(255)
                .HasComment("node名字")
                .HasColumnName("node_name");
            entity.Property(e => e.NodeType)
                .HasMaxLength(255)
                .HasComment("node的类型")
                .HasColumnName("node_type");
            entity.Property(e => e.Step)
                .HasComment("每一步，block里面从1开始")
                .HasColumnName("step");
        });

        modelBuilder.Entity<TMyAssistent>(entity =>
        {
            entity.HasKey(e => e.MyAssistentId);

            entity.ToTable("t_my_assistent");

            entity.Property(e => e.MyAssistentId).HasColumnName("my_assistent_id");
            entity.Property(e => e.AssistentLibraryId).HasColumnName("assistent_library_id");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.MyAssistentLogo)
                .HasMaxLength(2000)
                .HasColumnName("my_assistent_logo");
            entity.Property(e => e.MyAssistentName)
                .HasMaxLength(50)
                .HasColumnName("my_assistent_name");
            entity.Property(e => e.Uid).HasColumnName("uid");
        });

        modelBuilder.Entity<TNodeTemplate>(entity =>
        {
            entity.HasKey(e => e.NodeTemplateId);

            entity.ToTable("t_node_template");

            entity.Property(e => e.NodeTemplateId).HasColumnName("node_template_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.EffectiveTime).HasColumnName("effective_time");
            entity.Property(e => e.ExpiredTime).HasColumnName("expired_time");
            entity.Property(e => e.Filters)
                .HasMaxLength(500)
                .HasColumnName("filters");
            entity.Property(e => e.IsDisabled).HasColumnName("is_disabled");
            entity.Property(e => e.IsSystem).HasColumnName("is_system");
            entity.Property(e => e.LastUpdateBy).HasColumnName("last_update_by");
            entity.Property(e => e.LastUpdateByName)
                .HasMaxLength(50)
                .HasColumnName("last_update_by_name");
            entity.Property(e => e.LastUpdateOn).HasColumnName("last_update_on");
            entity.Property(e => e.LearningId).HasColumnName("learning_id");
            entity.Property(e => e.NodeType).HasColumnName("node_type");
            entity.Property(e => e.Point)
                .HasMaxLength(100)
                .HasColumnName("point");
            entity.Property(e => e.PointDescription)
                .HasMaxLength(500)
                .HasColumnName("point_description");
            entity.Property(e => e.PointOrderIndex).HasColumnName("point_order_index");
            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.PurposeId).HasColumnName("purpose_id");
        });

        modelBuilder.Entity<TNotification>(entity =>
        {
            entity.HasKey(e => e.NotificationId);

            entity.ToTable("t_notification");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.Content)
                .HasMaxLength(1000)
                .HasColumnName("content");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(100)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.EffectiveDate).HasColumnName("effective_date");
            entity.Property(e => e.ExpiredDate).HasColumnName("expired_date");
            entity.Property(e => e.IsDisabled).HasColumnName("is_disabled");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TOperationAuditLog>(entity =>
        {
            entity.ToTable("t_operation_audit_log");

            entity.HasIndex(e => e.ActionCode, "idx_operation_audit_log_action_code");

            entity.HasIndex(e => e.CreatedAt, "idx_operation_audit_log_created_at");

            entity.HasIndex(e => new { e.ModuleCode, e.BizId }, "idx_operation_audit_log_module_biz");

            entity.HasIndex(e => e.OperatorId, "idx_operation_audit_log_operator_id");

            entity.Property(e => e.Id)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.ActionCode)
                .HasMaxLength(50)
                .HasComment("操作编码")
                .HasColumnName("action_code");
            entity.Property(e => e.BizId)
                .HasMaxLength(64)
                .HasComment("业务对象ID")
                .HasColumnName("biz_id");
            entity.Property(e => e.BizName)
                .HasMaxLength(200)
                .HasComment("业务对象名称")
                .HasColumnName("biz_name");
            entity.Property(e => e.Content)
                .HasComment("操作时记录的配置快照")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ModuleCode)
                .HasMaxLength(50)
                .HasComment("模块编码，如 AGENT / MINI_PROGRAM")
                .HasColumnName("module_code");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(50)
                .HasComment("模块名称，如 智能体 / 小程序")
                .HasColumnName("module_name");
            entity.Property(e => e.OperatorId)
                .HasComment("操作人ID")
                .HasColumnName("operator_id");
            entity.Property(e => e.OperatorName)
                .HasMaxLength(50)
                .HasComment("操作人姓名")
                .HasColumnName("operator_name");
        });

        modelBuilder.Entity<TPersonality>(entity =>
        {
            entity.HasKey(e => e.PersonalityId);

            entity.ToTable("t_personality");

            entity.Property(e => e.PersonalityId).HasColumnName("personality_id");
            entity.Property(e => e.Content)
                .HasMaxLength(2000)
                .HasColumnName("content");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TPlatform>(entity =>
        {
            entity.HasKey(e => e.PlatformId);

            entity.ToTable("t_platform");

            entity.Property(e => e.PlatformId).HasColumnName("platform_id");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(200)
                .HasColumnName("logo_url");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.OrderIndex).HasColumnName("order_index");
        });

        modelBuilder.Entity<TPlugin>(entity =>
        {
            entity.ToTable("t_plugin", tb => tb.HasComment("插件后台配置\r\n最终要组成一个json，传递给openai\r\n\"aiPlugin\": {\r\n    \"schemaVersion\": \"v1\",\r\n    \"nameForModel\": \"MathPlugin\",\r\n    \"nameForHuman\": \"Math Plugin\",\r\n    \"descriptionForModel\": \"Used to perform math operations (i.e., add, subtract, multiple, divide).\",\r\n    \"descriptionForHuman\": \"Used to perform math operations.\",\r\n    \"auth\": {\r\n        \"type\": \"none\"\r\n    },\r\n    \"api\": {\r\n        \"type\": \"openapi\",\r\n        \"url\": \"{url}/swagger.json\"\r\n    },\r\n    \"logoUrl\": \"{url}/logo.png\",\r\n    \"contactEmail\": \"support@example.com\",\r\n    \"legalInfoUrl\": \"http://www.example.com/legal\"\r\n}"));

            entity.HasIndex(e => e.Uuid, "idx_plugin_uuid")
                .IsUnique()
                .HasFilter("([uuid] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiUrl)
                .HasMaxLength(500)
                .HasComment("api的json地址")
                .HasColumnName("api_url");
            entity.Property(e => e.Auth)
                .HasMaxLength(2000)
                .HasComment("暂存header和value来鉴权 e.g [ Authorization:Bearer ******I ]")
                .HasColumnName("auth");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.CreatedBy)
                .HasComment("创建人id")
                .HasColumnName("created_by");
            entity.Property(e => e.DescriptionForModel)
                .HasComment("更好地为模型量身定制的描述，例如令牌上下文长度注意事项或关键字用法，以改进插件提示。最多 8,000 个字符")
                .HasColumnName("description_for_model");
            entity.Property(e => e.DisplayType)
                .HasComment("ai小程序的插件显示外面的类型：0=不显示在外面，1=知识库与数据，2=通知")
                .HasColumnName("display_type");
            entity.Property(e => e.FromSouce)
                .HasDefaultValueSql("('1')")
                .HasComment("1:内部编写的plugin 2:logic app")
                .HasColumnName("from_souce");
            entity.Property(e => e.IsContainKnowleage)
                .HasComment("是否包含知识库节点")
                .HasColumnName("is_contain_knowleage");
            entity.Property(e => e.IsDelete)
                .HasComment("是否删除")
                .HasColumnName("is_delete");
            entity.Property(e => e.IsValid)
                .IsRequired()
                .HasDefaultValueSql("('1')")
                .HasComment("启用，禁用")
                .HasColumnName("is_valid");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(500)
                .HasComment("插件的logo地址")
                .HasColumnName("logo_url");
            entity.Property(e => e.NameForModel)
                .HasMaxLength(50)
                .HasComment("模型将用于定位插件的名称（不允许空格，只能使用字母和数字）。最多 50 个字符")
                .HasColumnName("name_for_model");
            entity.Property(e => e.NameSpace)
                .HasMaxLength(20)
                .HasComment("命令空间，sk会与方法名拼在一起")
                .HasColumnName("name_space");
            entity.Property(e => e.OperationsToExclude)
                .HasMaxLength(2000)
                .HasComment("解析时排除那些接口。以 , 分割;")
                .HasColumnName("operations_to_exclude");
            entity.Property(e => e.PluginType)
                .HasComment("看类：E_Plug_Plugin_Type")
                .HasColumnName("plugin_type");
            entity.Property(e => e.SuperAgentCategoryId)
                .HasComment("类别id")
                .HasColumnName("super_agent_category_id");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("('1')")
                .HasComment("1：AI")
                .HasColumnName("type");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
            entity.Property(e => e.Uuid)
                .HasMaxLength(50)
                .HasColumnName("uuid");
        });

        modelBuilder.Entity<TPluginCopy1>(entity =>
        {
            entity.ToTable("t_plugin_copy1", tb => tb.HasComment("插件后台配置\r\n最终要组成一个json，传递给openai\r\n\"aiPlugin\": {\r\n    \"schemaVersion\": \"v1\",\r\n    \"nameForModel\": \"MathPlugin\",\r\n    \"nameForHuman\": \"Math Plugin\",\r\n    \"descriptionForModel\": \"Used to perform math operations (i.e., add, subtract, multiple, divide).\",\r\n    \"descriptionForHuman\": \"Used to perform math operations.\",\r\n    \"auth\": {\r\n        \"type\": \"none\"\r\n    },\r\n    \"api\": {\r\n        \"type\": \"openapi\",\r\n        \"url\": \"{url}/swagger.json\"\r\n    },\r\n    \"logoUrl\": \"{url}/logo.png\",\r\n    \"contactEmail\": \"support@example.com\",\r\n    \"legalInfoUrl\": \"http://www.example.com/legal\"\r\n}"));

            entity.HasIndex(e => e.Id, "index_t_plugin_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiUrl)
                .HasMaxLength(500)
                .HasComment("api的json地址")
                .HasColumnName("api_url");
            entity.Property(e => e.Auth)
                .HasMaxLength(2000)
                .HasComment("暂存header和value来鉴权 e.g [ Authorization:Bearer ******I ]")
                .HasColumnName("auth");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.CreatedBy)
                .HasComment("创建人id")
                .HasColumnName("created_by");
            entity.Property(e => e.DescriptionForModel)
                .HasComment("更好地为模型量身定制的描述，例如令牌上下文长度注意事项或关键字用法，以改进插件提示。最多 8,000 个字符")
                .HasColumnName("description_for_model");
            entity.Property(e => e.DisplayType)
                .HasComment("ai小程序的插件显示外面的类型：1=知识库与数据，2=通知")
                .HasColumnName("display_type");
            entity.Property(e => e.FromSouce)
                .HasDefaultValueSql("('1')")
                .HasComment("1:内部编写的plugin 2:logic app")
                .HasColumnName("from_souce");
            entity.Property(e => e.IsContainKnowleage)
                .HasComment("是否包含知识库节点")
                .HasColumnName("is_contain_knowleage");
            entity.Property(e => e.IsDelete)
                .HasComment("是否删除")
                .HasColumnName("is_delete");
            entity.Property(e => e.IsValid)
                .IsRequired()
                .HasDefaultValueSql("('1')")
                .HasComment("启用，禁用")
                .HasColumnName("is_valid");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(500)
                .HasComment("插件的logo地址")
                .HasColumnName("logo_url");
            entity.Property(e => e.NameForModel)
                .HasMaxLength(50)
                .HasComment("模型将用于定位插件的名称（不允许空格，只能使用字母和数字）。最多 50 个字符")
                .HasColumnName("name_for_model");
            entity.Property(e => e.NameSpace)
                .HasMaxLength(20)
                .HasComment("命令空间，sk会与方法名拼在一起")
                .HasColumnName("name_space");
            entity.Property(e => e.OperationsToExclude)
                .HasMaxLength(2000)
                .HasComment("解析时排除那些接口。以 , 分割;")
                .HasColumnName("operations_to_exclude");
            entity.Property(e => e.PluginType)
                .HasComment("AI小程序的插件类型：0=通用，1=python")
                .HasColumnName("plugin_type");
            entity.Property(e => e.SuperAgentCategoryId)
                .HasComment("类别id")
                .HasColumnName("super_agent_category_id");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("('1')")
                .HasComment("1：AI")
                .HasColumnName("type");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
            entity.Property(e => e.Uuid)
                .HasMaxLength(50)
                .HasColumnName("uuid");
        });

        modelBuilder.Entity<TProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("t_product");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .HasColumnName("brand");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.IsAnalysised)
                .HasDefaultValueSql("('0')")
                .HasColumnName("is_analysised");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasMaxLength(100)
                .HasColumnName("price");
            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.ProductLine)
                .HasMaxLength(100)
                .HasColumnName("product_line");
            entity.Property(e => e.ProductSummary).HasColumnName("product_summary");
            entity.Property(e => e.TargetUser)
                .HasMaxLength(200)
                .HasColumnName("target_user");
        });

        modelBuilder.Entity<TProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId);

            entity.ToTable("t_product_category");

            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.Cluster)
                .HasMaxLength(50)
                .HasColumnName("cluster");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.IsDisabled).HasColumnName("is_disabled");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.ParentProductCategoryId).HasColumnName("parent_product_category_id");
        });

        modelBuilder.Entity<TPromptHistory>(entity =>
        {
            entity.HasKey(e => e.PromptHistoryId);

            entity.ToTable("t_prompt_history");

            entity.Property(e => e.PromptHistoryId).HasColumnName("prompt_history_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.Prompt)
                .HasMaxLength(3000)
                .HasColumnName("prompt");
            entity.Property(e => e.Response)
                .HasMaxLength(3000)
                .HasColumnName("response");
        });

        modelBuilder.Entity<TPromptTemplateConfig>(entity =>
        {
            entity.ToTable("t_prompt_template_config");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Prompt).HasColumnName("prompt");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Uid).HasColumnName("uid");
        });

        modelBuilder.Entity<TPurpose>(entity =>
        {
            entity.HasKey(e => e.PurposeId);

            entity.ToTable("t_purpose");

            entity.Property(e => e.PurposeId).HasColumnName("purpose_id");
            entity.Property(e => e.Cluster)
                .HasMaxLength(50)
                .HasColumnName("cluster");
            entity.Property(e => e.Content)
                .HasMaxLength(2000)
                .HasColumnName("content");
            entity.Property(e => e.Isdelete).HasColumnName("isdelete");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId);

            entity.ToTable("t_question");

            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.OrderIndex).HasColumnName("order_index");
            entity.Property(e => e.QuestionnaireId).HasColumnName("questionnaire_id");
        });

        modelBuilder.Entity<TQuestionnaire>(entity =>
        {
            entity.HasKey(e => e.QuestionnaireId);

            entity.ToTable("t_questionnaire");

            entity.Property(e => e.QuestionnaireId).HasColumnName("questionnaire_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TQuestionnaireFeedback>(entity =>
        {
            entity.HasKey(e => e.QuestionnaireFeedbackId);

            entity.ToTable("t_questionnaire_feedback");

            entity.Property(e => e.QuestionnaireFeedbackId).HasColumnName("questionnaire_feedback_id");
            entity.Property(e => e.Answer)
                .HasMaxLength(100)
                .HasColumnName("answer");
            entity.Property(e => e.Conversition).HasColumnName("conversition");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.QuestionnaireId).HasColumnName("questionnaire_id");
            entity.Property(e => e.Summary).HasColumnName("summary");
            entity.Property(e => e.TopicId).HasColumnName("topic_id");
        });

        modelBuilder.Entity<TReptileAnalysis>(entity =>
        {
            entity.ToTable("t_reptile_analysis");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedTime)
                .HasComment("创建时间")
                .HasColumnName("created_time");
            entity.Property(e => e.Depth)
                .HasComment("深度 最少一层")
                .HasColumnName("depth");
            entity.Property(e => e.IsDelete)
                .HasComment("是否删除1.删除  0.可用")
                .HasColumnName("is_delete");
            entity.Property(e => e.IsEveryDayUpdate)
                .HasComment("是否是每天更新，1.是，0不是")
                .HasColumnName("is_every_day_update");
            entity.Property(e => e.LibraryId)
                .HasMaxLength(36)
                .HasComment("知识库id")
                .HasColumnName("library_id");
            entity.Property(e => e.Msg)
                .HasMaxLength(500)
                .HasComment("报错信息")
                .HasColumnName("msg");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Status)
                .HasComment("分析进度")
                .HasColumnName("status");
            entity.Property(e => e.Tags)
                .HasMaxLength(1000)
                .HasComment("标签")
                .HasColumnName("tags");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnName("update_time");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasComment("需要分析的网址")
                .HasColumnName("url");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<TReptileAnalysisResult>(entity =>
        {
            entity.ToTable("t_reptile_analysis_result");

            entity.HasIndex(e => e.Id, "index_t_url_analysis_result_id");

            entity.HasIndex(e => e.ReptileAnalysisId, "index_t_url_analysis_result_id_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedTime)
                .HasComment("创建时间")
                .HasColumnName("created_time");
            entity.Property(e => e.Msg)
                .HasMaxLength(500)
                .HasComment("报错信息")
                .HasColumnName("msg");
            entity.Property(e => e.ReptileAnalysisId).HasColumnName("reptile_analysis_id");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasComment("标题")
                .HasColumnName("title");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnName("update_time");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasComment("分析结果的url")
                .HasColumnName("url");

            entity.HasOne(d => d.ReptileAnalysis).WithMany(p => p.TReptileAnalysisResults)
                .HasForeignKey(d => d.ReptileAnalysisId)
                .HasConstraintName("t_reptile_analysis_result_ibfk_1");
        });

        modelBuilder.Entity<TResellerRebate>(entity =>
        {
            entity.HasKey(e => e.ResellerRebateId);

            entity.ToTable("t_reseller_rebate");

            entity.Property(e => e.ResellerRebateId).HasColumnName("reseller_rebate_id");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.RebateAmount).HasColumnName("rebate_amount");
            entity.Property(e => e.RebateRate).HasColumnName("rebate_rate");
            entity.Property(e => e.ResellerUid).HasColumnName("reseller_uid");
            entity.Property(e => e.ServiceOrderId).HasColumnName("service_order_id");
            entity.Property(e => e.ServiceOrderPaidAmount).HasColumnName("service_order_paid_amount");
            entity.Property(e => e.WithdrawalOrderNumber)
                .HasMaxLength(50)
                .HasColumnName("withdrawal_order_number");
            entity.Property(e => e.WithdrawalStatus).HasColumnName("withdrawal_status");
        });

        modelBuilder.Entity<TResellerWithdrawal>(entity =>
        {
            entity.HasKey(e => e.ResellerWithdrawalId);

            entity.ToTable("t_reseller_withdrawal");

            entity.Property(e => e.ResellerWithdrawalId).HasColumnName("reseller_withdrawal_id");
            entity.Property(e => e.Comments)
                .HasMaxLength(200)
                .HasColumnName("comments");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.WithdrawalOrderNumber)
                .HasMaxLength(50)
                .HasColumnName("withdrawal_order_number");
            entity.Property(e => e.WithdrawalPaymentStatus).HasColumnName("withdrawal_payment_status");
            entity.Property(e => e.WithdrawalTotalAmount).HasColumnName("withdrawal_total_amount");
        });

        modelBuilder.Entity<TSecretInfo>(entity =>
        {
            entity.ToTable("t_secret_info", tb => tb.HasComment("秘钥信息表"));

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasComment("主键")
                .HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");
            entity.Property(e => e.SecretKey)
                .HasMaxLength(255)
                .HasComment("秘钥名称")
                .HasColumnName("secret_key");
            entity.Property(e => e.SecretValue)
                .HasMaxLength(500)
                .HasComment("秘钥值(加密后的内容)")
                .HasColumnName("secret_value");
            entity.Property(e => e.SystemName)
                .HasMaxLength(255)
                .HasComment("系统名称")
                .HasColumnName("system_name");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<TSensitiveWord>(entity =>
        {
            entity.ToTable("t_sensitive_word");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Enable).HasColumnName("enable");
            entity.Property(e => e.Word)
                .HasMaxLength(255)
                .HasColumnName("word");
        });

        modelBuilder.Entity<TServiceOrder>(entity =>
        {
            entity.HasKey(e => e.ServiceOrderId);

            entity.ToTable("t_service_order");

            entity.Property(e => e.ServiceOrderId).HasColumnName("service_order_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.IsDisabled).HasColumnName("is_disabled");
            entity.Property(e => e.OrderChannel)
                .HasMaxLength(50)
                .HasColumnName("order_channel");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(200)
                .HasColumnName("order_number");
            entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            entity.Property(e => e.PaymentLastError)
                .HasMaxLength(200)
                .HasColumnName("payment_last_error");
            entity.Property(e => e.Remark)
                .HasMaxLength(500)
                .HasColumnName("remark");
            entity.Property(e => e.ServicePlanCount).HasColumnName("service_plan_count");
            entity.Property(e => e.ServicePlanId).HasColumnName("service_plan_id");
            entity.Property(e => e.TotalOrderAmount).HasColumnName("total_order_amount");
            entity.Property(e => e.TotalOrderComposeQuota).HasColumnName("total_order_compose_quota");
            entity.Property(e => e.TotalOrderWordQuota).HasColumnName("total_order_word_quota");
            entity.Property(e => e.Uid).HasColumnName("uid");
        });

        modelBuilder.Entity<TServiceOrderAllocation>(entity =>
        {
            entity.HasKey(e => e.ServiceOrderAllocationId);

            entity.ToTable("t_service_order_allocation");

            entity.Property(e => e.ServiceOrderAllocationId).HasColumnName("service_order_allocation_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.ServiceOrderId).HasColumnName("service_order_id");
            entity.Property(e => e.Uid).HasColumnName("uid");
        });

        modelBuilder.Entity<TServicePlan>(entity =>
        {
            entity.HasKey(e => e.ServicePlanId);

            entity.ToTable("t_service_plan");

            entity.Property(e => e.ServicePlanId).HasColumnName("service_plan_id");
            entity.Property(e => e.ComposeCount).HasColumnName("compose_count");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EffectiveMonth).HasColumnName("effective_month");
            entity.Property(e => e.MembershipCode)
                .HasMaxLength(50)
                .HasColumnName("membership_code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PlanType)
                .HasMaxLength(50)
                .HasColumnName("plan_type");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ResellerLv1RebateRate).HasColumnName("reseller_lv1_rebate_rate");
            entity.Property(e => e.ResellerLv2RebateRate).HasColumnName("reseller_lv2_rebate_rate");
            entity.Property(e => e.SalesProgram)
                .HasMaxLength(20)
                .HasColumnName("sales_program");
            entity.Property(e => e.WordCount).HasColumnName("word_count");
        });

        modelBuilder.Entity<TSuperAgentCategory>(entity =>
        {
            entity.HasKey(e => e.SuperAgentCategoryId);

            entity.ToTable("t_super_agent_category");

            entity.Property(e => e.SuperAgentCategoryId).HasColumnName("super_agent_category_id");
            entity.Property(e => e.Category)
                .HasMaxLength(2000)
                .HasComment("类型")
                .HasColumnName("category");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasComment("代码号")
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasComment("描述")
                .HasColumnName("description");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(50)
                .HasComment("显示名称")
                .HasColumnName("display_name");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.Name)
                .HasMaxLength(2000)
                .HasColumnName("name");
            entity.Property(e => e.Sort)
                .HasComment("排序")
                .HasColumnName("sort");
            entity.Property(e => e.Type)
                .HasComment("分区，1=agent,2=plugin,3=ai小程序,4=知识库,5=管理标签,6=文档标签；7：用户反馈标签；8：敏感词；")
                .HasColumnName("type");
        });

        modelBuilder.Entity<TSuperAgentDepartmentMap>(entity =>
        {
            entity.ToTable("t_super_agent_department_map", tb => tb.HasComment("用户组与部门映射表"));

            entity.HasIndex(e => e.DepartmentCode, "idx_department_code");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(50)
                .HasComment("创建人")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");
            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(20)
                .HasComment("部门编号")
                .HasColumnName("department_code");
            entity.Property(e => e.EntityId)
                .HasComment("智能体id/小程序id")
                .HasColumnName("entity_id");
            entity.Property(e => e.PermissionType)
                .HasComment("权限类型：1=使用权限，2=编辑权限")
                .HasColumnName("permission_type");
            entity.Property(e => e.Type)
                .HasComment("1=智能体，2=小程序")
                .HasColumnName("type");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(50)
                .HasComment("更新人")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<TSuperAgentFunctionCalling>(entity =>
        {
            entity.HasKey(e => e.FunctionCallId);

            entity.ToTable("t_super_agent_function_calling");

            entity.Property(e => e.FunctionCallId).HasColumnName("function_call_id");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(50)
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DialogId)
                .HasMaxLength(50)
                .HasColumnName("dialog_id");
            entity.Property(e => e.FunctionDescription)
                .HasMaxLength(2000)
                .HasColumnName("function_description");
            entity.Property(e => e.FunctionInput).HasColumnName("function_input");
            entity.Property(e => e.FunctionName)
                .HasMaxLength(500)
                .HasColumnName("function_name");
            entity.Property(e => e.FunctionOutput).HasColumnName("function_output");
            entity.Property(e => e.TaskNumber)
                .HasMaxLength(50)
                .HasColumnName("task_number");
        });

        modelBuilder.Entity<TSuperAgentManageLable>(entity =>
        {
            entity.HasKey(e => e.AgentManageLableId);

            entity.ToTable("t_super_agent_manage_lable", tb => tb.HasComment("智能体管理标签"));

            entity.Property(e => e.AgentManageLableId).HasColumnName("agent_manage_lable_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.PermissionType)
                .HasComment("权限类型：1=使用权限，2=编辑权限")
                .HasColumnName("permission_type");
            entity.Property(e => e.SuperAgentCategoryId)
                .HasComment("管理标签id")
                .HasColumnName("super_agent_category_id");
            entity.Property(e => e.SuperAgentSettingId)
                .HasComment("智能体id")
                .HasColumnName("super_agent_setting_id");
        });

        modelBuilder.Entity<TSuperAgentQuickCommand>(entity =>
        {
            entity.HasKey(e => e.QuickCommandId);

            entity.ToTable("t_super_agent_quick_command");

            entity.Property(e => e.QuickCommandId).HasColumnName("quick_command_id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.JsonEx1).HasColumnName("json_ex1");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Prompt)
                .HasMaxLength(2000)
                .HasColumnName("prompt");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.SuperAgentSettingId).HasColumnName("super_agent_setting_id");
            entity.Property(e => e.Tip)
                .HasMaxLength(1000)
                .HasColumnName("tip");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");

            entity.HasOne(d => d.SuperAgentSetting).WithMany(p => p.TSuperAgentQuickCommands)
                .HasForeignKey(d => d.SuperAgentSettingId)
                .HasConstraintName("t_super_agent_quick_command_ibfk_1");
        });

        modelBuilder.Entity<TSuperAgentRelease>(entity =>
        {
            entity.HasKey(e => e.PublishId);

            entity.ToTable("t_super_agent_release");

            entity.Property(e => e.PublishId).HasColumnName("publish_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Remark).HasColumnName("remark");
            entity.Property(e => e.SuperAgentConfig).HasColumnName("super_agent_config");
            entity.Property(e => e.SuperAgentSettingId)
                .HasComment("agent id")
                .HasColumnName("super_agent_setting_id");
            entity.Property(e => e.Version)
                .HasMaxLength(255)
                .HasColumnName("version");
            entity.Property(e => e.VersionSpecialIdentification)
                .HasMaxLength(255)
                .HasColumnName("version_special_identification");

            entity.HasOne(d => d.SuperAgentSetting).WithMany(p => p.TSuperAgentReleases)
                .HasForeignKey(d => d.SuperAgentSettingId)
                .HasConstraintName("t_super_agent_release_ibfk_1");
        });

        modelBuilder.Entity<TSuperAgentSetting>(entity =>
        {
            entity.HasKey(e => e.SuperAgentSettingId);

            entity.ToTable("t_super_agent_setting");

            entity.Property(e => e.SuperAgentSettingId).HasColumnName("super_agent_setting_id");
            entity.Property(e => e.Category)
                .HasComment("agent类型；0：bach agent；1：founry agent")
                .HasColumnName("category");
            entity.Property(e => e.Count)
                .HasComment("使用次数")
                .HasColumnName("count");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.EnableFollowUpQuestions)
                .HasComment("启用追问：0：不启用；1：启用；")
                .HasColumnName("enable_follow_up_questions");
            entity.Property(e => e.EnableVrm)
                .HasComment("启用3d虚拟人")
                .HasColumnName("enable_vrm");
            entity.Property(e => e.HistoryCount)
                .HasComment("上下文轮数")
                .HasColumnName("history_count");
            entity.Property(e => e.IsAllowAttachPrivateKnowledgeBase)
                .HasComment("是否运行会话绑定个人知识库 0: 不允许 1： 运行")
                .HasColumnName("is_allow_attach_private_knowledge_base");
            entity.Property(e => e.IsAllowUploadTempDocument)
                .HasComment("允许上传临时文档；0：不允许；1：允许；")
                .HasColumnName("is_allow_upload_temp_document");
            entity.Property(e => e.IsPublish)
                .HasComment("0:未发布；1：已发布；")
                .HasColumnName("is_publish");
            entity.Property(e => e.IsPublishApi)
                .HasComment("有没有发布api")
                .HasColumnName("is_publish_api");
            entity.Property(e => e.IsRecommended).HasColumnName("is_recommended");
            entity.Property(e => e.IsSelectKnowledgeMustChatDoc)
                .HasComment("选中知识库文档后，是否必定跟文档对话；0：否（走意图判断）；1：是")
                .HasColumnName("is_select_knowledge_must_chat_doc");
            entity.Property(e => e.LastUpdateBy)
                .HasComment("最后修改人id")
                .HasColumnName("last_update_by");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.Logo)
                .HasMaxLength(200)
                .HasColumnName("logo");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.SendHistory)
                .HasComment("发送历史（问题的top3）")
                .HasColumnName("send_history");
            entity.Property(e => e.SuperAgentCategoryId).HasColumnName("super_agent_category_id");
            entity.Property(e => e.SystemMessage).HasColumnName("system_message");
            entity.Property(e => e.Temperature)
                .HasColumnType("decimal(11, 4)")
                .HasColumnName("temperature");
            entity.Property(e => e.UseFallbackAi)
                .HasComment("无引用资料的时候是否使用ai兜底")
                .HasColumnName("use_fallback_ai");
            entity.Property(e => e.UserTag)
                .HasMaxLength(500)
                .HasColumnName("user_tag");
            entity.Property(e => e.WelcomeMessage).HasColumnName("welcome_message");
        });

        modelBuilder.Entity<TSuperAgentSettingApiMessage>(entity =>
        {
            entity.ToTable("t_super_agent_setting_api_message");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Answer)
                .HasComment("回答")
                .HasColumnName("answer");
            entity.Property(e => e.Ask)
                .HasComment("问题")
                .HasColumnName("ask");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(36)
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.DialogId)
                .HasMaxLength(36)
                .HasColumnName("dialog_id");
            entity.Property(e => e.FromId)
                .HasMaxLength(36)
                .HasColumnName("from_id");
            entity.Property(e => e.Reference)
                .HasComment("引用")
                .HasColumnName("reference");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
        });

        modelBuilder.Entity<TSuperAgentSettingApiPublish>(entity =>
        {
            entity.ToTable("t_super_agent_setting_api_publish");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.SuperAgentSettingId).HasColumnName("super_agent_setting_id");
            entity.Property(e => e.Uid).HasColumnName("uid");
        });

        modelBuilder.Entity<TSuperAgentSettingCk>(entity =>
        {
            entity.HasKey(e => e.SuperAgentSettingId);

            entity.ToTable("t_super_agent_setting_ck");

            entity.Property(e => e.SuperAgentSettingId)
                .ValueGeneratedNever()
                .HasColumnName("super_agent_setting_id");
            entity.Property(e => e.IsValid).HasColumnName("is_valid");
            entity.Property(e => e.Limit).HasColumnName("limit");
            entity.Property(e => e.Similarity).HasColumnName("similarity");
        });

        modelBuilder.Entity<TSuperAgentSettingFlow>(entity =>
        {
            entity.HasKey(e => e.SuperAgentSettingFlowId);

            entity.ToTable("t_super_agent_setting_flow");

            entity.Property(e => e.SuperAgentSettingFlowId).HasColumnName("super_agent_setting_flow_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.SuperAgentSettingId).HasColumnName("super_agent_setting_id");
        });

        modelBuilder.Entity<TSuperAgentSettingKnowledgeBase>(entity =>
        {
            entity.HasKey(e => e.SuperAgentSettingKnowledgeBaseId);

            entity.ToTable("t_super_agent_setting_knowledge_base");

            entity.Property(e => e.SuperAgentSettingKnowledgeBaseId).HasColumnName("super_agent_setting_knowledge_base_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.KnowledgeBaseDescription)
                .HasMaxLength(200)
                .HasColumnName("knowledge_base_description");
            entity.Property(e => e.KnowledgeBaseId)
                .HasMaxLength(50)
                .HasColumnName("knowledge_base_id");
            entity.Property(e => e.KnowledgeBaseLogo)
                .HasMaxLength(200)
                .HasColumnName("knowledge_base_logo");
            entity.Property(e => e.KnowledgeBaseName)
                .HasMaxLength(50)
                .HasColumnName("knowledge_base_name");
            entity.Property(e => e.KnowledgeBaseSearchPolicyId)
                .HasMaxLength(36)
                .HasComment("知识库检索策略id")
                .HasColumnName("knowledge_base_search_policy_id");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.SuperAgentSettingId).HasColumnName("super_agent_setting_id");
        });

        modelBuilder.Entity<TSuperAgentSettingLlm>(entity =>
        {
            entity.ToTable("t_super_agent_setting_llm", tb => tb.HasComment("agent的模型选择\r\n"));

            entity.HasIndex(e => e.Id, "INDEX_SUPENT_AGENTG_LLM_INDEX").IsUnique();

            entity.HasIndex(e => e.SuperAgentSettingId, "INDEX_SUPENT_AGENTG_LLM_SETTING_ID");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.LlmModelName)
                .HasMaxLength(255)
                .HasComment("大模型语言")
                .HasColumnName("llm_model_name");
            entity.Property(e => e.LlmProvider)
                .HasComment("来源")
                .HasColumnName("llm_provider");
            entity.Property(e => e.LlmSettingName)
                .HasMaxLength(255)
                .HasComment("配置的名字")
                .HasColumnName("llm_setting_name");
            entity.Property(e => e.ModelIsSupportFunction)
                .HasComment("模型是否支持function calling")
                .HasColumnName("model_is_support_function");
            entity.Property(e => e.SuperAgentSettingId).HasColumnName("super_agent_setting_id");
            entity.Property(e => e.Type)
                .HasComment("大模型技能 ：1 知识库查询结果的总结：2")
                .HasColumnName("type");
        });

        modelBuilder.Entity<TSuperAgentSettingOuter>(entity =>
        {
            entity.HasKey(e => e.SuperAgentSettingId).HasName("PK__t_super___0A44913F5EBCA3C1");

            entity.ToTable("t_super_agent_setting_outer");

            entity.Property(e => e.SuperAgentSettingId)
                .ValueGeneratedNever()
                .HasColumnName("super_agent_setting_id");
            entity.Property(e => e.AgentName)
                .HasMaxLength(255)
                .HasColumnName("agent_name");
            entity.Property(e => e.Category)
                .HasComment("agent类型；0：bach agent；1：founry agent")
                .HasColumnName("category");
            entity.Property(e => e.ClientId)
                .HasMaxLength(200)
                .HasColumnName("client_id");
            entity.Property(e => e.ClientSecret)
                .HasMaxLength(500)
                .HasColumnName("client_secret");
            entity.Property(e => e.Endpoint)
                .HasMaxLength(500)
                .HasColumnName("endpoint");
            entity.Property(e => e.TenantId)
                .HasMaxLength(100)
                .HasColumnName("tenant_id");
        });

        modelBuilder.Entity<TSuperAgentSettingPermission>(entity =>
        {
            entity.HasKey(e => e.SuperAgentSettingPermissionId);

            entity.ToTable("t_super_agent_setting_permission");

            entity.Property(e => e.SuperAgentSettingPermissionId).HasColumnName("super_agent_setting_permission_id");
        });

        modelBuilder.Entity<TSuperAgentSettingPlugin>(entity =>
        {
            entity.HasKey(e => e.SuperAgentSettingPluginId);

            entity.ToTable("t_super_agent_setting_plugin");

            entity.Property(e => e.SuperAgentSettingPluginId).HasColumnName("super_agent_setting_plugin_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.HeaderInfo).HasColumnName("header_info");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.PluginDescription)
                .HasMaxLength(2000)
                .HasColumnName("plugin_description");
            entity.Property(e => e.PluginId).HasColumnName("plugin_id");
            entity.Property(e => e.SuperAgentSettingId).HasColumnName("super_agent_setting_id");
        });

        modelBuilder.Entity<TSuperAgentSettingPluginDataBase>(entity =>
        {
            entity.HasKey(e => e.SuperAgentSettingPluginDataBaseId);

            entity.ToTable("t_super_agent_setting_plugin_data_base", tb => tb.HasComment("数据库插件当前数据库的信息"));

            entity.Property(e => e.SuperAgentSettingPluginDataBaseId).HasColumnName("super_agent_setting_plugin_data_base_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.DataBaseId)
                .HasComment("数据库id")
                .HasColumnName("data_base_id");
            entity.Property(e => e.IntentionId)
                .HasComment("意图id")
                .HasColumnName("intention_id");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.PluginId)
                .HasComment("插件id")
                .HasColumnName("plugin_id");
            entity.Property(e => e.SuperAgentSettingId)
                .HasComment("智能体id")
                .HasColumnName("super_agent_setting_id");
        });

        modelBuilder.Entity<TSuperAgentSettingPluginDataBaseRelease>(entity =>
        {
            entity.HasKey(e => e.DataBasePublishId);

            entity.ToTable("t_super_agent_setting_plugin_data_base_release", tb => tb.HasComment("智能体版本对应的数据库插件信息"));

            entity.Property(e => e.DataBasePublishId).HasColumnName("data_base_publish_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.DataBaseId)
                .HasComment("数据库id")
                .HasColumnName("data_base_id");
            entity.Property(e => e.IntentionId)
                .HasComment("意图id")
                .HasColumnName("intention_id");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.PluginId)
                .HasComment("插件id")
                .HasColumnName("plugin_id");
            entity.Property(e => e.SuperAgentSettingId)
                .HasComment("智能体id")
                .HasColumnName("super_agent_setting_id");
            entity.Property(e => e.Version)
                .HasMaxLength(255)
                .HasComment("智能体版本")
                .HasColumnName("version");
        });

        modelBuilder.Entity<TSuperAgentSettingPresetQuestion>(entity =>
        {
            entity.ToTable("t_super_agent_setting_preset_question");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.PresetQuestion)
                .HasMaxLength(2000)
                .HasComment("预设问题")
                .HasColumnName("preset_question");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.SuperAgentSettingId).HasColumnName("super_agent_setting_id");
        });

        modelBuilder.Entity<TSuperAgentSettingQuickInstruction>(entity =>
        {
            entity.HasKey(e => e.SuperAgentSettingQuickInstructionId);

            entity.ToTable("t_super_agent_setting_quick_instruction", tb => tb.HasComment("助理的快捷指令"));

            entity.Property(e => e.SuperAgentSettingQuickInstructionId).HasColumnName("super_agent_setting_quick_instruction_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.FlowCard)
                .HasComment("小程序的第一步的输入卡片")
                .HasColumnName("flow_card");
            entity.Property(e => e.FlowId).HasColumnName("flow_id");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment("快捷指令名称")
                .HasColumnName("name");
            entity.Property(e => e.QuickInputContent)
                .HasComment("快捷输入内容")
                .HasColumnName("quick_input_content");
            entity.Property(e => e.SuperAgentSettingId).HasColumnName("super_agent_setting_id");
            entity.Property(e => e.Type)
                .HasComment("快捷指令类型：1=快速输入，2=AI小程序")
                .HasColumnName("type");
        });

        modelBuilder.Entity<TSuperAgentSettingVariable>(entity =>
        {
            entity.ToTable("t_super_agent_setting_variable");

            entity.HasIndex(e => e.SuperAgentSettingId, "super_agent_setting_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.SuperAgentSettingId).HasColumnName("super_agent_setting_id");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
            entity.Property(e => e.VariableDescription)
                .HasMaxLength(2000)
                .HasComment("变量描述")
                .HasColumnName("variable_description");
            entity.Property(e => e.VariableName)
                .HasMaxLength(255)
                .HasComment("变量名称")
                .HasColumnName("variable_name");

            entity.HasOne(d => d.SuperAgentSetting).WithMany(p => p.TSuperAgentSettingVariables)
                .HasForeignKey(d => d.SuperAgentSettingId)
                .HasConstraintName("t_super_agent_setting_variable_ibfk_1");
        });

        modelBuilder.Entity<TSuperAgentSettingVariableExample>(entity =>
        {
            entity.ToTable("t_super_agent_setting_variable_example");

            entity.HasIndex(e => e.SuperAgentSettingVariableId, "super_agent_setting_variable_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.ExampleContent)
                .HasMaxLength(2000)
                .HasComment("样例内容")
                .HasColumnName("example_content");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.SuperAgentSettingVariableId).HasColumnName("super_agent_setting_variable_id");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");

            entity.HasOne(d => d.SuperAgentSettingVariable).WithMany(p => p.TSuperAgentSettingVariableExamples)
                .HasForeignKey(d => d.SuperAgentSettingVariableId)
                .HasConstraintName("t_super_agent_setting_variable_example_ibfk_1");
        });

        modelBuilder.Entity<TSuperAgentSettingVrm>(entity =>
        {
            entity.ToTable("t_super_agent_setting_vrm");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.SuperAgentSettingId).HasColumnName("super_agent_setting_id");
            entity.Property(e => e.VrmId)
                .HasMaxLength(36)
                .HasComment("大模型技能 ：1 知识库查询结果的总结：2")
                .HasColumnName("vrm_id");
        });

        modelBuilder.Entity<TSuperAgentTask>(entity =>
        {
            entity.HasKey(e => e.TaskId);

            entity.ToTable("t_super_agent_task");

            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(50)
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DialogId)
                .HasMaxLength(50)
                .HasColumnName("dialog_id");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("('0')")
                .HasColumnName("is_deleted");
            entity.Property(e => e.Objective)
                .HasMaxLength(500)
                .HasColumnName("objective");
            entity.Property(e => e.Owner)
                .HasMaxLength(50)
                .HasComment("task owner")
                .HasColumnName("owner");
            entity.Property(e => e.OwnerName)
                .HasMaxLength(200)
                .HasColumnName("owner_name");
            entity.Property(e => e.ParentTaskNumber)
                .HasMaxLength(2000)
                .HasColumnName("parent_task_number");
            entity.Property(e => e.ResourceAction)
                .HasMaxLength(50)
                .HasColumnName("resource_action");
            entity.Property(e => e.ResourceId)
                .HasMaxLength(50)
                .HasColumnName("resource_id");
            entity.Property(e => e.ResourceName)
                .HasMaxLength(500)
                .HasColumnName("resource_name");
            entity.Property(e => e.ResourceType)
                .HasMaxLength(50)
                .HasColumnName("resource_type");
            entity.Property(e => e.Task)
                .HasMaxLength(500)
                .HasColumnName("task");
            entity.Property(e => e.TaskGeneration).HasColumnName("task_generation");
            entity.Property(e => e.TaskNumber)
                .HasMaxLength(50)
                .HasColumnName("task_number");
            entity.Property(e => e.TaskResult).HasColumnName("task_result");
            entity.Property(e => e.TaskResultEvaluation).HasColumnName("task_result_evaluation");
            entity.Property(e => e.TaskResultFormatRequirement)
                .HasMaxLength(500)
                .HasColumnName("task_result_format_requirement");
            entity.Property(e => e.TaskResultQualityScore).HasColumnName("task_result_quality_score");
            entity.Property(e => e.TaskStatus)
                .HasComment("0, Not Start, 1, Exectuing, 2 Complete")
                .HasColumnName("task_status");
            entity.Property(e => e.TaskType)
                .HasComment("0: User , 1 Agent")
                .HasColumnName("task_type");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
        });

        modelBuilder.Entity<TSuperAgentTaskDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId);

            entity.ToTable("t_super_agent_task_document");

            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(50)
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DialogId)
                .HasMaxLength(50)
                .HasColumnName("dialog_id");
            entity.Property(e => e.DocumentName)
                .HasMaxLength(500)
                .HasComment("文档名称")
                .HasColumnName("document_name");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
        });

        modelBuilder.Entity<TSuperAgentUserMap>(entity =>
        {
            entity.ToTable("t_super_agent_user_map", tb => tb.HasComment("用户组与用户的映射表"));

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.HasIndex(e => new { e.EntityId, e.Type }, "idx_entity_id_type");

            entity.HasIndex(e => e.Uid, "idx_uid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(50)
                .HasComment("创建人")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateTime)
                .HasComment("创建时间")
                .HasColumnName("create_time");
            entity.Property(e => e.EntityId)
                .HasComment("智能体id/小程序id")
                .HasColumnName("entity_id");
            entity.Property(e => e.PermissionType)
                .HasComment("权限类型：1=使用权限，2=编辑权限")
                .HasColumnName("permission_type");
            entity.Property(e => e.Type)
                .HasComment("1=智能体，2=小程序")
                .HasColumnName("type");
            entity.Property(e => e.Uid)
                .HasComment("员工id")
                .HasColumnName("uid");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(50)
                .HasComment("更新人")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<TTestManager>(entity =>
        {
            entity.ToTable("t_test_manager", tb => tb.HasComment("测试管理--考试"));

            entity.HasIndex(e => e.Id, "index_t_test_manager_id");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasComment("表的唯一标识，用于区分不同的记录")
                .HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasComment("进行该测试的具体时间")
                .HasColumnName("create_time");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasComment("该测试的详细简介，包括测试目的、范围等信息")
                .HasColumnName("description");
            entity.Property(e => e.ErrMsg)
                .HasMaxLength(255)
                .HasComment("错误信息")
                .HasColumnName("err_msg");
            entity.Property(e => e.FailCount).HasColumnName("fail_count");
            entity.Property(e => e.FromUid)
                .HasMaxLength(255)
                .HasColumnName("from_uid");
            entity.Property(e => e.FromUserName)
                .HasMaxLength(255)
                .HasColumnName("from_user_name");
            entity.Property(e => e.LlmModelName)
                .HasMaxLength(255)
                .HasComment("大模型语言")
                .HasColumnName("llm_model_name");
            entity.Property(e => e.LlmProvider)
                .HasComment("来源")
                .HasColumnName("llm_provider");
            entity.Property(e => e.LlmSettingName)
                .HasMaxLength(255)
                .HasComment("配置的名字")
                .HasColumnName("llm_setting_name");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment("测试的名称，简要描述该测试的主题")
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("('1')")
                .HasComment("1")
                .HasColumnName("status");
            entity.Property(e => e.SuccessCount).HasColumnName("success_count");
            entity.Property(e => e.TestSetId)
                .HasMaxLength(36)
                .HasComment("关联的测试集的唯一标识，用于确定该测试所属的测试集")
                .HasColumnName("test_set_id");
            entity.Property(e => e.TestSetQuestionFullInfo)
                .HasComment("用来测试的试卷信息")
                .HasColumnName("test_set_question_full_info");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .HasColumnName("token");
            entity.Property(e => e.TotalCount).HasColumnName("total_count");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
        });

        modelBuilder.Entity<TTestManagerObject>(entity =>
        {
            entity.ToTable("t_test_manager_object", tb => tb.HasComment("参加本次考试的考生"));

            entity.HasIndex(e => e.Id, "index_t_test_manager_dsfa").IsUnique();

            entity.HasIndex(e => e.TestManagerId, "index_t_test_managerdsfa_dfsa");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.AgentFullInfo)
                .HasComment("agent的所有信息")
                .HasColumnName("agent_full_info");
            entity.Property(e => e.AgentId)
                .HasMaxLength(255)
                .HasColumnName("agent_id");
            entity.Property(e => e.AgentKbInfo)
                .HasComment("kb的信息")
                .HasColumnName("agent_kb_info");
            entity.Property(e => e.AgentName)
                .HasMaxLength(255)
                .HasColumnName("agent_name");
            entity.Property(e => e.AgentSearchPolicy)
                .HasComment("智能体绑定知识库的检索策略信息")
                .HasColumnName("agent_search_policy");
            entity.Property(e => e.AgentVersion)
                .HasMaxLength(255)
                .HasComment("agent的版本号")
                .HasColumnName("agent_version");
            entity.Property(e => e.TestManagerId)
                .HasMaxLength(36)
                .HasColumnName("test_manager_id");
            entity.Property(e => e.TotalScore)
                .HasDefaultValueSql("('0.00')")
                .HasComment("agent 回答所有问题的总分")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_score");
            entity.Property(e => e.TotalScoringRate)
                .HasComment("得分率")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_scoring_rate");
            entity.Property(e => e.Type)
                .HasComment("1:agent")
                .HasColumnName("type");

            entity.HasOne(d => d.TestManager).WithMany(p => p.TTestManagerObjects)
                .HasForeignKey(d => d.TestManagerId)
                .HasConstraintName("FK_t_test_managerDSAF_DSFA");
        });

        modelBuilder.Entity<TTestRunTestInfoResult>(entity =>
        {
            entity.ToTable("t_test_run_test_info_result", tb => tb.HasComment("测试运行测试信息结果表（考试结果）"));

            entity.HasIndex(e => e.ConversationId, "IX_t_test_run_test_info_result_conversation_id");

            entity.HasIndex(e => e.DialogId, "IX_t_test_run_test_info_result_dialog_id");

            entity.HasIndex(e => e.AgentInstanceId, "idx_agent_instance_id");

            entity.HasIndex(e => new { e.AgentInstanceId, e.QuestionId }, "idx_agent_instance_question");

            entity.HasIndex(e => e.Id, "index_test_run_test_info_iddfsa1").IsUnique();

            entity.HasIndex(e => e.TTestManagerId, "t_test_manager_id");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasComment("记录唯一标识")
                .HasColumnName("id");
            entity.Property(e => e.AgentId)
                .HasMaxLength(36)
                .HasColumnName("agent_id");
            entity.Property(e => e.AgentInstanceId)
                .HasMaxLength(36)
                .HasComment("智能体实例ID，关联t_test_manager_object.id")
                .HasColumnName("agent_instance_id");
            entity.Property(e => e.AiReason)
                .HasMaxLength(2000)
                .HasComment("AI打分依据")
                .HasColumnName("ai_reason");
            entity.Property(e => e.AiScore)
                .HasComment("AI打分")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ai_score");
            entity.Property(e => e.Answer)
                .HasComment("回答")
                .HasColumnName("answer");
            entity.Property(e => e.ConversationId)
                .HasMaxLength(200)
                .HasComment("会话ID-用于追踪对话详情")
                .HasColumnName("conversation_id");
            entity.Property(e => e.CreateTime)
                .HasComment("测试时间")
                .HasColumnName("create_time");
            entity.Property(e => e.DialogId)
                .HasMaxLength(200)
                .HasComment("对话ID-用于追踪单轮对话")
                .HasColumnName("dialog_id");
            entity.Property(e => e.ErrMsg)
                .HasMaxLength(500)
                .HasComment("如果出错只有这个")
                .HasColumnName("err_msg");
            entity.Property(e => e.PersonReason)
                .HasMaxLength(2000)
                .HasComment("人为打分依据")
                .HasColumnName("person_reason");
            entity.Property(e => e.PersonScore)
                .HasComment("人为打分")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("person_score");
            entity.Property(e => e.Question)
                .HasComment("问题")
                .HasColumnName("question");
            entity.Property(e => e.QuestionId)
                .HasMaxLength(36)
                .HasColumnName("question_id");
            entity.Property(e => e.QuestionScore)
                .HasComment("问题分数")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("question_score");
            entity.Property(e => e.Score)
                .HasComment("得分")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("score");
            entity.Property(e => e.ScoringRate)
                .HasComment("得分率")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("scoring_rate");
            entity.Property(e => e.Status)
                .HasComment("1")
                .HasColumnName("status");
            entity.Property(e => e.TTestManagerId)
                .HasMaxLength(36)
                .HasColumnName("t_test_manager_id");

            entity.HasOne(d => d.AgentInstance).WithMany(p => p.TTestRunTestInfoResults)
                .HasForeignKey(d => d.AgentInstanceId)
                .HasConstraintName("fk_t_test_run_test_info_result_ibsfdsa2");

            entity.HasOne(d => d.TTestManager).WithMany(p => p.TTestRunTestInfoResults)
                .HasForeignKey(d => d.TTestManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("t_test_run_test_info_result_ibfk_1");
        });

        modelBuilder.Entity<TTestSet>(entity =>
        {
            entity.ToTable("t_test_set", tb => tb.HasComment("测试集（试卷）"));

            entity.HasIndex(e => e.Id, "index_test_set_id");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasComment("描述")
                .HasColumnName("description");
            entity.Property(e => e.FromUid)
                .HasMaxLength(255)
                .HasColumnName("from_uid");
            entity.Property(e => e.FromUserName)
                .HasMaxLength(255)
                .HasColumnName("from_user_name");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment(" 名字")
                .HasColumnName("name");
            entity.Property(e => e.Tag)
                .HasMaxLength(1000)
                .HasComment("标签")
                .HasColumnName("tag");
            entity.Property(e => e.TotalScore)
                .HasComment("总分")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_score");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
            entity.Property(e => e.UpdateUid)
                .HasMaxLength(255)
                .HasColumnName("update_uid");
            entity.Property(e => e.UpdateUserName)
                .HasMaxLength(255)
                .HasColumnName("update_user_name");
        });

        modelBuilder.Entity<TTestSetQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId);

            entity.ToTable("t_test_set_question", tb => tb.HasComment("测试集问题（考题）"));

            entity.HasIndex(e => e.TestSetId, "index_test_set_question_test_set_id");

            entity.Property(e => e.QuestionId)
                .HasMaxLength(36)
                .HasComment("问题的唯一标识")
                .HasColumnName("question_id");
            entity.Property(e => e.CreateTime)
                .HasComment("记录问题创建的时间")
                .HasColumnName("create_time");
            entity.Property(e => e.CreateUid)
                .HasMaxLength(255)
                .HasComment("创建者uid")
                .HasColumnName("create_uid");
            entity.Property(e => e.CreateUserName)
                .HasMaxLength(255)
                .HasComment("创建者名字")
                .HasColumnName("create_user_name");
            entity.Property(e => e.ForwardAnswer)
                .HasMaxLength(2000)
                .HasComment("问题的详细解答内容")
                .HasColumnName("forward_answer");
            entity.Property(e => e.Group)
                .HasMaxLength(255)
                .HasComment("用于对问题进行分组归类")
                .HasColumnName("group");
            entity.Property(e => e.IsValid)
                .HasComment("1:可用 0：禁用")
                .HasColumnName("is_valid");
            entity.Property(e => e.Order)
                .HasComment("用于表示问题的顺序")
                .HasColumnName("order");
            entity.Property(e => e.Question)
                .HasComment("问题")
                .HasColumnName("question");
            entity.Property(e => e.Score)
                .HasComment("满分")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("score");
            entity.Property(e => e.ScoringCriteriaPrompt)
                .HasComment("评分标准提示词")
                .HasColumnName("scoring_criteria_prompt");
            entity.Property(e => e.TestSetId)
                .HasMaxLength(36)
                .HasComment("关联t_test_set表的id，用于确定所属的测试集")
                .HasColumnName("test_set_id");
            entity.Property(e => e.UpdateTime).HasColumnName("update_time");
            entity.Property(e => e.UpdateUid)
                .HasMaxLength(255)
                .HasComment("更新uid")
                .HasColumnName("update_uid");
            entity.Property(e => e.UpdateUserName)
                .HasMaxLength(255)
                .HasComment("更新者名字")
                .HasColumnName("update_user_name");

            entity.HasOne(d => d.TestSet).WithMany(p => p.TTestSetQuestions)
                .HasForeignKey(d => d.TestSetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("t_test_set_question_ibfk_1");
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("t_user");

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.Account)
                .HasMaxLength(255)
                .HasComment("账号")
                .HasColumnName("account");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.CropUserId)
                .HasMaxLength(500)
                .HasComment("企业微信用户ID")
                .HasColumnName("crop_user_id");
            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(50)
                .HasComment("部门编码")
                .HasColumnName("department_code");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.InvitationCode)
                .HasMaxLength(50)
                .HasColumnName("invitation_code");
            entity.Property(e => e.InvitedBy).HasColumnName("invited_by");
            entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
            entity.Property(e => e.IsApiUser).HasColumnName("is_api_user");
            entity.Property(e => e.IsCreator).HasColumnName("is_creator");
            entity.Property(e => e.IsDisabled)
                .HasDefaultValueSql("('0')")
                .HasColumnName("is_disabled");
            entity.Property(e => e.IsLv1Reseller).HasColumnName("is_lv1_reseller");
            entity.Property(e => e.IsLv2Reseller).HasColumnName("is_lv2_reseller");
            entity.Property(e => e.LastLoginTime).HasColumnName("last_login_time");
            entity.Property(e => e.LastSyncTime)
                .HasComment("上次同步时间")
                .HasColumnName("last_sync_time");
            entity.Property(e => e.Logo)
                .HasMaxLength(255)
                .HasColumnName("logo");
            entity.Property(e => e.MyInvitationCode)
                .HasMaxLength(50)
                .HasColumnName("my_invitation_code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Organization)
                .HasMaxLength(100)
                .HasComment("组织/机构")
                .HasColumnName("organization");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.TimeFormat)
                .HasMaxLength(50)
                .HasColumnName("time_format");
            entity.Property(e => e.UserCode)
                .HasMaxLength(50)
                .HasColumnName("user_code");
        });

        modelBuilder.Entity<TUserApiAuth>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("t_user_api_auth");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("uid");
            entity.Property(e => e.AppCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("app_code");
            entity.Property(e => e.AppSecret)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("app_secret");
            entity.Property(e => e.ExpirationTime).HasColumnName("expiration_time");
        });

        modelBuilder.Entity<TUserApiSet>(entity =>
        {
            entity.ToTable("t_user_api_set");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.BachApiSetId)
                .HasMaxLength(36)
                .HasColumnName("bach_api_set_id");
            entity.Property(e => e.ControllerName)
                .HasMaxLength(500)
                .HasColumnName("controller_name");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.PathUrl)
                .HasMaxLength(500)
                .HasColumnName("path_url");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<TUserAuth>(entity =>
        {
            entity.ToTable("t_user_auth");

            entity.HasIndex(e => e.Uid, "uid");

            entity.Property(e => e.Id)
                .HasComment("标识")
                .HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasComment("新建时间")
                .HasColumnName("create_time");
            entity.Property(e => e.Credential)
                .HasMaxLength(255)
                .HasComment("密码凭证 (站内的保存密码 , 站外的不保存或保存 token)")
                .HasColumnName("credential");
            entity.Property(e => e.Identifier)
                .HasMaxLength(255)
                .HasComment("标识 (手机号/邮箱/用户名或第三方应用的唯一标识) \r\nbayer cwid")
                .HasColumnName("identifier");
            entity.Property(e => e.IdentityType)
                .HasMaxLength(255)
                .HasComment("登录类型：bayer microsoft auth;")
                .HasColumnName("identity_type");
            entity.Property(e => e.Uid)
                .HasComment("内部用户编号")
                .HasColumnName("uid");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新时间")
                .HasColumnName("update_time");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.TUserAuths)
                .HasForeignKey(d => d.Uid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("t_user_auth_ibfk_1");
        });

        modelBuilder.Entity<TUserLoginHistory>(entity =>
        {
            entity.HasKey(e => e.UserLoginHistoryId);

            entity.ToTable("t_user_login_history");

            entity.Property(e => e.UserLoginHistoryId).HasColumnName("user_login_history_id");
            entity.Property(e => e.LoginIp)
                .HasMaxLength(50)
                .HasColumnName("login_ip");
            entity.Property(e => e.LoginTime).HasColumnName("login_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Uid)
                .HasMaxLength(50)
                .HasColumnName("uid");
        });

        modelBuilder.Entity<TUserManageLable>(entity =>
        {
            entity.HasKey(e => e.UserManageLableId);

            entity.ToTable("t_user_manage_lable", tb => tb.HasComment("用户管理标签"));

            entity.Property(e => e.UserManageLableId).HasColumnName("user_manage_lable_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.LastUpdateTime).HasColumnName("last_update_time");
            entity.Property(e => e.SuperAgentCategoryId)
                .HasComment("管理标签id")
                .HasColumnName("super_agent_category_id");
            entity.Property(e => e.Uid)
                .HasComment("用户id")
                .HasColumnName("uid");
        });

        modelBuilder.Entity<TUserMcp>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("t_user_mcp");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("uid");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
            entity.Property(e => e.UserCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_code");
            entity.Property(e => e.UserKongAuthKey)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_kong_auth_key");
        });

        modelBuilder.Entity<TUserMembership>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("t_user_membership");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("uid");
            entity.Property(e => e.EffectiveDate)
                .HasColumnType("datetime")
                .HasColumnName("effective_date");
            entity.Property(e => e.ExpiredDate)
                .HasColumnType("datetime")
                .HasColumnName("expired_date");
            entity.Property(e => e.MembershipCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("membership_code");
            entity.Property(e => e.MembershipLevel).HasColumnName("membership_level");
            entity.Property(e => e.MembershipName)
                .HasMaxLength(50)
                .HasColumnName("membership_name");
            entity.Property(e => e.QuotaCompose).HasColumnName("quota_compose");
            entity.Property(e => e.QuotaWord).HasColumnName("quota_word");
            entity.Property(e => e.UsedCompose).HasColumnName("used_compose");
            entity.Property(e => e.UsedWord).HasColumnName("used_word");
        });

        modelBuilder.Entity<TUserOutline>(entity =>
        {
            entity.HasKey(e => e.UserOutlineId);

            entity.ToTable("t_user_outline");

            entity.Property(e => e.UserOutlineId).HasColumnName("user_outline_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn).HasColumnName("created_on");
            entity.Property(e => e.LastUpdateOn).HasColumnName("last_update_on");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.PurposeId).HasColumnName("purpose_id");
        });

        modelBuilder.Entity<TUserOutlineDetail>(entity =>
        {
            entity.HasKey(e => e.UserOutlineDetailId);

            entity.ToTable("t_user_outline_detail");

            entity.Property(e => e.UserOutlineDetailId).HasColumnName("user_outline_detail_id");
            entity.Property(e => e.Features).HasColumnName("features");
            entity.Property(e => e.NodeTemplateId).HasColumnName("node_template_id");
            entity.Property(e => e.OrderIndex).HasColumnName("order_index");
            entity.Property(e => e.UserOutlineId).HasColumnName("user_outline_id");
        });

        modelBuilder.Entity<TUserWorkSpace>(entity =>
        {
            entity.ToTable("t_user_work_space", tb => tb.HasComment("工作区"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasComment("创建人ID")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(50)
                .HasComment("创建人姓名")
                .HasColumnName("created_by_name");
            entity.Property(e => e.CreatedOn)
                .HasComment("创建时间")
                .HasColumnName("created_on");
            entity.Property(e => e.LastUpdateTime)
                .HasComment("最后更新时间")
                .HasColumnName("last_update_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment("工作区名称")
                .HasColumnName("name");
            entity.Property(e => e.Sort)
                .HasComment("工作区顺序")
                .HasColumnName("sort");
        });

        modelBuilder.Entity<TVrm>(entity =>
        {
            entity.ToTable("t_vrm");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.CoverPath)
                .HasMaxLength(500)
                .HasColumnName("cover_path");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.FilePath)
                .HasMaxLength(500)
                .HasColumnName("file_path");
            entity.Property(e => e.Md5)
                .HasMaxLength(255)
                .HasColumnName("md5");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Voice)
                .HasMaxLength(255)
                .HasColumnName("voice");
        });

        modelBuilder.Entity<TempChunk>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("temp_chunks");

            entity.Property(e => e.TextChunkId)
                .HasMaxLength(64)
                .HasColumnName("text_chunk_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
