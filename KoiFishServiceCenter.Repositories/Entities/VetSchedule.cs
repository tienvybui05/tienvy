using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class VetSchedule
{
    [Required(ErrorMessage = "{0} Vui lòng nhập")]
    [DisplayName("Mã lịch làm")]
    public int ScheduleId { get; set; }

    public int? VeterinarianId { get; set; }
    [DisplayName("Ngày làm")]
    public DateTime ScheduleDate { get; set; }
    [DisplayName("Ca làm")]
    public string? TimeSlot { get; set; }
    [DisplayName("Bác sĩ")]
    public virtual UserAccount? Veterinarian { get; set; }
}
