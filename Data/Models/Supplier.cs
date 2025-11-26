using System;
using System.Collections.Generic;

namespace SETEcho.Data.Models;

public partial class Supplier
{
    public long Id { get; set; }

    public string SupplierCode { get; set; } = null!;

    public string SupplierName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public string? StateProvince { get; set; }

    public string? PostalCode { get; set; }

    public string? CountryCode { get; set; }

    public string? TaxLicenseNumber { get; set; }

    public string? DefaultCurrencyCode { get; set; }

    public long? PaymentTermsId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public long CreatedByUserId { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long UpdatedByUserId { get; set; }

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}
