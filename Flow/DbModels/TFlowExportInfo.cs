using System;
using System.Collections.Generic;

namespace Flow.DbModels;

public partial class TFlowExportInfo
{
    public string Id { get; set; } = null!;

    public int? FlowId { get; set; }

    /// <summary>
    /// 唯一编号,为了导出，其他是否都用flowid
    /// </summary>
    public string Uuid { get; set; } = null!;

    public string ProcessContent { get; set; } = null!;

    /// <summary>
    /// 状态：1：正在处理，2：成功，9：失败
    /// </summary>
    public int Status { get; set; }

    public DateTime CreateTime { get; set; }

    /// <summary>
    /// blob的地址
    /// </summary>
    public string BlobUrl { get; set; } = null!;

    /// <summary>
    /// 1：导出，2：导入
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// 操作人
    /// </summary>
    public int Uid { get; set; }

    /// <summary>
    /// 导出 0：一个  1：多个
    /// 导入 0：全新   1：覆盖
    /// </summary>
    public bool Strategy { get; set; }
}
