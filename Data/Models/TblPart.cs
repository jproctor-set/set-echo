using System;
using System.Collections.Generic;

namespace SETEcho.Data.Models;

public partial class TblPart
{
    public int PartId { get; set; }

    public string PartNumber { get; set; } = null!;

    public string? PartDescription { get; set; }

    public int PartUnitId { get; set; }

    public int PartTypeId { get; set; }

    public int? CompanyId { get; set; }

    public int? SupplierId { get; set; }

    public string? Notes1 { get; set; }

    public string? Notes2 { get; set; }

    public string? Notes3 { get; set; }

    public string? Notes4 { get; set; }

    public string? Notes5 { get; set; }

    public string? Notes6 { get; set; }

    public string? Notes7 { get; set; }

    public string? Notes8 { get; set; }

    public string? Notes9 { get; set; }

    public string? Notes10 { get; set; }

    public virtual ICollection<TblBom> TblBomChildParts { get; set; } = new List<TblBom>();

    public virtual ICollection<TblBom> TblBomParentParts { get; set; } = new List<TblBom>();
}
