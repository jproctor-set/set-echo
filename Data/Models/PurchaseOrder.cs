using System;
using System.Collections.Generic;

namespace SETEcho.Data.Models;

public partial class PurchaseOrder
{
    public long Id { get; set; }

    public string PoNumber { get; set; } = null!;

    public long VendorId { get; set; }

    public long BuyerId { get; set; }

    public DateOnly PoDate { get; set; }

    public DateOnly? NeededByDate { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public long ShipToLocationId { get; set; }

    public long BillToLocationId { get; set; }

    public DateTime CreatedAt { get; set; }

    public long CreatedByUserId { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long UpdatedByUserId { get; set; }

    public DateTime? ClosedAt { get; set; }

    public long? ClosedByUserId { get; set; }

    public DateTime? CanceledAt { get; set; }

    public long? CanceledByUserId { get; set; }

    public bool IsDeleted { get; set; }

    public string? LegacyPoIdentifier { get; set; }

    public string? SourceFileName { get; set; }

    public string? SourceSheetName { get; set; }

    public int? SourceRowNumber { get; set; }

    public long? MigrationBatchId { get; set; }

    public virtual ICollection<PurchaseOrderApproval> PurchaseOrderApprovals { get; set; } = new List<PurchaseOrderApproval>();

    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();

    public virtual ICollection<PurchaseOrderStatusHistory> PurchaseOrderStatusHistories { get; set; } = new List<PurchaseOrderStatusHistory>();
}
