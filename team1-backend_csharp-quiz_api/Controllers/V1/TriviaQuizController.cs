using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.Services;
using System.Text;
using team1_backend_csharp_quiz_api.Entities;

namespace team1_backend_csharp_quiz_api.V1;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
public class TriviaQuizController : ControllerBase
{
    private readonly ITriviaService _triviaService;


    public TriviaQuizController(ITriviaService triviaService)
    {
        _triviaService = triviaService;

    }

    /// <summary>
    /// Gets a random question from Database or TriviaQuiz, 50/50
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<QuizGameQuestion>> GetQuestion()
    {
        var quizQuestion = await _triviaService.getQuestion();

        return Ok(quizQuestion);
    }

    /// <summary>
    /// Checks if the answer is correct. Enter ID of question and your desired answer.
    /// </summary>
    /// <param name="id"> ID of the question to answer.</param>
    /// <param name="answer"> The answer in text. Needs to be exact.</param>
    [HttpPost("{id}-{answer}")]
    public async Task<ActionResult<string>> PostAnswer(Guid id, string answer)
    {

        var quizQuestion = _triviaService.checkAnswer(id, answer).Result;

        return Ok(quizQuestion);
    }

}
