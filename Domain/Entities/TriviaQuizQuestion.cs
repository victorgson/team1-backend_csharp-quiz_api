using System.Text.Json.Serialization;

namespace Quiz.Domain.Entities;

public class TriviaQuizQuestion
{
    [JsonPropertyName("question")]
    public string QuestionString { get; set; }
    public string language = "English";
    public string category { get; set; }

    public string correctAnswer { get; set; }
    public List<string> incorrectAnswers { get; set; }

}
