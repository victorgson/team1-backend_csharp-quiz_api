using System;
namespace team1_backend_csharp_quiz_api.Entities
{
	public class QuizGameQuestion
	{
        public Guid Id { get; set; }
        public string QuestionString { get; set; }
        public List<string> Answers { get; set; }

        public QuizGameQuestion()
        {
            Answers = new List<string>();
        }
    }

   
}

