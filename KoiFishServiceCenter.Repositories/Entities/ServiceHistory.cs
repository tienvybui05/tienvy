using System;
using System.Collections.Generic;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class ServiceHistory
{
    public int HistoryId { get; set; }

    public int? CustomerId { get; set; }

    public int? ServiceId { get; set; }

    public int? VeterinarianId { get; set; }

    public DateTime ServiceDate { get; set; }

    public string? Result { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Service? Service { get; set; }

    public virtual UserAccount? Veterinarian { get; set; }
}
