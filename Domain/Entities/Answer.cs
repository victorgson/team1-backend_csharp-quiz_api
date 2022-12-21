using System.ComponentModel.DataAnnotations.Schema;
namespace Quiz.Domain.Entities;

public class Answer
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string AnswerString { get; set; }
    public bool isCorrectAnswer { get; set; }

    public Answer()
    {
        Id = Guid.NewGuid(); 
    }

}

