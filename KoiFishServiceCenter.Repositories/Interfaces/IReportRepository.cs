using KoiFishServiceCenter.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<List<Report>> GetReportsAsync();
        Task<bool> DelReportAsync(int Id);
        Task<bool> DelReportAsync(Report report);
        Task<bool> AddReportAsync(Report report);
        Task<bool> UpdateReportAsync(Report report);
        Task<Report> GetReportByIdAsync(int Id);
        Task<int> CountReport();
        Task<List<Report>> SearchAsync(DateTime dateTime);
        Task<int> CreateId();
    }
}