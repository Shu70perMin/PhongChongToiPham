using System;
using System.Collections.Generic;

namespace phongchongtoipham.Models;

public partial class User
{
    public string UserName { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public int? Role { get; set; }
}
