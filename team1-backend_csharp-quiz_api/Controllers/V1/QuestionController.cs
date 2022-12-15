using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using team1_backend_csharp_quiz_api.Entities;
using team1_backend_csharp_quiz_api.Persistance;
using team1_backend_csharp_quiz_api.Services;
using team1_backend_csharp_quiz_api.Repository;

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
            // Do random, 0 - 10

            Random r = new Random();
            var number = r.Next(0, 10);
       
            if(number >= 5)
            {
                var questionService = new QuestionService();
                return questionService.GetRandomQuestion();
                // Get question from DB or 
            } else
            {
                var triviaRepository = new TriviaQuizRepository();
                TriviaQuizQuestion triviaQuestion = triviaRepository.GetTriviaQuestion().Result;
                Question question = new Question();
                question.QuestionString = triviaQuestion.question;
                question.triviaId = triviaQuestion.triviaId;
                question.Language = "en";
                question.Category = "N/A";

                Answer answer = new Answer();

                answer.AnswerString = triviaQuestion.correctAnswer;
                answer.QuestionId = question.Id;
                answer.isCorrectAnswer = true;
   
                var questionService = new QuestionService();
                var answerService = new AnswerService();


                // check if question exists
                if(questionService.checkIfTriviaQuestionExists(triviaQuestion.triviaId))
                {
                    // get question by triviaId if exists
                    return questionService.getTriviaQuestionIfExists(triviaQuestion.triviaId);
                } else
                {
                    // Save question if not exists
                    questionService.AddQuestion(question);
                    answerService.AddAnswer(answer);

                    // Saves all incorrect answers
                    foreach (var i in triviaQuestion.incorrectAnswers)
                    {
                        var wrongAnswer = new Answer();
                        wrongAnswer.AnswerString = i;
                        wrongAnswer.isCorrectAnswer = false;
                        wrongAnswer.QuestionId = question.Id;
                        answerService.AddAnswer(wrongAnswer);
                    }
                }
                return question;

            }

            // Check if question exists in DB
  


          
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

