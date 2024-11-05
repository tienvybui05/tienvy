using KoiFishServiceCenter.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishServiceCenter.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<List<Feedback>> GetFeedbacksAsync();
        Task<bool> DelFeedback(int Id);
        Task<bool> DelFeedback(Feedback feedback);
        Task<bool> AddFeedback(Feedback feedback);
        Task<bool> UpdateFeedback(Feedback feedback);
        Task<Feedback> GetFeedbackById(int Id);
        Task<int> CountFeedback();
    }
}
