﻿using team1_backend_csharp_quiz_api.Entities;

namespace team1_backend_csharp_quiz_api.Contracts;

public interface ITriviaQuizRepository
{
    Task<TriviaQuizQuestion> GetTriviaQuestion();
}
