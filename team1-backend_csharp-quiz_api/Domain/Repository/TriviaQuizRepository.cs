using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.Entities;
using System.Text.Json;

namespace team1_backend_csharp_quiz_api.Repository { 

    public class TriviaQuizRepository : ITriviaQuizRepository
    {
        public async Task<TriviaQuizQuestion> GetTriviaQuestion()
        {
            try
            {
                var uri = $"https://the-trivia-api.com/api/questions?limit=1";

                using var client = new HttpClient();

                var response = await client.GetAsync(uri);

                var stream = await response.Content.ReadAsStreamAsync();

                var triviaQuestion = await JsonSerializer.DeserializeAsync<List<TriviaQuizQuestion>>(stream);

                return triviaQuestion[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
