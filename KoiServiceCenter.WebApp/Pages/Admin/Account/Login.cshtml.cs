﻿using KoiFishServiceCenter.Repositories.Entities;
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
        public UserAccount userAccount;
        //public string chucNang;
        //Veterinarian,Manager
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
            userAccount = await _service.Account(credential.UserName, credential.Password);
			if (userAccount.Role == "Manager"|| userAccount.Role == "Staff")
            {
                List<Claim> claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, userAccount.UserName),
                new Claim(ClaimTypes.Email, userAccount.Email)
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
                else if (userAccount.Role =="Veterian")
                {
                    claims.Add(new Claim("Veterian", "true"));
                }
                // Khởi tạo ClaimsIdentity và đăng nhập với cookie
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                // Chuyển hướng đến trang Admin/Index sau khi đăng nhập
                return RedirectToPage("/Admin/Index");
            }
            return Page();
        }
        public class Credential
        {
            [Required]
            [Display(Name = "Tài khoản")]
            public string UserName { get; set; }
            [Required]
            [Display(Name = "Mật khẩu")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}