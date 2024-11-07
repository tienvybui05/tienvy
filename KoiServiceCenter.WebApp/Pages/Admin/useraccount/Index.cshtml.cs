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
	public class IndexModel : PageModel
    {
        private readonly IUserAccountService _service;

        public IndexModel(IUserAccountService service)
        {
            _service = service;
        }

        public IList<UserAccount> UserAccount { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                UserAccount = await _service.SearcheAsync(searchString);
            }
            else
            {
                UserAccount = await _service.GetUserAccountsAsync();
            }
        }
    }
}
