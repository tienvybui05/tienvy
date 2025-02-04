﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace KoiServiceCenter.WebApp.Pages.Admin.services
{
	[Authorize(Policy = "ManagerOrStaffOnly")]
	public class IndexModel : PageModel
    {
        private readonly IServiceService _service;

        public IndexModel(IServiceService service)
        {
            _service = service;
        }

        public IList<Service> Service { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Service = await _service.SearcheAsync(searchString);
            }
            else
            {
                Service = await _service.GetServicesAsync();
            }
        }
    }
}
