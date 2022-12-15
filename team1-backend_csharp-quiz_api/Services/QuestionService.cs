﻿using System;
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

       
                Random r = new Random();

                    var tableToList = context.Questions.ToList();
                    var question = tableToList.ElementAt(r.Next(0, tableToList.Count()));
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

        public bool checkIfTriviaQuestionExists(String id)
        {
            using (var context = new QuizDatabaseContext())
            {
                if (context.Questions.Where(q => q.triviaId == id).Count() == 0) {
                    return false;
                }
                return true;

            }
        }

        public Question getTriviaQuestionIfExists(String id)
        {
            using (var context = new QuizDatabaseContext())
            {
                var question = context.Questions.Where(q => q.triviaId == id).First();
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

