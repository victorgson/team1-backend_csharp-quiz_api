using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using team1_backend_csharp_quiz_api.Entities;
using team1_backend_csharp_quiz_api.Persistance;
using team1_backend_csharp_quiz_api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace team1_backend_csharp_quiz_api.Controllers.V1
{

    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

       
        // GET: api/values
        [HttpGet]
        public Question GetRandomQuestion()
        {
            var questionService = new QuestionService();
            return questionService.GetRandomQuestion();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Question GetQuestionBy(Guid id)
        {
            var questionService = new QuestionService();
            return questionService.GetQuestionBy(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Question question)
        {
            var questionService = new QuestionService();
            questionService.AddQuestion(question);  
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Question question)
        {
            var questionService = new QuestionService();
            questionService.UpdateQuestion(id, question);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}

