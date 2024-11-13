using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KoiFishServiceCenter.Repositories.Entities;

public partial class UserAccount
{
    [Required(ErrorMessage = "{0} Vui lòng nhập")]
    [DisplayName("Mã tài khoản")]
    public int UserId { get; set; }
    [DisplayName("Tài khoản")]
    public string UserName { get; set; } = null!;
    [DisplayName("Mật khẩu")]
    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;
    [DisplayName("Vai trò")]
    public string Role { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<ServiceHistory> ServiceHistories { get; set; } = new List<ServiceHistory>();

    public virtual ICollection<VetSchedule> VetSchedules { get; set; } = new List<VetSchedule>();
}
