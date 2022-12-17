using System;
using Microsoft.Build.Framework;
namespace team1_backend_csharp_quiz_api.DTO.Answer
{
	public class BaseAnswerDto
	{
        [Required]
        public int QuestionId { get; set; }
        public string AnswerString { get; set; }
        public bool isCorrectAnswer { get; set; }
    }
}

