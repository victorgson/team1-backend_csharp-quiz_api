using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.DTO.Question;
using team1_backend_csharp_quiz_api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using team1_backend_csharp_quiz_api.DTO;

namespace team1_backend_csharp_quiz_api.Services
{
    public class QuestionService : IQuestionService
    {

        public IQuestionsRepository _repository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionsRepository repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }

        public async Task<GetQuestionDto> RandomQuestionFromList()
        {
            Random r = new Random();

            var allQuestions = await _repository.GetAllQuestions();

            var question = allQuestions.ElementAt(r.Next(0, allQuestions.Count));

            var questionDto = _mapper.Map<GetQuestionDto>(question);

            return questionDto;
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

        //public async Task<CreateQuestionDto> AddQuestion(CreateQuestionDto createQuestionDto)
        //{
        //    var question = _mapper.Map<Question>(createQuestionDto);
        //    await _repository.AddSync(question);
        //    return question;
        //}

        //public async Task<IActionResult> ChangeQuestion(Guid id, UpdateQuestionDto questionDto)
        //{

        //}
    }
}