using System;
using Microsoft.Build.Framework;
namespace Quiz.Domain.DTO.Answer
{
	public class BaseAnswerDto
	{
        [Required]
        public Guid QuestionId { get; set; }
        public string AnswerString { get; set; }
        public bool isCorrectAnswer { get; set; }
    }
}

