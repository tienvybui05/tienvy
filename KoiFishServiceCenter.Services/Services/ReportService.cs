using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using KoiFishServiceCenter.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Services.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;
        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> AddReport(Report report)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DelReport(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DelReport(Report report)
        {
            throw new NotImplementedException();
        }

        public Task<Report> GetReportById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Report>> GetReportsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateReport(Report report)
        {
            throw new NotImplementedException();
        }
    }
}
