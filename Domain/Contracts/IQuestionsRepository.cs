using System;
using Quiz.Domain.Entities;

namespace Quiz.Domain.Contracts
{
	public interface IQuestionsRepository : IGenericRepository<Question>
	{

        Task<List<Question>> GetAllQuestions();

    }
}

