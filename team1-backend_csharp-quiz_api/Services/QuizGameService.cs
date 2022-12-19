using System;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.Entities;

namespace team1_backend_csharp_quiz_api.Services
{

    public interface IQuizGameService
    {
        Task<QuizGameQuestion> getQuestion();
        Task<string> checkAnswer(Guid id, string answer);

    }

    public class QuizGameService : IQuizGameService
	{
        private readonly ITriviaService _triviaService;
        private readonly IAnswersRepository _answersRepository;

        public QuizGameService(ITriviaService triviaService,IAnswersRepository answersRepository)
		{
            _triviaService = triviaService;
            _answersRepository = answersRepository;
		}

        public async Task<QuizGameQuestion> getQuestion()
        {
            var question = await _triviaService.GetRandomQuestion();
            var answers = await _answersRepository.GetAllAsync();
            var filteredAnswers = answers.FindAll(q => question.Id == q.QuestionId);


            Random rng = new Random();
            var shuffledListOfAnswers = filteredAnswers.OrderBy(a => rng.Next()).ToList();

            QuizGameQuestion quizGameQuestion = new QuizGameQuestion();
            quizGameQuestion.Id = question.Id;
            quizGameQuestion.QuestionString = question.QuestionString;
            

            foreach (var item in shuffledListOfAnswers)
            {
                quizGameQuestion.Answers.Add(item.AnswerString);
            }

            return quizGameQuestion;

        }

        public async Task<string> checkAnswer(Guid id, string answer)
        {
            var answers = await _answersRepository.GetAllAsync();
            var filteredAnswers = answers.Find(q => answer == q.AnswerString);


            if(filteredAnswers is null)
            {
                return "Answer does not exist";
            }

            if(filteredAnswers.isCorrectAnswer)
            {
                return filteredAnswers.AnswerString + " is correct";
            } else
            {
                return filteredAnswers.AnswerString + " is not correct!"; 
            }

        }
    }
}

