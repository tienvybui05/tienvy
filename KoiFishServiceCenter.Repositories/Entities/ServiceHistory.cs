using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class ServiceHistory
{
    [Required(ErrorMessage = "{0} Vui lòng nhập")]
    [DisplayName("Mã lịch làm")]
    public int HistoryId { get; set; }

    public int? CustomerId { get; set; }

    public int? ServiceId { get; set; }

    public int? VeterinarianId { get; set; }
    [Required(ErrorMessage = "{0} Vui lòng nhập")]
    [DisplayName("Ngày hẹn")]
    public DateTime ServiceDate { get; set; }
    [DisplayName("Ghi chú")]
    public string? Result { get; set; }
    [DisplayName("Khách hàng")]
    public virtual Customer? Customer { get; set; }
    [DisplayName("Dịch vụ")]
    public virtual Service? Service { get; set; }
    [DisplayName("Bác sĩ")]
    public virtual UserAccount? Veterinarian { get; set; }
}
