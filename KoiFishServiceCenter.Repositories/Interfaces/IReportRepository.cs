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
        bool DelReport(int Id);
        bool DelReport(Report report);
        bool AddReport(Report report);
        bool UpdateReport(Report report);
        Task<Report> GetReportById(int Id);
    }
}
