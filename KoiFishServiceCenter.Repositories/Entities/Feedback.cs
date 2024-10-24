using System;
using System.Collections.Generic;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? CustomerId { get; set; }

    public int? ServiceId { get; set; }

    public int? Rating { get; set; }

    public string? Comments { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Service? Service { get; set; }
}
