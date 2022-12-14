using System.Text.Json.Serialization;

namespace team1_backend_csharp_quiz_api.Entities;

public class TriviaQuizQuestion
{
    //[JsonPropertyName("triviaQuestion")]
    public string question { get; set; }
    public string correctAnswer { get; set; }
    public List<string> incorrectAnswers { get; set; }
    public string id { get; set; }
}
