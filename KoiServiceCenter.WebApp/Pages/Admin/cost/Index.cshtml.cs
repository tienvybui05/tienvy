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

namespace KoiServiceCenter.WebApp.Pages.Admin.cost
{
	[Authorize(Policy = "ManagerOrStaffOnly")]
	public class IndexModel : PageModel
    {
        private readonly ICostService _service;

        public IndexModel(ICostService service)
        {
            _service = service;
        }

        public IList<Cost> Cost { get; set; }

        public async Task OnGetAsync(int? search)
        {
            if (search.HasValue)
            {
                Cost = await _service.SearchAsync(search.Value);
            }
            else
            {
                //Nếu không có FeedbackId, lấy tất cả feedbacks
                Cost = await _service.GetCostsAsync();
            }
        }
    }
}


