using team1_backend_csharp_quiz_api.Infrastructure.Models;

namespace team1_backend_csharp_quiz_api.Domain;

public interface ITriviaQuizRepository
{
    Task<TriviaQuizQuestion> GetTriviaQuestion();
}
