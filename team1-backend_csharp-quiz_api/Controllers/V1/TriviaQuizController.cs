using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.Services;

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

    [HttpGet]
    public async Task<IActionResult> GetQuestion()
    {
        var quizQuestion = await _triviaService.getQuestion();

        return Ok(quizQuestion);
    }

    [HttpGet("{id}, {answer}")]
    public async Task<IActionResult> GetAnswer(Guid id, string answer)
    {
        var quizQuestion = _triviaService.checkAnswer(id, answer).Result;

        return Ok(quizQuestion);
    }

}
