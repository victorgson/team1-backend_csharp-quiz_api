using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using team1_backend_csharp_quiz_api.DTO.Answer;
using team1_backend_csharp_quiz_api.Entities;
using team1_backend_csharp_quiz_api.Persistance;
using AutoMapper;
using team1_backend_csharp_quiz_api.Repository;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.DTO.Question;
using team1_backend_csharp_quiz_api.Services;
using team1_backend_csharp_quiz_api.DTO;

namespace team1_backend_csharp_quiz_api.Controllers.V2
{
    [Route("api/v2/[controller]")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _answerService;


        public AnswersController(IMapper mapper, IAnswersRepository repository, IAnswerService answerService)
        {
            _answerService = answerService;
        }

        // GET: api/Answers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers() => Ok(await _answerService.GetAnswersList());

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetAnswer(Guid id)
        {
            var answer = await _answerService.GetAnswer(id);

            return (answer != null ? Ok(answer) : NotFound());
        }

        // PUT: api/Answers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer(Guid id, UpdateAnswerDto answerDto)
        {
            if (id != answerDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _answerService.UpdateAnswer(id, answerDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AnswerExists(id))
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

        // POST: api/Answers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Answer>> PostAnswer(CreateAnswerDto createAnswerDto)
        {
            var answer = await _answerService.AddAnswer(createAnswerDto);

            return CreatedAtAction("GetAnswer", new { id = answer.Id }, answer);
        }

        // DELETE: api/Answers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(Guid id)
        {
            var success = await _answerService.RemoveAnswer(id);

            return (success ? NoContent() : BadRequest("Answer ID was not found."));
        }

        private async Task<bool> AnswerExists(Guid id)
        {
            return await _answerService.AnswerExists(id);
        }
    }
}
