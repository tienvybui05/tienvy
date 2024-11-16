using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using KoiFishServiceCenter.Repositories.Entities;
namespace KoiServiceCenter.WebApp.Pages.Account
{
    public class RegisterModel : PageModel
    {
		private readonly IUserAccountService _service;
		public RegisterModel(IUserAccountService service)
		{
			_service = service;
		}


		public void OnGet()
        {
        }

		[BindProperty]
		public InputModel Input { get; set; }
		// For more information, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
            if (await _service.CreateAccount(Input.UserName, Input.Password, Input.Email) == false)
            {
                ModelState.AddModelError("Input.UserName", "Tên người dùng đã tồn tại. Vui lòng nhập tên khác khác.");
                if (await _service.checkEmail(Input.Email) == false)
                {
                    ModelState.AddModelError("Input.Email", "Email đã tồn tại. Vui lòng nhập Email khác.");

                }
                return Page();
            }

            return RedirectToPage("/Index");
		}
		public class InputModel
		{
            [Required(ErrorMessage = "Vui lòng nhập tên người dùng.")]
            [Display(Name = "Tên người dùng")]
            [RegularExpression(@"^\S*$", ErrorMessage = "Mật khẩu không được chứa khoảng trắng.")]
            [StringLength(50, ErrorMessage = "Tên người dùng không được vượt quá 50 ký tự.")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập email.")]
            [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
            [StringLength(50, ErrorMessage = "{0} phải dài ít nhất là {2} và tối đa {1} ký tự.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu")]
            [RegularExpression(@"^\S*$", ErrorMessage = "Mật khẩu không được chứa khoảng trắng.")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Vui lòng xác nhận lại mật khẩu.")]
            [DataType(DataType.Password)]
            [Display(Name = "Xác nhận mật khẩu")]
            [Compare("Password", ErrorMessage = "Mật khẩu và mật khẩu xác nhận không khớp.")]
            public string ConfirmPassword { get; set; }
        }
	}
}
