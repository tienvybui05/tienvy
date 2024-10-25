using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Repositories.Repositories
{
    public class ReportRepository : IReportRepository
    {
        public bool AddReport(Report report)
        {
            throw new NotImplementedException();
        }

        public bool DelReport(int Id)
        {
            throw new NotImplementedException();
        }

        public bool DelReport(Report report)
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

        public bool UpdateReport(Report report)
        {
            throw new NotImplementedException();
        }
    }
}
