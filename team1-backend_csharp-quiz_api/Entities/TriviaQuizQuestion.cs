using System.Text.Json.Serialization;

namespace team1_backend_csharp_quiz_api.Entities;

public class TriviaQuizQuestion
{
    [JsonPropertyName("question")]
    public string QuestionString { get; set; }
    public string language = "English";
    public string category { get; set; }
}
