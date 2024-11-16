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

        public async Task<bool> AddReportAsync(Report report)
        {
            DateTime currentDate = DateTime.Today;
            if ( report.ReportDate != currentDate)
            {
                return false;
            }  
            return await _repository.AddReportAsync(report);
        }

        public async Task<bool> DelReportAsync(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương", nameof(Id));
            }
            return await _repository.DelReportAsync(Id);
        }

        public async Task<bool> DelReportAsync(Report report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report), "Báo cáo không được để trống.");
            return await _repository.DelReportAsync(report);
        }

        public async Task<Report> GetReportByIdAsync(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương", nameof(Id));
            }
            return await _repository.GetReportByIdAsync(Id);
        }

        public async Task<List<Report>> GetReportsAsync()
        {
            return await _repository.GetReportsAsync();
        }

        public async Task<bool> UpdateReportAsync(Report report)
        {

            return await _repository.UpdateReportAsync(report);
        }

        public async Task<int> CountReport()
        {
            return await _repository.CountReport();
        }
        public Task<List<Report>> SearchAsync(DateTime dateTime)
        {
            return _repository.SearchAsync(dateTime);
        }
        public Task<int> CreateId()
        {
            return _repository.CreateId();
        }
    }
}
