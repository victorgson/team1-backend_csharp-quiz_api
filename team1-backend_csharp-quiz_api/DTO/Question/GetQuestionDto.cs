﻿using System;
namespace team1_backend_csharp_quiz_api.DTO.Question
{
	public class GetQuestionDto
	{
        public Guid Id { get; set; }
        public string Language { get; set; }
        public string QuestionString { get; set; }
        public string Category { get; set; }
    }
}
