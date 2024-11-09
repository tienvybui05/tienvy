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
                ModelState.AddModelError("Input.UserName", "Tên tài khoản đã tồn tại. Vui lòng nhập tên khác khác.");
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
			[Required]
			[Display(Name = "Tên tài khoản")]
			public string UserName { get; set; }

			[Required]
			[EmailAddress]
			[Display(Name = "Email")]
			public string Email { get; set; }

			[Required]
			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			[DataType(DataType.Password)]
			[Display(Name = "Password")]
			public string Password { get; set; }

			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }
		}
	}
}
