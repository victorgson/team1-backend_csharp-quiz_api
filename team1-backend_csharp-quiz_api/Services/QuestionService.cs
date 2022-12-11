using System;
using team1_backend_csharp_quiz_api.Entities;
using team1_backend_csharp_quiz_api.Persistance;

namespace team1_backend_csharp_quiz_api.Services
{
	public class QuestionService
	{
		public QuestionService()
		{
		}

		public void AddQuestion(Question question)
		{
			using (var context = new QuizDatabaseContext())
			{
				context.Questions.Add(question);
				context.SaveChanges();
			}
		}

		public Question GetRandomQuestion()
		{
			using (var context = new QuizDatabaseContext())
			{

				//Fixa till random
				var question = context.Questions.FirstOrDefault();
                context.SaveChanges();
                return question;

            }
		}

        public Question GetQuestionBy(Guid id)
        {
            using (var context = new QuizDatabaseContext())
            {
				var question = context.Questions.Where(q => q.Id == id).First();
                context.SaveChanges();
                return question;

            }
        }

        public Question DeleteQuestion(Guid id)
        {
            using (var context = new QuizDatabaseContext())
            {
                var question = context.Questions.Where(q => q.Id == id).First();
				context.Questions.Remove(question);
                context.SaveChanges();
                return question;
            }
        }

        public Question UpdateQuestion(Guid id, Question question)
        {
            using (var context = new QuizDatabaseContext())
            {
                var questionToUpdate = context.Questions.Where(q => q.Id == question.Id).First();
                context.Questions.Update(question);
                context.SaveChanges();
                return question;
            }
        }
    }
}

