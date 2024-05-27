using System;
using System.Collections.Generic;

namespace phongchongtoipham.Models;

public partial class Report
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public DateOnly? Date { get; set; }

    public string? Location { get; set; }

    public string? Detail { get; set; }

    public string? Image { get; set; }
}
