using System;
using Quiz.Domain.Entities;

namespace Quiz.Domain.Contracts
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

