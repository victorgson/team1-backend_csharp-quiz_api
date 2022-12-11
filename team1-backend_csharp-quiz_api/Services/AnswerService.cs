using System;
using team1_backend_csharp_quiz_api.Entities;
using team1_backend_csharp_quiz_api.Persistance;

namespace team1_backend_csharp_quiz_api.Services
{
    public class AnswerService
    {
        public AnswerService()
        {
        }

        public void AddAnswer(Answer answer)
        {
            using (var context = new QuizDatabaseContext())
            {
                context.Answers.Add(answer);
                context.SaveChanges();
            }
        }

        public Answer GetAnswerBy(Guid id)
        {
            using (var context = new QuizDatabaseContext())
            {
                var answer = context.Answers.Where(q => q.Id == id).First();
                context.SaveChanges();
                return answer;

            }
        }

        public Answer DeleteAnswer(Guid id)
        {
            using (var context = new QuizDatabaseContext())
            {
                var answer = context.Answers.Where(q => q.Id == id).First();
                context.Answers.Remove(answer);
                context.SaveChanges();
                return answer;
            }
        }

        public Answer UpdateAnswer(Guid id, Answer answer)
        {
            using (var context = new QuizDatabaseContext())
            {
                var answerToUpdate = context.Answers.Where(q => q.Id == answer.Id).First();
                context.Answers.Update(answer);
                context.SaveChanges();
                return answerToUpdate;
            }
        }
    }
}

