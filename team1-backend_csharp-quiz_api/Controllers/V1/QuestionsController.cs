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

namespace team1_backend_csharp_quiz_api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]

    // Behöver en GetRandomQuestion-Metod? Eller kanske bör vara i ett repo, som hanterar både egen databas och trivia? 
    public class QuestionsController : ControllerBase
    {
        private readonly QuizDatabaseContext _context;
        private readonly IQuestionsRepository _repository;

        public QuestionsController(QuizDatabaseContext context, IQuestionsRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {

            var questions = await _repository.GetAllAsync();

            return Ok(questions);
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(Guid id)
        {


            var question = await _repository.GetAsync(id);

            if (question is null)
            {
                return NotFound(); 
            }

            return Ok(question);

            // Gamla sättet... 

          //if (_context.Questions == null)
          //{
          //    return NotFound();
          //}
          //  var question = await _context.Questions.FindAsync(id);

                //  if (question == null)
                //  {
                //      return NotFound();
                //  }

                //  return question;
        }

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(Guid id, Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            var questionToEdit = await _repository.GetAsync(id);

            if (questionToEdit is null)
            {
                return NotFound(); 
            }

            try
            {
                await _repository.UpdateAsync(questionToEdit);
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
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {

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
