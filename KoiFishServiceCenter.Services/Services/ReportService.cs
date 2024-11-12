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
            if (report == null)
                throw new ArgumentNullException(nameof(report), "Báo cáo không được để trống.");

            if (report.ReportId <= 0)
                throw new ArgumentException("Mã báo cáo phải là số nguyên dương.", nameof(report.ReportId));

            if (report.ReportDate == default(DateTime))
                throw new ArgumentException("Ngày báo cáo không được để trống hoặc mặc định.", nameof(report.ReportDate));
            else if (report.ReportDate > DateTime.Now)
                throw new ArgumentException("Ngày báo cáo không được là một ngày trong tương lai.", nameof(report.ReportDate));
            else
            {
                try
                {
                    DateTime ngayHopLe = new DateTime(report.ReportDate.Year, report.ReportDate.Month, report.ReportDate.Day);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new ArgumentException("Ngày báo cáo không hợp lệ hoặc không tồn tại.", nameof(report.ReportDate));
                }
            }

            if (report.TotalCustomers < 0)
                throw new ArgumentException("Tổng khách hàng phải là số nguyên không âm.", nameof(report.TotalCustomers));

            if (report.TotalServices < 0)
                throw new ArgumentException("Tổng dịch vụ thực hiện phải là số nguyên không âm.", nameof(report.TotalServices));

            if (report.AverageRating < 0 || report.AverageRating > 5)
                throw new ArgumentException("Điểm đánh giá phải nằm trong khoảng từ 0 đến 5.", nameof(report.AverageRating));

            if (string.IsNullOrWhiteSpace(report.Notes))
                throw new ArgumentException("Ghi chú báo cáo không được để trống hoặc chỉ chứa khoảng trắng.", nameof(report.Notes));

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
            if (report == null)
                throw new ArgumentNullException(nameof(report), "Báo cáo không được để trống.");

            if (report.ReportId <= 0)
                throw new ArgumentException("Mã báo cáo phải là số nguyên dương.", nameof(report.ReportId));

            if (report.ReportDate == default(DateTime))
                throw new ArgumentException("Ngày báo cáo không được để trống hoặc mặc định.", nameof(report.ReportDate));
            else if (report.ReportDate > DateTime.Now)
                throw new ArgumentException("Ngày báo cáo không được là một ngày trong tương lai.", nameof(report.ReportDate));
            else
            {
                try
                {
                    DateTime ngayHopLe = new DateTime(report.ReportDate.Year, report.ReportDate.Month, report.ReportDate.Day);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new ArgumentException("Ngày báo cáo không hợp lệ hoặc không tồn tại.", nameof(report.ReportDate));
                }
            }

            if (report.TotalCustomers < 0)
                throw new ArgumentException("Tổng khách hàng phải là số nguyên không âm.", nameof(report.TotalCustomers));

            if (report.TotalServices < 0)
                throw new ArgumentException("Tổng dịch vụ thực hiện phải là số nguyên không âm.", nameof(report.TotalServices));

            if (report.AverageRating < 0 || report.AverageRating > 5)
                throw new ArgumentException("Điểm đánh giá phải nằm trong khoảng từ 0 đến 5.", nameof(report.AverageRating));

            if (string.IsNullOrWhiteSpace(report.Notes))
                throw new ArgumentException("Ghi chú báo cáo không được để trống hoặc chỉ chứa khoảng trắng.", nameof(report.Notes));

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
