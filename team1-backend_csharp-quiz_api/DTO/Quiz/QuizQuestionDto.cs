using System;
using Microsoft.Build.Framework;
namespace team1_backend_csharp_quiz_api.DTO.Question
{
    public class QuizQuestionDto
    {
        public string QuestionString { get; set; }
        public List<string> Answers { get; set; }

    }
}

