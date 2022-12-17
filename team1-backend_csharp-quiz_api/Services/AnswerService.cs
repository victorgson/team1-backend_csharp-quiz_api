using System;
using team1_backend_csharp_quiz_api.Contracts;


namespace team1_backend_csharp_quiz_api.Services
{
    public class AnswerService
    {

        private readonly IAnswersRepository _repository;

        public AnswerService(IAnswersRepository repository)
        {
            _repository = repository;
        }
    }
}

