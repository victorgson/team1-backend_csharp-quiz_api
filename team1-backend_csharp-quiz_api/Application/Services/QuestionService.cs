using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.DTO;
using team1_backend_csharp_quiz_api.DTO.Question;
using team1_backend_csharp_quiz_api.Entities;

namespace team1_backend_csharp_quiz_api.Services
{
    public class QuestionService : IQuestionService
    {

        public IQuestionsRepository _repository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Question> RandomQuestionFromList()
        {
            Random r = new Random();

            var allQuestions = await _repository.GetAllQuestions();

            var question = allQuestions.ElementAt(r.Next(0, allQuestions.Count));

            return question;
        }


        public async Task<List<GetQuestionDto>> GetQuestionsList()
        {
            var questions = await _repository.GetAllAsync();
            var questionsList = _mapper.Map<List<GetQuestionDto>>(questions);

            return questionsList;

        }

        public async Task<GetQuestionDto> GetQuestion(Guid id)
        {
            var question = await _repository.GetAsync(id);
            var questionDto = _mapper.Map<GetQuestionDto>(question);

            return questionDto;

        }

        public async Task<bool> UpdateQuestion(Guid id, UpdateQuestionDto questionDto)
        {
            
            var question = await _repository.GetAsync(id);
            _mapper.Map(questionDto, question);
            if (question is null)
            {
                return false; 
            } else
            {
                await _repository.UpdateAsync(question);
                return true; 
            }

        }

        public async Task<Question> AddQuestion(CreateQuestionDto questionDto)
        {

            var question = _mapper.Map<Question>(questionDto);
            await _repository.AddSync(question);

            return question; 

        }


        public async Task<bool> RemoveQuestion(Guid id)
        {
            var question = await _repository.GetAsync(id);
            if (question is null)
            {
                return false;
            }

            await _repository.DeleteAsync(id);

            return true;

        }

        public async Task<bool> QuestionExists(Guid id)
        {
            return await _repository.Exists(id);
        }


    }
}