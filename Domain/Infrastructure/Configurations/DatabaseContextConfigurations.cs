using System;
using Microsoft.EntityFrameworkCore;
using team1_backend_csharp_quiz_api.Persistance;

namespace Quiz.Infrastructure.Configurations
{
	public static class DatabaseContextConfigurations
	{
        public static IServiceCollection AddContextUsingSQLLite(this IServiceCollection services, string fileName = "quiz.db")
        {
            return services
                .AddDbContext<QuizDatabaseContext>(options =>
                    options.UseSqlite($"Data Source={fileName}"),
                    ServiceLifetime.Scoped
            );
        }
    }
}

