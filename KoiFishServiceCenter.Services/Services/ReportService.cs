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
        public bool AddReport(Report report)
        {
            return _repository.AddReport(report);
        }

        public bool DelReport(int Id)
        {
            return (_repository.DelReport(Id));
        }

        public bool DelReport(Report report)
        {
            return _repository.DelReport(report);
        }

        public Task<Report> GetReportById(int Id)
        {
            return _repository.GetReportById(Id);
        }

        public Task<List<Report>> GetReportsAsync()
        {
            return _repository.GetReportsAsync();
        }

        public bool UpdateReport(Report report)
        {
            return _repository.UpdateReport(report);
        }
    }
}
