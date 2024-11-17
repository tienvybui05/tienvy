using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class Customer
{
    [DisplayName("Mã khách hàng")]
    public int CustomerId { get; set; }

    [DisplayName("Họ và tên")]
    [MaxLength(20, ErrorMessage = "Họ và tên không được vượt quá 100 ký tự.")]
    public string FullName { get; set; } = null!;

    [DisplayName("Số điện thoại")]
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
    [RegularExpression(@"^[0-9]{1,11}$", ErrorMessage = "Số điện thoại chỉ được chứa các chữ số và không vượt quá 11 ký tự.")]
    public string? PhoneNumber { get; set; }

    [DisplayName("Địa chỉ")]
    public string? Address { get; set; }

    [DisplayName("Email")]
    public string? Email { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<ServiceHistory> ServiceHistories { get; set; } = new List<ServiceHistory>();

    [DisplayName("Tên người dùng")]
    public virtual UserAccount? User { get; set; }

}
