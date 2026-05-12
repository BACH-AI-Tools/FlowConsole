using System;
using System.Collections.Generic;

namespace Flow.DbModels;

/// <summary>
/// 插件后台配置
/// 最终要组成一个json，传递给openai
/// &quot;aiPlugin&quot;: {
///     &quot;schemaVersion&quot;: &quot;v1&quot;,
///     &quot;nameForModel&quot;: &quot;MathPlugin&quot;,
///     &quot;nameForHuman&quot;: &quot;Math Plugin&quot;,
///     &quot;descriptionForModel&quot;: &quot;Used to perform math operations (i.e., add, subtract, multiple, divide).&quot;,
///     &quot;descriptionForHuman&quot;: &quot;Used to perform math operations.&quot;,
///     &quot;auth&quot;: {
///         &quot;type&quot;: &quot;none&quot;
///     },
///     &quot;api&quot;: {
///         &quot;type&quot;: &quot;openapi&quot;,
///         &quot;url&quot;: &quot;{url}/swagger.json&quot;
///     },
///     &quot;logoUrl&quot;: &quot;{url}/logo.png&quot;,
///     &quot;contactEmail&quot;: &quot;support@example.com&quot;,
///     &quot;legalInfoUrl&quot;: &quot;http://www.example.com/legal&quot;
/// }
/// </summary>
public partial class TPlugin
{
    public int Id { get; set; }

    public string? Uuid { get; set; }

    /// <summary>
    /// 模型将用于定位插件的名称（不允许空格，只能使用字母和数字）。最多 50 个字符
    /// </summary>
    public string NameForModel { get; set; } = null!;

    /// <summary>
    /// 更好地为模型量身定制的描述，例如令牌上下文长度注意事项或关键字用法，以改进插件提示。最多 8,000 个字符
    /// </summary>
    public string? DescriptionForModel { get; set; }

    /// <summary>
    /// api的json地址
    /// </summary>
    public string ApiUrl { get; set; } = null!;

    /// <summary>
    /// 插件的logo地址
    /// </summary>
    public string? LogoUrl { get; set; }

    /// <summary>
    /// 启用，禁用
    /// </summary>
    public bool? IsValid { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 解析时排除那些接口。以 , 分割;
    /// </summary>
    public string? OperationsToExclude { get; set; }

    /// <summary>
    /// 暂存header和value来鉴权 e.g [ Authorization:Bearer ******I ]
    /// </summary>
    public string? Auth { get; set; }

    /// <summary>
    /// 是否包含知识库节点
    /// </summary>
    public bool IsContainKnowleage { get; set; }

    /// <summary>
    /// 1：AI
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// 看类：E_Plug_Plugin_Type
    /// </summary>
    public int PluginType { get; set; }

    /// <summary>
    /// 创建人id
    /// </summary>
    public int CreatedBy { get; set; }

    /// <summary>
    /// 类别id
    /// </summary>
    public int? SuperAgentCategoryId { get; set; }

    /// <summary>
    /// 是否删除
    /// </summary>
    public bool IsDelete { get; set; }

    /// <summary>
    /// ai小程序的插件显示外面的类型：0=不显示在外面，1=知识库与数据，2=通知
    /// </summary>
    public int DisplayType { get; set; }

    /// <summary>
    /// 1:内部编写的plugin 2:logic app
    /// </summary>
    public int FromSouce { get; set; }

    /// <summary>
    /// 命令空间，sk会与方法名拼在一起
    /// </summary>
    public string? NameSpace { get; set; }
}
