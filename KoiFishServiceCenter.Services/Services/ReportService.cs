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
            //Kiểm tra nhập liệu rỗng
            if (report == null)
                throw new ArgumentNullException(nameof(report), "Báo cáo không được để trống.");

            // Kiểm tra điều kiện dữ liệu
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

            return _repository.AddReport(report);
        }

        public bool DelReport(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương", nameof(Id));
            }
            return (_repository.DelReport(Id));
        }

        public bool DelReport(Report report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report), "Báo cáo không được để trống.");
            return _repository.DelReport(report);
        }

        public Task<Report> GetReportById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("ID không hợp lệ, chỉ chấp nhận số nguyên dương", nameof(Id));
            }
            return _repository.GetReportById(Id);
        }

        public Task<List<Report>> GetReportsAsync()
        {
            return _repository.GetReportsAsync();
        }

        public bool UpdateReport(Report report)
        {
            //Kiểm tra nhập liệu rỗng
            if (report == null)
                throw new ArgumentNullException(nameof(report), "Báo cáo không được để trống.");

            // Kiểm tra điều kiện dữ liệu
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

            return _repository.UpdateReport(report);
        }
    }
}
