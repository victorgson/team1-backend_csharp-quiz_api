using team1_backend_csharp_quiz_api.Entities;

namespace team1_backend_csharp_quiz_api.Services
{
    public interface IQuestionService
    {
        Task<Question> RandomQuestionFromList();
    }
}