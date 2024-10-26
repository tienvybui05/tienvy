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
        bool DelFeedback(int Id);
        bool DelFeedback(Feedback feedback);
        bool AddFeedback(Feedback feedback);
        bool UpdateFeedback(Feedback feedback);
        Task<Feedback> GetFeedbackById(int Id);
    }
}
