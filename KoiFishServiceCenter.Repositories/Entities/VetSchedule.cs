using System;
using System.Collections.Generic;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class VetSchedule
{
    public int ScheduleId { get; set; }

    public int? VeterinarianId { get; set; }

    public DateTime ScheduleDate { get; set; }

    public string? TimeSlot { get; set; }

    public virtual UserAccount? Veterinarian { get; set; }
}
