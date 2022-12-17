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

namespace team1_backend_csharp_quiz_api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
     
        private readonly IMapper _mapper;
        private readonly IAnswersRepository _repository;

        public AnswersController(IMapper mapper, IAnswersRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        // GET: api/Answers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers()
        {

            var answers = await _repository.GetAllAsync();
            var records = _mapper.Map<List<GetAnswerDto>>(answers);

            return Ok(records);
        }

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetAnswer(Guid id)
        {
            var answer = await _repository.GetAsync(id);

            if (answer is null)
            {
                return NotFound();
            }

            return Ok(answer);
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

            var question = await _repository.GetAsync(id);

            if (question is null)
            {
                return NotFound();
            }
            _mapper.Map(answerDto, question);
            try
            {
                await _repository.UpdateAsync(question);
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
            var answer = _mapper.Map<Answer>(createAnswerDto);
            await _repository.AddSync(answer);

            return CreatedAtAction("GetAnswer", new { id = answer.Id }, answer);
        }

        // DELETE: api/Answers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(Guid id)
        {
            var answer = await _repository.GetAsync(id);
            if (answer is null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);


            return NoContent();
        }

        private async Task<bool> AnswerExists(Guid id)
        {
            return await _repository.Exists(id);
        }
    }
}
