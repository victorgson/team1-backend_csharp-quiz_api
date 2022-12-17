using System;
using team1_backend_csharp_quiz_api.DTO.Question;

namespace team1_backend_csharp_quiz_api.DTO
{
	public class UpdateQuestionDto : BaseQuestionDto
    {
        public Guid Id { get; set; }
      
       
	}
}

