using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;

namespace KoiServiceCenter.WebApp.Pages.Admin.report
{
    public class IndexModel : PageModel
    {
        private readonly IReportService _service;

        public IndexModel(IReportService service)
        {
            _service = service;
        }

        public IList<Report> Report { get; set; }

        public async Task OnGetAsync(DateTime dateTime)
        {
            if (dateTime != DateTime.MinValue)
            {
                Report = await _service.SearchAsync(dateTime);
            }
            else
            {
                Report = await _service.GetReportsAsync();
            }
        }
    }
}
