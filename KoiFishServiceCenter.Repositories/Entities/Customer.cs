using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class Customer
{
    [DisplayName("Mã khách hàng")]
    public int CustomerId { get; set; }

    [DisplayName("Họ và tên")]
    public string FullName { get; set; } = null!;

    [DisplayName("Số điện thoại")]
    public string? PhoneNumber { get; set; }

    [DisplayName("Địa chỉ")]
    public string? Address { get; set; }

    [DisplayName("Email")]
    public string? Email { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<ServiceHistory> ServiceHistories { get; set; } = new List<ServiceHistory>();

    [DisplayName("Tài khoản")]
    public virtual UserAccount? User { get; set; }

}
