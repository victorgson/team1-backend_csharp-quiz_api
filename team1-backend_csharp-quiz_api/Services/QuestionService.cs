using System;
using Microsoft.EntityFrameworkCore;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.Entities;

namespace team1_backend_csharp_quiz_api.Services
{
    public class QuestionService : IQuestionService
    {

        public IQuestionsRepository _repository;

        public QuestionService(IQuestionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Question> RandomQuestionFromList()
        {
            Random r = new Random();

            var allQuestions = await _repository.GetAllQuestions();

            var question = allQuestions.ElementAt(r.Next(0, allQuestions.Count));

            return question;
        }


    }
}