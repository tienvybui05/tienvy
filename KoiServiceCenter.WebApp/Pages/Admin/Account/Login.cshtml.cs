using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace KoiServiceCenter.WebApp.Pages.Admin.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential credential { get; set; }
        private readonly IUserAccountService _service;

        public LoginModel(IUserAccountService service)
        {
            _service = service;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnpostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
             var userAccount = await _service.Account(credential.UserName, credential.Password);
            if(userAccount == null)
            {
				
				ModelState.AddModelError("credential.Password", "Tên người dùng hoặc mật khẩu không hợp lệ.");

				return Page();
			}
            if(userAccount!=null)
            {
                if (userAccount.Role == "Manager" || userAccount.Role == "Staff")
                {
                    List<Claim> claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, userAccount.UserName),
                new Claim(ClaimTypes.Email, userAccount.Email),
                new Claim(ClaimTypes.NameIdentifier, userAccount.UserId.ToString())
                };

                    // Thêm claims dựa vào loại người dùng
                    if (userAccount.Role == "Manager")
                    {
                        claims.Add(new Claim("Manager", "true"));
                    }
                    else if (userAccount.Role == "Staff")
                    {
                        claims.Add(new Claim("Staff", "true"));
                    }
                    // Khởi tạo ClaimsIdentity và đăng nhập với cookie
                    var identity = new ClaimsIdentity(claims, "AdminCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync("AdminCookieAuth", claimsPrincipal);

                    // Chuyển hướng đến trang Admin/Index sau khi đăng nhập
                    return RedirectToPage("/Admin/Index");
                }
            }    
		
            return Page();
        }
        public class Credential
        {
            [Required(ErrorMessage = "Vui lòng nhập tên người dùng.")]
            [Display(Name = "Tên người dùng")]
            public string UserName { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
            [StringLength(50, ErrorMessage = "{0} phải dài ít nhất là {2} và tối đa {1} ký tự.", MinimumLength = 6)]
            [Display(Name = "Mật khẩu")]
            [RegularExpression(@"^\S*$", ErrorMessage = "Mật khẩu không được chứa khoảng trắng.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
