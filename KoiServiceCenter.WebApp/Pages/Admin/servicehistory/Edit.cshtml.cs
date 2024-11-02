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

namespace KoiServiceCenter.WebApp.Pages.Admin.servicehistory
{
    public class EditModel : PageModel
    {
        private readonly IServiceHistoryService _service;

        public EditModel(IServiceHistoryService service)
        {
            _service = service;
        }

        [BindProperty]
        public ServiceHistory ServiceHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int ID;
            if (id == null)
            {
                ID = 0;
                return NotFound();
            }
            ID = (int)id;
            ServiceHistory = await _service.GetServiceHistoryById(ID);

            if (ServiceHistory == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = _service.GetServiceHistorySelect("CustomerId");
            ViewData["ServiceId"] = _service.GetServiceHistorySelect("ServiceId");
            ViewData["VeterinarianId"] = _service.GetServiceHistorySelect("VeterinarianId");
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

            await _service.UpdateServiceHistory(ServiceHistory);

            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceHistoryExists(ServiceHistory.HistoryId))
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

        private bool ServiceHistoryExists(int id)
        {
            return _service.GetServiceHistoryById(id) != null;
        }
    }
}
