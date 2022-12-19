using Microsoft.AspNetCore.Mvc;
using team1_backend_csharp_quiz_api.DTO;
using team1_backend_csharp_quiz_api.DTO.Question;
using team1_backend_csharp_quiz_api.Entities;

namespace team1_backend_csharp_quiz_api.Services
{
    public interface IQuestionService
    {
        Task<GetQuestionDto> RandomQuestionFromList();

        Task<List<GetQuestionDto>> GetQuestionsList();

        Task<GetQuestionDto> GetQuestion(Guid id);

       

    }
}