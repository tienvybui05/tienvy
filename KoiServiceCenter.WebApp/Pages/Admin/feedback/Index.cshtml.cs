using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace KoiServiceCenter.WebApp.Pages.Admin.feedback
{
	[Authorize(Policy = "ManagerOrStaffOnly")]
	public class IndexModel : PageModel
    {
        private readonly IFeedbackService _service;

        public IndexModel(IFeedbackService service)
        {
            _service = service;
        }

        public IList<Feedback> Feedback { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Feedback = await _service.SearchAsync(searchString);
            }

            else
            {
                //Nếu không có FeedbackId, lấy tất cả feedbacks
                Feedback = await _service.GetFeedbacksAsync();
            }
        }
    }
}
