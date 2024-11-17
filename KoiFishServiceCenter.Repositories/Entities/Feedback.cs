using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class Feedback
{
    [DisplayName("Mã đánh giá")]
    public int FeedbackId { get; set; }

    public int? CustomerId { get; set; }

    public int? ServiceId { get; set; }
    [Range(0, 5, ErrorMessage = "Vui lòng nhập giá trị nhỏ hơn hoặc bằng 5.")]
    [DisplayName("Sao")]
    [Required(ErrorMessage = "{0} Vui lòng nhập")]
    public int? Rating { get; set; }
    [DisplayName("Đánh giá")]
    [Required(ErrorMessage = "{0} Vui lòng nhập")]
    public string? Comments { get; set; }
    [DisplayName("Khách hàng")]
    public virtual Customer? Customer { get; set; }
    [DisplayName("Dịch vụ")]
    public virtual Service? Service { get; set; }
}
