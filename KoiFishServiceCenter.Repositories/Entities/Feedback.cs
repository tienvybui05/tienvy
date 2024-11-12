using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class Feedback
{
    [DisplayName("Mã đánh giá")]
    public int FeedbackId { get; set; }

    public int? CustomerId { get; set; }

    public int? ServiceId { get; set; }
    [DisplayName("Sao")]
    public int? Rating { get; set; }
    [DisplayName("Đánh giá")]
    public string? Comments { get; set; }
    [DisplayName("Khách hàng")]
    public virtual Customer? Customer { get; set; }
    [DisplayName("Dịch vụ")]
    public virtual Service? Service { get; set; }
}
