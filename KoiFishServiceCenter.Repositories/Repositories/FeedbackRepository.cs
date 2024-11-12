using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            if (feedback.Rating < 1 || feedback.Rating > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(feedback.Rating), "Đánh giá phải từ 1 đến 5 sao.");
            }

            try
            {
                await _dbContext.Feedbacks.AddAsync(feedback);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Lỗi", ex);
            }
            //try
            //{
            //    await _dbContext.Feedbacks.AddAsync(feedback);
            //    await _dbContext.SaveChangesAsync();
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    throw new NotImplementedException("Lỗi khi thêm đánh giá từ người dùng", ex);
            //}
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
            return await _dbContext.Feedbacks.Include(s => s.Customer).Include(s => s.Service).FirstOrDefaultAsync(f => f.FeedbackId == Id);
            //return await _dbContext.Feedbacks.Where(p => p.FeedbackId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Feedback>> GetFeedbacksAsync()
        {
            return await _dbContext.Feedbacks.Include(s => s.Customer).Include(s => s.Service).ToListAsync();
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

        public async Task<List<Feedback>> SearchAsync(string searchString)
        {
            return await _dbContext.Feedbacks
                .Where(f => f.Customer.FullName.Contains(searchString))
                .Include(f => f.Customer) 
                .Include(f => f.Service)
/*                .Where(f => f.Customer.FullName.Contains(searchString))*/ // Tìm kiếm theo tên khách hàng
                .ToListAsync();
        }

        public SelectList GetFeedbackSelect(string viewData)
        {
            if (viewData == "CustomerId")
            {
                return new SelectList(_dbContext.Customers, "CustomerId", "FullName");
            }
            else if (viewData == "ServiceId")
            {
                return new SelectList(_dbContext.Services, "ServiceId", "Description");
            }
            else
            {
                return new SelectList(_dbContext.UserAccounts, "UserId", "Email");
            }
        }

        public async Task<int> CreateId()
        {
            Random random = new Random();
            int id;
            do
            {
                id = random.Next(1, 1001);
                var ojb = await GetFeedbackById(id);
                if (ojb == null)
                {
                    return id;
                }
            } while (true);
        }
    }
}
