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
using team1_backend_csharp_quiz_api.Repository;
using AutoMapper;
using team1_backend_csharp_quiz_api.DTO;
using team1_backend_csharp_quiz_api.DTO.Question;
using team1_backend_csharp_quiz_api.Services;

namespace team1_backend_csharp_quiz_api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]

    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITriviaService _service;

        public QuestionsController(IQuestionsRepository repository, IMapper mapper, ITriviaService service)
        {
            this._service = service;
            _repository = repository;
            this._mapper = mapper;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetQuestionDto>>> GetQuestions()
        {

            var questions = await _repository.GetAllAsync();
            var records = _mapper.Map<List<GetQuestionDto>>(questions);

            return Ok(records);
        }

        //GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(Guid id)
        {


            var question = await _repository.GetAsync(id);


            if (question is null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // GET: api/Questions/
        [HttpGet]
        [Route("/api/v1/Questions/Random")]
        public async Task<ActionResult<Question>> GetRandomQuestion()
        {
            var question = await _service.GetRandomQuestion();

            if (question is null)
            {
                return NotFound();
            }
            return Ok(question);
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

            var question = await _repository.GetAsync(id);

            if (question is null)
            {
                return NotFound(); 
            }
            _mapper.Map(questionDto, question);
            try
            {
                await _repository.UpdateAsync(question);
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

            var question = _mapper.Map<Question>(createQuestionDto);
            await _repository.AddSync(question);

            return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {

            var question = await _repository.GetAsync(id);
            if (question is null)
            {
                return NotFound(); 
            }

            await _repository.DeleteAsync(id);


            return NoContent(); 


        }

        private async Task<bool> QuestionExists(Guid id)
        {
            return await _repository.Exists(id);
        }
    }
}