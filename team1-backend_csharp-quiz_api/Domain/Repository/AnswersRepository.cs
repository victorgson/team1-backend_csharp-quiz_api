using System;
using Microsoft.EntityFrameworkCore;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.Entities;
using team1_backend_csharp_quiz_api.Persistance;

namespace team1_backend_csharp_quiz_api.Repository
{
    public class AnswersRepository : GenericRepository<Answer>, IAnswersRepository
    {
        private readonly QuizDatabaseContext _context;
        public AnswersRepository(QuizDatabaseContext context) : base(context)
        {
            _context = context;
        }

    }
}

