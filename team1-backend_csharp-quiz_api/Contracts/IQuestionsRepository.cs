using System;
using team1_backend_csharp_quiz_api.Entities;

namespace team1_backend_csharp_quiz_api.Contracts
{
	public interface IQuestionsRepository : IGenericRepository<Question>
	{

        Task<Question> GetRandomAsync();

        Task<List<Question>> GetAllQuestions();

    }
}

