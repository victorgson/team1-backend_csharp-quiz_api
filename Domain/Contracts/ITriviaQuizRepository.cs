using Quiz.Domain.Entities;

namespace Quiz.Domain.Contracts;
public interface ITriviaQuizRepository
{
    Task<TriviaQuizQuestion> GetTriviaQuestion();
}
