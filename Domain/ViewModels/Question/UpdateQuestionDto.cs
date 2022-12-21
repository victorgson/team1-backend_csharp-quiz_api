using System;
using team1_backend_csharp_quiz_api.Application.DTO.Question;

namespace Quiz.Domain.DTO.Question
{
	public class UpdateQuestionDto : BaseQuestionDto
    {
        public Guid Id { get; set; }
      
       
	}
}

