﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly IReportService _service;

        public DetailsModel(IReportService service)
        {
            _service = service;
        }

        public Report Report { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int ID;
            if (id == null)
            {
                ID = 0;
                return NotFound();
            }
            ID = (int)id;
            Report = await _service.GetReportByIdAsync(ID);

            if (Report == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
