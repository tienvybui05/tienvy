using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace KoiServiceCenter.WebApp.Pages.Admin.useraccount
{
	[Authorize(Policy = "ManagerOnly")]
	public class EditModel : PageModel
    {
        private readonly IUserAccountService _service;

        public EditModel(IUserAccountService service)
        {
            _service = service;
        }

        [BindProperty]
        public UserAccount UserAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id;
            if (id == null)
            {
                Id = 0;
                return NotFound();
            }
            Id = (int)id;
            UserAccount = await _service.GetUserByIdAsync(Id);
            if (UserAccount == null)
            {
                return NotFound();
            }
            ViewData["Role"] = _service.GetRoleSelect();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ViewData["Role"] = _service.GetRoleSelect();
            await _service.UpdateUserAccountAsync(UserAccount);
            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccountExists(UserAccount.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserAccountExists(int id)
        {
            return _service.GetUserByIdAsync(id) != null;
        }
    }
}
