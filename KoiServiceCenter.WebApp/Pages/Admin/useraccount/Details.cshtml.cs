using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;

namespace KoiServiceCenter.WebApp.Pages.Admin.useraccount
{
    public class DetailsModel : PageModel
    {
        private readonly IUserAccountService _service;

        public DetailsModel(IUserAccountService service)
        {
            _service = service;
        }

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
    }
}
