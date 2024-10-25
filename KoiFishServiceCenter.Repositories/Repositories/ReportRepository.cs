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
        public bool AddReport(Report report)
        {
            try
            {
                _dbContext.Reports.AddAsync(report);
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelReport(int Id)
        {
            try
            {
                var objDel = _dbContext.Reports.Where(p => p.ReportId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Reports.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.ToString());
            }
        }

        public bool DelReport(Report report)
        {
            try
            {
                _dbContext.Reports.Remove(report);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<Report> GetReportById(int Id)
        {
            return await _dbContext.Reports.Where(p => p.ReportId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Report>> GetReportsAsync()
        {
            return await _dbContext.Reports.ToListAsync();
        }

        public bool UpdateReport(Report report)
        {
            try
            {
                _dbContext.Reports.Update(report);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
