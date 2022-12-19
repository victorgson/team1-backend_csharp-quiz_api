using team1_backend_csharp_quiz_api.DTO;
using team1_backend_csharp_quiz_api.DTO.Question;
using team1_backend_csharp_quiz_api.Entities;

namespace team1_backend_csharp_quiz_api.Services
{
    public interface IQuestionService
    {
        Task<Question> RandomQuestionFromList();

        Task<List<GetQuestionDto>> GetQuestionsList();

        Task<GetQuestionDto> GetQuestion(Guid id);

        Task<bool> UpdateQuestion(Guid id, UpdateQuestionDto questionDto);

        Task<Question> AddQuestion(CreateQuestionDto questionDto);

        Task<bool> RemoveQuestion(Guid id);

        Task<bool> QuestionExists(Guid id);

    }
}