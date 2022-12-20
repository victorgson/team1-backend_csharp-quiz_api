using System;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.Repository;
using team1_backend_csharp_quiz_api.Services;

namespace team1_backend_csharp_quiz_api.Configurations
{
    public static class ConfigureDependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration config)
        {

            return services
                .AddScoped<ITriviaQuizRepository, TriviaQuizRepository>()
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<IQuestionsRepository, QuestionsRepository>()
                .AddScoped<IAnswersRepository, AnswersRepository>()
                .AddScoped<ITriviaService, TriviaService>()
                .AddScoped<IQuestionService, QuestionService>()
                .AddScoped<IAnswerService, AnswerService>();
        }
    }
}

