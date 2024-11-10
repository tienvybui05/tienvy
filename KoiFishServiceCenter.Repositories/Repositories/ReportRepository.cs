using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Repositories.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly KoiVetServicesDbContext _dbContext;
        public ReportRepository(KoiVetServicesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddReportAsync(Report report)
        {
            try
            {
                await _dbContext.Reports.AddAsync(report);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DelReportAsync(int Id)
        {
            try
            {
                var objDel = _dbContext.Reports.Where(p => p.ReportId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Reports.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.ToString());
            }
        }

        public async Task<bool> DelReportAsync(Report report)
        {
            try
            {
                _dbContext.Reports.Remove(report);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<Report> GetReportByIdAsync(int Id)
        {
            return await _dbContext.Reports.Where(p => p.ReportId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Report>> GetReportsAsync()
        {
            return await _dbContext.Reports.ToListAsync();
        }

        public async Task<bool> UpdateReportAsync(Report report)
        {
            try
            {
                _dbContext.Reports.Update(report);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<int> CountReport()
        {
            int count = 0;
            var ojb = await _dbContext.Reports.ToListAsync();
            foreach (var i in ojb)
            {
                count++;
            }
            return count;
        }
        public async Task<List<Report>> SearchAsync(DateTime dateTime)
        {
            return await _dbContext.Reports.Where(a => (a.ReportDate.Day == dateTime.Day) &&
                                                            (a.ReportDate.Month == dateTime.Month) &&
                                                            (a.ReportDate.Year == dateTime.Year)).ToListAsync();
        }
    }
}
