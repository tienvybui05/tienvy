using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiServiceCenter.WebApp.Pages.Admin.Account
{
    public class LogoutModel : PageModel
    {
		public async Task<IActionResult> OnPostAsync()
		{
			await HttpContext.SignOutAsync("AdminCookieAuth");
			return RedirectToPage("/Admin/Index");

		}
	}
}
