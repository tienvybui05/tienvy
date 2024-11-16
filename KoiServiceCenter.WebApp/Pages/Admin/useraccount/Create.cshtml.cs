using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace KoiServiceCenter.WebApp.Pages.Admin.useraccount
{
	[Authorize(Policy = "ManagerOnly")]
	public class CreateModel : PageModel
    {
        private readonly IUserAccountService _service;

        public CreateModel(IUserAccountService service)
        {
            _service = service;
        }


        public async Task<IActionResult> OnGet()
        {
            int ranDumID;
            ranDumID = await _service.CreateId();

            UserAccount = new UserAccount
            {
                UserId = ranDumID
            };
            ViewData["Role"] = _service.GetRoleSelect();
            return Page();
        }

        [BindProperty]
        public UserAccount UserAccount { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ViewData["Role"] = _service.GetRoleSelect();
            if (await _service.checkEmail(UserAccount.Email) == false)
            {
                ModelState.AddModelError("UserAccount.Email", "Email đã tồn tại. Vui lòng chọn ngày khác.");
                return Page();
            }
            if (await _service.AddUserAccountAsync(UserAccount) == false)
            {
                ModelState.AddModelError("UserAccount.UserName", "Tên người dùng đã tồn tại. Vui lòng chọn ngày khác.");
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
