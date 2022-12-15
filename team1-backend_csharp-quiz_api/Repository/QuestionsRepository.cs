using System;
using team1_backend_csharp_quiz_api.Persistance;

namespace team1_backend_csharp_quiz_api.Repository
{
	public class QuestionsRepository
	{
        private readonly QuizDatabaseContext _context;
        public QuestionsRepository(QuizDatabaseContext context)
		{
            this._context = context;
        }
	}
}

