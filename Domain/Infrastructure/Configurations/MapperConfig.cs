using System;
using AutoMapper;
using team1_backend_csharp_quiz_api.DTO;
using team1_backend_csharp_quiz_api.DTO.Question;
using team1_backend_csharp_quiz_api.DTO.Answer;
using team1_backend_csharp_quiz_api.Entities;

namespace Quiz.Infrastructure.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<Question, CreateQuestionDto>().ReverseMap();
            CreateMap<Question, UpdateQuestionDto>().ReverseMap();
            CreateMap<Question, GetQuestionDto>().ReverseMap();

            CreateMap<Answer, GetAnswerDto>().ReverseMap();
            CreateMap<Answer, CreateAnswerDto>().ReverseMap();
            CreateMap<Answer, UpdateAnswerDto>().ReverseMap();
            CreateMap<TriviaQuizQuestion, Question>().ReverseMap();
            CreateMap<QuizQuestionDto, QuizGameQuestion>().ReverseMap();

        }
	}
}

