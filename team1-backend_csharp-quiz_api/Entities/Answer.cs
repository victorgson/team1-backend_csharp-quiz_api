using System.ComponentModel.DataAnnotations.Schema;
namespace team1_backend_csharp_quiz_api.Entities
{
    public class Answer
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(QuestionId))]
        public Guid QuestionId { get; set; }
        public string AnswerString { get; set; }
        public bool isCorrectAnswer { get; set; }

        public Answer()
        {
            Id = Guid.NewGuid(); 
        }

    }
}

