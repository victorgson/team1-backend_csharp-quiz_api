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
    public class AnswerController : ControllerBase
    {


        // GET: api/values
        [HttpGet("{id}")]
        public Answer GetAnswer(Guid id)
        {
            var answerService = new AnswerService();
            return answerService.GetAnswerBy(id);
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody] Answer answer)
        {
            var answerService = new AnswerService();
            answerService.AddAnswer(answer);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(Guid id, [FromBody] Question question)
        //{
        //    var questionService = new QuestionService();
        //    questionService.UpdateQuestion(id, question);
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(Guid id)
        //{
        //}
    }
}

