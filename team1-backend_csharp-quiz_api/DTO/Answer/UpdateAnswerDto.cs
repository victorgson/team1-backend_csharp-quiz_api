using System;
namespace team1_backend_csharp_quiz_api.DTO.Answer
{
	public class UpdateAnswerDto
	{
        public Guid Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerString { get; set; }
        public bool isCorrectAnswer { get; set; }
    }
}

