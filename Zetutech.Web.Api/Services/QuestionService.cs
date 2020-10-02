using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zetutech.Web.Api.ApplicationCore.Entities;
using Zetutech.Web.Api.ApplicationCore.Interfaces;
using Zetutech.Web.Api.ApplicationCore.Specifications;
using Zetutech.Web.Api.Interfaces;

namespace Zetutech.Web.Api.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IAsyncRepository<Question> _asyncQuestionRepository;
        public QuestionService(IRepository<Question> questionRepository, IAsyncRepository<Question> asyncQuestionRepository)
        {
            _questionRepository = questionRepository;
            _asyncQuestionRepository = asyncQuestionRepository;
        }
        public IEnumerable<Question> GetAll()
        {
            var questions = _questionRepository.ListAll().ToList();
            return questions;
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            var questions = await _asyncQuestionRepository.ListAllAsync();
            return questions;
        }

        public async Task<IEnumerable<Question>> GetAllAsync(int pageIndex, int itemsPage, int? questionId)
        {
            var filterPaginatedSpecification =
                new QuestionsFilterPaginatedSpecification(itemsPage * pageIndex, itemsPage, questionId);
            var questions = await _asyncQuestionRepository.ListAllAsync(filterPaginatedSpecification);
            return questions;
        }
    }
}
