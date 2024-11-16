using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace KoiServiceCenter.WebApp.Pages.Account
{
    public class LoginModel : PageModel
    {

        private readonly IUserAccountService _service;

        public LoginModel(IUserAccountService service)
        {
            _service = service;
        }
        public void OnGet()
        {
        }
        [BindProperty]
        public Credential credential { get; set; }
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
            if (userAccount != null)
            {
                List<Claim> claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, userAccount.UserName),
                new Claim(ClaimTypes.Email, userAccount.Email),
                new Claim(ClaimTypes.NameIdentifier, userAccount.UserId.ToString()),
                
                };
                if(userAccount.Role == "Veterinarian")
                {
                    claims.Add(new Claim("Veterinarian", "true"));
                }
                else
                {
                    claims.Add(new Claim("Everyone", "true"));
                }
                var identity = new ClaimsIdentity(claims, "CustomerCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("CustomerCookieAuth", claimsPrincipal);
                return RedirectToPage("/Index");
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
