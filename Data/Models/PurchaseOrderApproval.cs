using System;
using System.Collections.Generic;

namespace SETEcho.Data.Models;

public partial class PurchaseOrderApproval
{
    public long Id { get; set; }

    public long PurchaseOrderId { get; set; }

    public int SequenceNumber { get; set; }

    public long ApproverUserId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? ActionedAt { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
}
