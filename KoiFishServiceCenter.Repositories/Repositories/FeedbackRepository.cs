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
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly KoiVetServicesDbContext _dbContext;
        public FeedbackRepository(KoiVetServicesDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public bool AddFeedback(Feedback feedback)
        {
            try
            {
                _dbContext.Feedbacks.AddAsync(feedback);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelFeedback(int Id)
        {
            try
            {
                var objDel = _dbContext.Feedbacks.Where(p => p.FeedbackId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Feedbacks.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelFeedback(Feedback feedback)
        {
            try
            {
                _dbContext.Feedbacks.Remove(feedback);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
                return false;
            }
        }

        public async Task<Feedback> GetFeedbackById(int Id)
        {
            return await _dbContext.Feedbacks.Where(p => p.FeedbackId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Feedback>> GetFeedbacksAsync()
        {
            return await _dbContext.Feedbacks.ToListAsync();
        }

        public bool UpdateFeedback(Feedback feedback)
        {
           try
           {
                _dbContext.Feedbacks.Update(feedback);
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
