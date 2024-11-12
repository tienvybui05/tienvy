using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace KoiServiceCenter.WebApp.Pages.Account
{
    [Authorize(Policy = "EveryoneOnly")]
    public class ChangePasswordModel : PageModel
    {
        private readonly IUserAccountService _service;

        public ChangePasswordModel(IUserAccountService service)
        {
            _service = service;
        }

        [BindProperty]
        public UserAccount UserAccount { get; set; }
        [BindProperty]
        public ChangePassword changePassword { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
           
            var AccountId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userIdInt = int.Parse(AccountId);
            ViewData["Role"] = _service.GetRoleSelect();
            if (await _service.ChangePasswordAsync(changePassword.OldPassword, changePassword.NewPassword, userIdInt) == false)
            {
                
                ModelState.AddModelError("changePassword.OldPassword", "Mật khẩu không hợp lệ.");
                return Page();
            }
            return RedirectToPage("/Index");
        }
        public class ChangePassword
        {
            [Required]
            [Display(Name = "Mật khẩu củ")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "{0} phải dài ít nhất là {2} và tối đa {1} ký tự.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu mới")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Xác nhận mật khẩu")]
            [Compare("NewPassword", ErrorMessage = "Mật khẩu và mật khẩu xác nhận không khớp.")]
            public string ConfirmPassword { get; set; }
        }
    }
}
