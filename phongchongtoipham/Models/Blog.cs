using System;
using System.Collections.Generic;

namespace phongchongtoipham.Models;

public partial class Blog
{
    public string Title { get; set; } = null!;

    public string? Content1 { get; set; }

    public string? Content2 { get; set; }

    public string? Content3 { get; set; }

    public string? Image { get; set; }
}
