using Quiz.Domain.DTO.Answer;
using Quiz.Domain.DTO.Question;
using Quiz.Domain.Entities;

namespace Quiz.Domain.Contracts
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