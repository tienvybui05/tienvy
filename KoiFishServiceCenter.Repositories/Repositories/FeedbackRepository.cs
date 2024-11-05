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
        public async Task<bool> AddFeedback(Feedback feedback)
        {
            try
            {
                await _dbContext.Feedbacks.AddAsync(feedback);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Lỗi khi thêm đánh giá từ người dùng", ex);
            }
        }

        public async Task<bool> DelFeedback(int Id)
        {
            try
            {
                var objDel = _dbContext.Feedbacks.Where(p => p.FeedbackId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Feedbacks.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Lỗi", ex);
            }
        }

        public async Task<bool> DelFeedback(Feedback feedback)
        {
            try
            {
                _dbContext.Feedbacks.Remove(feedback);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Lỗi", ex);
            }
        }

        public async Task<bool> UpdateFeedback(Feedback feedback)
        {
            try
            {
                _dbContext.Feedbacks.Update(feedback);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Lỗi", ex);
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
        public async Task<int> CountFeedback()
        {
            int count = 0;
            var ojb = await _dbContext.Feedbacks.Include(v => v.FeedbackId).ToListAsync();
            foreach (var i in ojb)
            {
                count++;
            }
            return count;
        }
    }
}
