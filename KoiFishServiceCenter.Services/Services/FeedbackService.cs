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
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repository;
        public FeedbackService(IFeedbackRepository repository)
        {
            _repository = repository;
        }
        public Task<List<Feedback>> GetFeedbacksAsync()
        {
            return _repository.GetFeedbacksAsync();
        }

        public bool DelFeedback(int Id)
        {
           return _repository.DelFeedback(Id);
        }

        public bool DelFeedback(Feedback feedback)
        {
            return _repository.DelFeedback(feedback);
        }

        public bool AddFeedback(Feedback feedback)
        {
            return _repository.AddFeedback(feedback);
        }

        public bool UpdateFeedback(Feedback feedback)
        {
            return _repository.UpdateFeedback(feedback);
        }

        public Task<Feedback> GetFeedbackById(int Id)
        {
            return _repository.GetFeedbackById(Id);
        }
    }
}
