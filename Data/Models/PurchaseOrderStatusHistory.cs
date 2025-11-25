using System;
using System.Collections.Generic;

namespace SETEcho.Data.Models;

public partial class PurchaseOrderStatusHistory
{
    public long Id { get; set; }

    public long PurchaseOrderId { get; set; }

    public string? OldStatus { get; set; }

    public string NewStatus { get; set; } = null!;

    public DateTime ChangedAt { get; set; }

    public long ChangedByUserId { get; set; }

    public string? Reason { get; set; }

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
}
