using KoiFishServiceCenter.Repositories.Entities;
using KoiFishServiceCenter.Repositories.Interfaces;
using KoiFishServiceCenter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public Task<bool> DelFeedback(int Id)
        {
           return _repository.DelFeedback(Id);
        }

        public Task<bool> DelFeedback(Feedback feedback)
        {
            return _repository.DelFeedback(feedback);
        }

        public Task<bool> AddFeedback(Feedback feedback)
        {
            return _repository.AddFeedback(feedback);
        }

        public Task< bool> UpdateFeedback(Feedback feedback)
        {
            return _repository.UpdateFeedback(feedback);
        }

        public Task<Feedback> GetFeedbackById(int Id)
        {
            return _repository.GetFeedbackById(Id);
        }
        public async Task<int> CountFeedback()
        {
            return await _repository.CountFeedback();
        }

        public Task<List<Feedback>> SearchAsync(string searchString)
        {
            return _repository.SearchAsync(searchString);
        }

        public SelectList GetFeedbackSelect(string viewData)
        {
            return _repository.GetFeedbackSelect(viewData);
        }
    }
}
