using System;
namespace Quiz.Domain.Entities
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

