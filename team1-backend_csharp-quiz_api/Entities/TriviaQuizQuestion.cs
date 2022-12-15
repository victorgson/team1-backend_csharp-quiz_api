using System.Text.Json.Serialization;

namespace team1_backend_csharp_quiz_api.Entities;

public class TriviaQuizQuestion
{
    [JsonPropertyName("question")]
    public string question { get; set; }
    [JsonPropertyName("correctAnswer")]
    public string correctAnswer { get; set; }
    [JsonPropertyName("incorrectAnswers")]
    public List<string> incorrectAnswers { get; set; }
    [JsonPropertyName("id")]
    public string triviaId { get; set; }
}
