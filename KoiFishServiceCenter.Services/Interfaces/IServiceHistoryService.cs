﻿using KoiFishServiceCenter.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Services.Interfaces
{
    public interface IServiceHistoryService
    {
        Task<List<ServiceHistory>> GetServiceHistories();
        Task<bool> DelServiceHistory(int Id);
        Task<bool> DelServiceHistory(ServiceHistory serviceHistory);
        Task<bool> AddServiceHistory(ServiceHistory serviceHistory);
        Task<bool> UpdateServiceHistory(ServiceHistory serviceHistory);
        Task<ServiceHistory> GetServiceHistoryById(int Id);
        SelectList GetServiceHistorySelect(string viewData);
        Task<List<ServiceHistory>> SearcheAsync(string searchString);
    }
}
