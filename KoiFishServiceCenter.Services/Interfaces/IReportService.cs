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
        Task<bool> DelReport(int Id);
        Task<bool> DelReport(Report report);
        Task<bool> AddReport(Report report);
        Task<bool> UpdateReport(Report report);
        Task<Report> GetReportById(int Id);
    }
}
