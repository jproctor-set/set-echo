using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using SETEcho.Data.Models;

namespace SETEcho.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrder1> PurchaseOrders1 { get; set; }

    public virtual DbSet<PurchaseOrderApproval> PurchaseOrderApprovals { get; set; }

    public virtual DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }

    public virtual DbSet<PurchaseOrderStatusHistory> PurchaseOrderStatusHistories { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TblBom> TblBoms { get; set; }

    public virtual DbSet<TblPart> TblParts { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["SETEchoDB"].ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tbl_POs");

            entity.ToTable("PurchaseOrder");

            entity.HasIndex(e => e.MigrationBatchId, "IX_PurchaseOrder_migration_batch");

            entity.HasIndex(e => e.Status, "IX_PurchaseOrder_status");

            entity.HasIndex(e => new { e.VendorId, e.PoDate }, "IX_PurchaseOrder_supplier_date").IsDescending(false, true);

            entity.HasIndex(e => e.PoNumber, "UX_PurchaseOrder_po_number").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BillToLocationId).HasColumnName("bill_to_location_id");
            entity.Property(e => e.BuyerId).HasColumnName("buyer_id");
            entity.Property(e => e.CanceledAt)
                .HasPrecision(3)
                .HasColumnName("canceled_at");
            entity.Property(e => e.CanceledByUserId).HasColumnName("canceled_by_user_id");
            entity.Property(e => e.ClosedAt)
                .HasPrecision(3)
                .HasColumnName("closed_at");
            entity.Property(e => e.ClosedByUserId).HasColumnName("closed_by_user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LegacyPoIdentifier)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("legacy_po_identifier");
            entity.Property(e => e.MigrationBatchId).HasColumnName("migration_batch_id");
            entity.Property(e => e.NeededByDate).HasColumnName("needed_by_date");
            entity.Property(e => e.PoDate).HasColumnName("po_date");
            entity.Property(e => e.PoNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("po_number");
            entity.Property(e => e.ShipToLocationId).HasColumnName("ship_to_location_id");
            entity.Property(e => e.SourceFileName)
                .HasMaxLength(260)
                .IsUnicode(false)
                .HasColumnName("source_file_name");
            entity.Property(e => e.SourceRowNumber).HasColumnName("source_row_number");
            entity.Property(e => e.SourceSheetName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("source_sheet_name");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");
            entity.Property(e => e.VendorId).HasColumnName("vendor_id");
        });

        modelBuilder.Entity<PurchaseOrder1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PurchaseOrders$PrimaryKey");

            entity.ToTable("PurchaseOrders");

            entity.HasIndex(e => e.ShippingTerms, "PurchaseOrders$CustomerID");

            entity.HasIndex(e => e.Id, "PurchaseOrders$Id");

            entity.HasIndex(e => e.ShippingMethod, "PurchaseOrders$ShipToId");

            entity.HasIndex(e => e.CustomerId, "PurchaseOrders$VendorID");

            entity.HasIndex(e => e.DeliveryDate, "PurchaseOrders$VendorQuoteId");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(255)
                .HasColumnName("Customer_ID");
            entity.Property(e => e.Date).HasMaxLength(255);
            entity.Property(e => e.DeliveryDate)
                .HasMaxLength(255)
                .HasColumnName("Delivery_Date");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Job).HasMaxLength(255);
            entity.Property(e => e.LineTotal)
                .HasMaxLength(255)
                .HasColumnName("Line_Total");
            entity.Property(e => e.PoNumber)
                .HasMaxLength(255)
                .HasColumnName("PO_Number");
            entity.Property(e => e.Qty).HasMaxLength(255);
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(255)
                .HasColumnName("Shipping_Method");
            entity.Property(e => e.ShippingTerms)
                .HasMaxLength(255)
                .HasColumnName("Shipping_Terms");
            entity.Property(e => e.Unit).HasMaxLength(255);
            entity.Property(e => e.UnitPrice)
                .HasMaxLength(255)
                .HasColumnName("Unit_Price");
            entity.Property(e => e.VendorQuote)
                .HasMaxLength(255)
                .HasColumnName("Vendor_Quote");
        });

        modelBuilder.Entity<PurchaseOrderApproval>(entity =>
        {
            entity.ToTable("PurchaseOrderApproval");

            entity.HasIndex(e => new { e.PurchaseOrderId, e.SequenceNumber }, "IX_POApproval_PO_Seq");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionedAt)
                .HasPrecision(3)
                .HasColumnName("actioned_at");
            entity.Property(e => e.ApproverUserId).HasColumnName("approver_user_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(2000)
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.PurchaseOrderId).HasColumnName("purchase_order_id");
            entity.Property(e => e.SequenceNumber).HasColumnName("sequence_number");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.PurchaseOrderApprovals)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseOrderApproval_PurchaseOrder");
        });

        modelBuilder.Entity<PurchaseOrderLine>(entity =>
        {
            entity.ToTable("PurchaseOrderLine");

            entity.HasIndex(e => new { e.GlAccountId, e.CostCenterId }, "IX_POLine_GL");

            entity.HasIndex(e => e.PurchaseOrderId, "IX_POLine_PO");

            entity.HasIndex(e => e.ProjectId, "IX_POLine_Project");

            entity.HasIndex(e => new { e.PurchaseOrderId, e.LineNumber }, "UQ_POLine_Per_PO").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CostCenterId).HasColumnName("cost_center_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");
            entity.Property(e => e.GlAccountId).HasColumnName("gl_account_id");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ItemDescription)
                .HasMaxLength(4000)
                .HasColumnName("item_description");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.LegacyLineIdentifier)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("legacy_line_identifier");
            entity.Property(e => e.LineNumber).HasColumnName("line_number");
            entity.Property(e => e.MigrationBatchId).HasColumnName("migration_batch_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.PurchaseOrderId).HasColumnName("purchase_order_id");
            entity.Property(e => e.QuantityOrdered)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("quantity_ordered");
            entity.Property(e => e.SourceFileName)
                .HasMaxLength(260)
                .IsUnicode(false)
                .HasColumnName("source_file_name");
            entity.Property(e => e.SourceRowNumber).HasColumnName("source_row_number");
            entity.Property(e => e.SourceSheetName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("source_sheet_name");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UnitOfMeasure)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("unit_of_measure");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("unit_price");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_POLine_PO");
        });

        modelBuilder.Entity<PurchaseOrderStatusHistory>(entity =>
        {
            entity.ToTable("PurchaseOrderStatusHistory");

            entity.HasIndex(e => new { e.PurchaseOrderId, e.ChangedAt }, "IX_POStatusHistory_PO").IsDescending(false, true);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChangedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("changed_at");
            entity.Property(e => e.ChangedByUserId).HasColumnName("changed_by_user_id");
            entity.Property(e => e.NewStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("new_status");
            entity.Property(e => e.OldStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("old_status");
            entity.Property(e => e.PurchaseOrderId).HasColumnName("purchase_order_id");
            entity.Property(e => e.Reason)
                .HasMaxLength(2000)
                .HasColumnName("reason");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.PurchaseOrderStatusHistories)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseOrderStatusHistory_PurchaseOrder");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.HasIndex(e => e.SupplierName, "IX_Supplier_Name");

            entity.HasIndex(e => e.SupplierCode, "UX_Supplier_Code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressLine1)
                .HasMaxLength(255)
                .HasColumnName("address_line1");
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(255)
                .HasColumnName("address_line2");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("country_code");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");
            entity.Property(e => e.DefaultCurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("default_currency_code");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PaymentTermsId).HasColumnName("payment_terms_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .HasColumnName("postal_code");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(100)
                .HasColumnName("state_province");
            entity.Property(e => e.SupplierCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("supplier_code");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(255)
                .HasColumnName("supplier_name");
            entity.Property(e => e.TaxLicenseNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_license_number");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("website");
        });

        modelBuilder.Entity<TblBom>(entity =>
        {
            entity.HasKey(e => e.BomId);

            entity.ToTable("tbl_BOM");

            entity.Property(e => e.BomId).HasColumnName("bomID");
            entity.Property(e => e.ChildPartId).HasColumnName("childPartID");
            entity.Property(e => e.ParentPartId).HasColumnName("parentPartID");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.ChildPart).WithMany(p => p.TblBomChildParts)
                .HasForeignKey(d => d.ChildPartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_BOM_tbl_Parts");

            entity.HasOne(d => d.ParentPart).WithMany(p => p.TblBomParentParts)
                .HasForeignKey(d => d.ParentPartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_BOM_tbl_Parts1");
        });

        modelBuilder.Entity<TblPart>(entity =>
        {
            entity.HasKey(e => e.PartId);

            entity.ToTable("tbl_Parts");

            entity.Property(e => e.PartId).HasColumnName("partID");
            entity.Property(e => e.CompanyId).HasColumnName("companyID");
            entity.Property(e => e.Notes1)
                .HasMaxLength(50)
                .HasColumnName("notes1");
            entity.Property(e => e.Notes10)
                .HasMaxLength(50)
                .HasColumnName("notes10");
            entity.Property(e => e.Notes2)
                .HasMaxLength(50)
                .HasColumnName("notes2");
            entity.Property(e => e.Notes3)
                .HasMaxLength(50)
                .HasColumnName("notes3");
            entity.Property(e => e.Notes4)
                .HasMaxLength(50)
                .HasColumnName("notes4");
            entity.Property(e => e.Notes5)
                .HasMaxLength(50)
                .HasColumnName("notes5");
            entity.Property(e => e.Notes6)
                .HasMaxLength(50)
                .HasColumnName("notes6");
            entity.Property(e => e.Notes7)
                .HasMaxLength(50)
                .HasColumnName("notes7");
            entity.Property(e => e.Notes8)
                .HasMaxLength(50)
                .HasColumnName("notes8");
            entity.Property(e => e.Notes9)
                .HasMaxLength(50)
                .HasColumnName("notes9");
            entity.Property(e => e.PartDescription)
                .HasMaxLength(255)
                .HasColumnName("partDescription");
            entity.Property(e => e.PartNumber)
                .HasMaxLength(100)
                .HasColumnName("partNumber");
            entity.Property(e => e.PartTypeId).HasColumnName("partTypeID");
            entity.Property(e => e.PartUnitId).HasColumnName("partUnitID");
            entity.Property(e => e.SupplierId).HasColumnName("supplierID");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("tbl_Users");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("lastName");
            entity.Property(e => e.PassWordHash)
                .HasMaxLength(256)
                .HasColumnName("passWordHash");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .HasColumnName("userRole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
