using System;
using System.Collections.Generic;

namespace SETEcho.Data.Models;

public partial class TblBom
{
    public int BomId { get; set; }

    public int ParentPartId { get; set; }

    public int ChildPartId { get; set; }

    public decimal Quantity { get; set; }

    public virtual TblPart ChildPart { get; set; } = null!;

    public virtual TblPart ParentPart { get; set; } = null!;
}
