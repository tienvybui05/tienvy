using KoiFishServiceCenter.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Services.Interfaces
{
    public interface IReportService
    {
        Task<List<Report>> GetReportsAsync();
        Task<bool> DelReportAsync(int Id);
        Task<bool> DelReportAsync(Report report);
        Task<bool> AddReportAsync(Report report);
        Task<bool> UpdateReportAsync(Report report);
        Task<Report> GetReportByIdAsync(int Id);
    }
}
