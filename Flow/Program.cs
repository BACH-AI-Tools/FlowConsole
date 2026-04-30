// 直接在这里配置要处理的文件，不需要在命令行里传参数。
//原始sqlite文件路径
const string InputPath = @"F:\ConsoleTest\FlowConsole\sqlitedb\插件测试.db";
//映射文件路径
const string MappingPath = @"F:\ConsoleTest\FlowConsole\mappingexcel\1.xlsx";
//输出文件夹路径
const string OutputPath = @"F:\ConsoleTest\FlowConsole\sqlitedb";

try
{
    var options = new RepairOptions(
        InputPath,
        MappingPath,
        OutputPath);

    var repairer = new ModelMappingRepairer();
    var result = await repairer.RepairAsync(options);

    Console.WriteLine("修复完成");
    Console.WriteLine($"flow_count: {result.FlowCount}");
    Console.WriteLine($"changed_flow_count: {result.ChangedFlowCount}");
    Console.WriteLine($"replacement_count: {result.Replacements.Count}");
    Console.WriteLine($"unmapped_model_count: {result.UnmappedModels.Count}");
    Console.WriteLine($"knowledge_base_replacement_count: {result.KnowledgeBaseReplacements.Count}");
    Console.WriteLine($"unmapped_knowledge_base_count: {result.UnmappedKnowledgeBases.Count}");
    Console.WriteLine($"output: {result.OutputPath}");

    if (result.Replacements.Count > 0)
    {
        Console.WriteLine();
        Console.WriteLine("模型替换明细:");
        foreach (var item in result.Replacements)
        {
            Console.WriteLine($"- flow={item.FlowName}({item.FlowId}), node={item.NodeName}({item.NodeId})");
            Console.WriteLine(
                $"  {item.OldModelName}/{item.OldSettingName}/{item.OldSettingLabel} -> " +
                $"{item.NewModelName}/{item.NewSettingName}/{item.NewSettingLabel}");

            Console.WriteLine();
        }
    }

    if (result.UnmappedModels.Count > 0)
    {
        Console.WriteLine();
        Console.WriteLine("未命中映射的模型组合:");
        foreach (var item in result.UnmappedModels)
        {
            Console.WriteLine($"- flow={item.FlowName}({item.FlowId}), node={item.NodeName}({item.NodeId})");
            Console.WriteLine($"  {item.ModelName}/{item.SettingName}");

            Console.WriteLine();
        }
    }

    if (result.KnowledgeBaseReplacements.Count > 0)
    {
        Console.WriteLine();
        Console.WriteLine("知识库替换明细:");
        foreach (var item in result.KnowledgeBaseReplacements)
        {
            Console.WriteLine($"- flow={item.FlowName}({item.FlowId}), node={item.NodeName}({item.NodeId})");
            Console.WriteLine($"  {item.KnowledgeBaseName} -> {item.LibraryId}");

            Console.WriteLine();
        }
    }

    if (result.UnmappedKnowledgeBases.Count > 0)
    {
        Console.WriteLine();
        Console.WriteLine("未命中映射的知识库:");
        foreach (var item in result.UnmappedKnowledgeBases)
        {
            Console.WriteLine($"- flow={item.FlowName}({item.FlowId}), node={item.NodeName}({item.NodeId})");
            Console.WriteLine($"  {item.KnowledgeBaseName}");

            Console.WriteLine();
        }
    }

    return result.UnmappedModels.Count == 0 && result.UnmappedKnowledgeBases.Count == 0 ? 0 : 2;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"错误: {ex.Message}");
    Console.Error.WriteLine("请检查 Program.cs 顶部的 InputPath、MappingPath、OutputPath 配置。");
    return 1;
}
