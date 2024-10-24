using System;
using System.Collections.Generic;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class Cost
{
    public int CostId { get; set; }

    public int? ServiceId { get; set; }

    public decimal Cost1 { get; set; }

    public decimal? AdditionalFees { get; set; }

    public virtual Service? Service { get; set; }
}
