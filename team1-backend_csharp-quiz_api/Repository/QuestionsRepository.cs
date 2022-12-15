using System;
using team1_backend_csharp_quiz_api.Entities;
using team1_backend_csharp_quiz_api.Persistance;
using team1_backend_csharp_quiz_api.Contracts;

namespace team1_backend_csharp_quiz_api.Repository
{
    public class QuestionsRepository : GenericRepository<Question>, IQuestionsRepository
    {
        public QuestionsRepository(QuizDatabaseContext context) : base(context)
        {
        }
    }
}

