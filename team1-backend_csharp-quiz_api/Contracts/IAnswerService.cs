using System;
using team1_backend_csharp_quiz_api.DTO;
using team1_backend_csharp_quiz_api.DTO.Answer;
using team1_backend_csharp_quiz_api.DTO.Question;
using team1_backend_csharp_quiz_api.Entities;

namespace team1_backend_csharp_quiz_api.Contracts
{
	public interface IAnswerService
	{
        
        Task<GetAnswerDto> GetAnswer(Guid id);

        Task<List<GetAnswerDto>> GetAnswersList();

        Task<bool> UpdateAnswer(Guid id, UpdateAnswerDto answerDto);

        Task<Answer> AddAnswer(CreateAnswerDto answerDto);

        Task<bool> RemoveAnswer(Guid id);

        Task<bool> AnswerExists(Guid id);
    }
}

