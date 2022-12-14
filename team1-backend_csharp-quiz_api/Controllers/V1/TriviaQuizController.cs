using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using team1_backend_csharp_quiz_api.Domain;

namespace team1_backend_csharp_quiz_api.V1;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
public class TriviaQuizController : ControllerBase
{
    private readonly ITriviaQuizRepository _triviaQuizRepository;

    public TriviaQuizController(ITriviaQuizRepository triviaQuizRepository)
    {
        _triviaQuizRepository = triviaQuizRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var quizQuestion = await _triviaQuizRepository.GetTriviaQuestion();

        return Ok(quizQuestion);
    }

}
