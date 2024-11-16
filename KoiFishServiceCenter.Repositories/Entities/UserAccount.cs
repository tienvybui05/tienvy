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
    [Required(ErrorMessage = "Vui lòng nhập tên người dùng.")]
    [Display(Name = "Tên người dùng")]
    [RegularExpression(@"^\S*$", ErrorMessage = "Mật khẩu không được chứa khoảng trắng.")]
    [StringLength(50, ErrorMessage = "Tên người dùng không được vượt quá 50 ký tự.")]
    public string UserName { get; set; } = null!;
    [DisplayName("Mật khẩu")]
    [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
    [StringLength(50, ErrorMessage = "{0} phải dài ít nhất là {2} và tối đa {1} ký tự.", MinimumLength = 6)]
    [RegularExpression(@"^\S*$", ErrorMessage = "Mật khẩu không được chứa khoảng trắng.")]
    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;
    [DisplayName("Vai trò")]
    [Required(ErrorMessage = "Vui lòng xác nhận lại chức năng.")]
    public string Role { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<ServiceHistory> ServiceHistories { get; set; } = new List<ServiceHistory>();

    public virtual ICollection<VetSchedule> VetSchedules { get; set; } = new List<VetSchedule>();
}
