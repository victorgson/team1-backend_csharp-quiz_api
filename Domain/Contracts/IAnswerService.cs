using System;
using Quiz.Domain.DTO.Answer;
using Quiz.Domain.DTO.Question;
using Quiz.Domain.Entities;

namespace Quiz.Domain.Contracts
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

