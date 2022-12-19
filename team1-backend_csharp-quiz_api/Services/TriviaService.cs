using System;
using AutoMapper;
using NuGet.Protocol.Core.Types;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.DTO;
using team1_backend_csharp_quiz_api.DTO.Question;
using team1_backend_csharp_quiz_api.Entities;

namespace team1_backend_csharp_quiz_api.Services
{

    public interface ITriviaService
    {
        Task<Question> GetRandomQuestion();
        Task<bool> checkIfTriviaQuestionExistsInDb(Guid id);
        void saveTriviaQuestion(Question question);
        void saveCorrectTriviaAnswers(TriviaQuizQuestion question, Guid questionId);
        void saveIncorrectTriviaAnswers(string incorrectAnswer, Guid questionId);
    }

	public class TriviaService : ITriviaService
	{

        private readonly IAnswersRepository _answerRepository;
        private readonly ITriviaQuizRepository _triviaRepository;
        private readonly IQuestionsRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;

        public TriviaService(IAnswersRepository answerRepository, ITriviaQuizRepository triviaRepository, IQuestionsRepository questionsRepository, IMapper mapper, IQuestionService _questionService)
		{
            this._mapper = mapper;
            this._questionService = _questionService;
            this._answerRepository = answerRepository;
            this._triviaRepository = triviaRepository;
            this._questionRepository = questionsRepository;

        }

        public async Task<Question> GetRandomQuestion()
        {
            Random r = new Random();
            // Vet inte varför 0, 1 inte funkar, så kör på detta
            var value = r.Next(0, 10);

            if (value >= 5)
            {
                return await _questionService.RandomQuestionFromList();
            }
            else
            {

                var question = await _triviaRepository.GetTriviaQuestion();
                var record = _mapper.Map<Question>(question);

                if(!await checkIfTriviaQuestionExistsInDb(record.Id))
                {
                    saveTriviaQuestion(record);
                    saveCorrectTriviaAnswers(question, record.Id);

                    foreach (var item in question.incorrectAnswers)
                    {
                        saveIncorrectTriviaAnswers(item, record.Id);
                    }
                }

                return record;
            }
        }

        public void saveTriviaQuestion(Question question)
        {
            _questionRepository.AddSync(question);
            
        }

        public async Task<bool> checkIfTriviaQuestionExistsInDb(Guid id)
        {
           
            return await _questionRepository.Exists(id);

        }

        public async void saveCorrectTriviaAnswers(TriviaQuizQuestion question, Guid questionId)
        {
            Answer answer = new Answer();
            answer.AnswerString = question.correctAnswer;
            answer.isCorrectAnswer = true;
            answer.QuestionId = questionId;
            await _answerRepository.AddSync(answer);

        }

        public async void saveIncorrectTriviaAnswers(String incorrectAnswer, Guid questionId)
        {
            Answer answer = new Answer();
            answer.AnswerString = incorrectAnswer;
            answer.isCorrectAnswer = false;
            answer.QuestionId = questionId;
            await _answerRepository.AddSync(answer);
        }
    }
}

