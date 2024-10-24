using System;
using System.Collections.Generic;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class Report
{
    public int ReportId { get; set; }

    public DateTime ReportDate { get; set; }

    public int? TotalCustomers { get; set; }

    public int? TotalServices { get; set; }

    public decimal? AverageRating { get; set; }

    public string? Notes { get; set; }
}
