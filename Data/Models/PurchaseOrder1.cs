using System;
using System.Collections.Generic;

namespace SETEcho.Data.Models;

public partial class PurchaseOrder1
{
    public int Id { get; set; }

    public string PoNumber { get; set; } = null!;

    public string Date { get; set; } = null!;

    public string? CustomerId { get; set; }

    public string? VendorQuote { get; set; }

    public string? ShippingMethod { get; set; }

    public string? ShippingTerms { get; set; }

    public string? DeliveryDate { get; set; }

    public string? Qty { get; set; }

    public string? Unit { get; set; }

    public string? Description { get; set; }

    public string? Job { get; set; }

    public string? UnitPrice { get; set; }

    public string? LineTotal { get; set; }
}
