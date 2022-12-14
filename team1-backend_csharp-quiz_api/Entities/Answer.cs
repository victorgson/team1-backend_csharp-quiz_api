using System.ComponentModel.DataAnnotations;
namespace team1_backend_csharp_quiz_api.Entities
{
    public class Answer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid QuestionId { get; set; }
        public string AnswerString { get; set; }
        public bool isCorrectAnswer { get; set; }

    }
}

