using System;
using System.Collections.Generic;

namespace SETEcho.Data.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string PassWordHash { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string UserRole { get; set; } = null!;
}
