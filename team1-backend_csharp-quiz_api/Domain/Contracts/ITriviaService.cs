using System;
using team1_backend_csharp_quiz_api.Entities;

namespace team1_backend_csharp_quiz_api.Contracts
{
    public interface ITriviaService
    {
        Task<Question> GetRandomQuestion();
        Task<bool> checkIfTriviaQuestionExistsInDb(Guid id);
        void saveTriviaQuestion(Question question);
        void saveCorrectTriviaAnswers(TriviaQuizQuestion question, Guid questionId);
        void saveIncorrectTriviaAnswers(string incorrectAnswer, Guid questionId);
        Task<QuizGameQuestion> getQuestion();
        Task<string> checkAnswer(Guid id, string answer);
    }
}

