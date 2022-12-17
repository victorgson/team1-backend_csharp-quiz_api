using System;
using team1_backend_csharp_quiz_api.Entities;
using team1_backend_csharp_quiz_api.Persistance;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.Services;

namespace team1_backend_csharp_quiz_api.Repository
{
    public class QuestionsRepository : GenericRepository<Question>, IQuestionsRepository
    {
        private readonly QuizDatabaseContext _context;
        public QuestionsRepository(QuizDatabaseContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Question> GetRandomAsync()
        {
            Random r = new Random();
            var tableToList = _context.Questions.ToList();
            var question = tableToList.ElementAt(r.Next(0, tableToList.Count()));
            return question; 
        }
    }
}

