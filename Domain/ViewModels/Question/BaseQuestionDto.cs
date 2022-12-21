using System;
using Microsoft.Build.Framework;
namespace Quiz.Domain.DTO.Question
{
	public class BaseQuestionDto
	{
        [Required]
        public string Language { get; set; }
        public string QuestionString { get; set; }
        public string Category { get; set; }

    }
}

