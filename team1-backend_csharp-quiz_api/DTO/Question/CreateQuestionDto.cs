using System;
using Microsoft.Build.Framework;
namespace team1_backend_csharp_quiz_api.DTO
{
	public class CreateQuestionDto
	{
        [Required]
        public string Language { get; set; }
        public string QuestionString { get; set; }
        public string Category { get; set; }
    }
}

