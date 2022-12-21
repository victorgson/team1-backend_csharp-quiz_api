using System;
using AutoMapper;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.DTO.Answer;
using team1_backend_csharp_quiz_api.DTO.Question;
using team1_backend_csharp_quiz_api.Entities;

namespace Quiz.Application.Services
{
    public class AnswerService : IAnswerService
    {

        private readonly IAnswersRepository _repository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswersRepository repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }

        public async Task<Answer> AddAnswer(CreateAnswerDto answerDto)
        {

            var answer = _mapper.Map<Answer>(answerDto);
            await _repository.AddSync(answer);

            return answer;

        }

        public async Task<bool> AnswerExists(Guid id)
        {
            return await _repository.Exists(id);

        }

        public async Task<GetAnswerDto> GetAnswer(Guid id)
        {
            var answer = await _repository.GetAsync(id);
            var answerDto = _mapper.Map<GetAnswerDto>(answer);

            return answerDto;
        }

        public async Task<List<GetAnswerDto>> GetAnswersList()
        {
            var answers = await _repository.GetAllAsync();
            var records = _mapper.Map<List<GetAnswerDto>>(answers);

            return records; 
        }

        public async Task<bool> RemoveAnswer(Guid id)
        {

            var answer = await _repository.GetAsync(id);
            if (answer is null)
            {
                return false;
            }

            await _repository.DeleteAsync(id);

            return true;


        }

        public async Task<bool> UpdateAnswer(Guid id, UpdateAnswerDto answerDto)
        {

            var answer = await _repository.GetAsync(id);
            _mapper.Map(answerDto, answer);
            if (answer is null)
            {
                return false;
            }
            else
            {
                await _repository.UpdateAsync(answer);
                return true;
            }

        }
    }
}

