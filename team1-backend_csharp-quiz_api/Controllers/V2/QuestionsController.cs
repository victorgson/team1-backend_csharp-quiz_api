using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.Entities;
using team1_backend_csharp_quiz_api.Persistance;
using team1_backend_csharp_quiz_api.DTO;
using team1_backend_csharp_quiz_api.DTO.Question;
using team1_backend_csharp_quiz_api.Services;

namespace team1_backend_csharp_quiz_api.Controllers.V1
{
    [Route("api/v2/[controller]")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]

    public class QuestionsController : ControllerBase
    {
 
        private readonly ITriviaService _triviaService;
        private readonly IQuestionService _questionService;

        public QuestionsController(ITriviaService triviaService, IQuestionService questionService)
        {
            this._triviaService = triviaService;
            this._questionService = questionService;

        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetQuestionDto>>> GetQuestions() => Ok(await _questionService.GetQuestionsList());

        //GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetQuestionDto>> GetQuestion(Guid id)
        {

            var question = await _questionService.GetQuestion(id);

            return (question != null ? Ok(question) : NotFound());

        }

        // GET: api/Questions/
        [HttpGet]
        [Route("/api/v1/Questions/Random")]
        public async Task<ActionResult<Question>> GetRandomQuestion()
        {
            var question = await _triviaService.GetRandomQuestion();

            return (question is null ? NotFound() : Ok(question));

        }

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(Guid id, UpdateQuestionDto questionDto)
        {
            if (id != questionDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _questionService.UpdateQuestion(id, questionDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(CreateQuestionDto createQuestionDto)
        {

            var question = await _questionService.AddQuestion(createQuestionDto);

            return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {

            var success = await _questionService.RemoveQuestion(id);

            return (success ? NoContent() : BadRequest("Question ID was not found."));


        }

        private async Task<bool> QuestionExists(Guid id)
        {
            return await _questionService.QuestionExists(id);

        }
    }
}