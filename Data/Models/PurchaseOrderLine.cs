using System;
using System.Collections.Generic;

namespace SETEcho.Data.Models;

public partial class PurchaseOrderLine
{
    public long Id { get; set; }

    public long PurchaseOrderId { get; set; }

    public int LineNumber { get; set; }

    public long? ItemId { get; set; }

    public string ItemDescription { get; set; } = null!;

    public decimal QuantityOrdered { get; set; }

    public string UnitOfMeasure { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public long? GlAccountId { get; set; }

    public long? CostCenterId { get; set; }

    public long? ProjectId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public long CreatedByUserId { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long UpdatedByUserId { get; set; }

    public bool IsDeleted { get; set; }

    public string? LegacyLineIdentifier { get; set; }

    public string? SourceFileName { get; set; }

    public string? SourceSheetName { get; set; }

    public int? SourceRowNumber { get; set; }

    public long? MigrationBatchId { get; set; }

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
}
