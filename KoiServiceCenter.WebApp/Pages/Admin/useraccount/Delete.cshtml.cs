using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace KoiServiceCenter.WebApp.Pages.Admin.useraccount
{
	[Authorize(Policy = "ManagerOnly")]
	public class DeleteModel : PageModel
    {
        private readonly IUserAccountService _service;

        public DeleteModel(IUserAccountService service)
        {
            _service = service;
        }

        [BindProperty]
        public UserAccount UserAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int ID;
            if (id == null)
            {
                ID = 0;
                return NotFound();
            }
            ID = (int)id;
            UserAccount = await _service.GetUserByIdAsync(ID);

            if (UserAccount == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            int ID;
            if (id == null)
            {
                ID = 0;
                return NotFound();
            }
            ID = (int)id;
            UserAccount = await _service.GetUserByIdAsync(ID);

            if (UserAccount != null)
            {
                await _service.DeleteUserAccountAsync(ID);
            }

            return RedirectToPage("./Index");
        }
    }
}
