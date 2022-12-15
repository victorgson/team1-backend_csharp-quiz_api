
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using team1_backend_csharp_quiz_api.Persistance;
using team1_backend_csharp_quiz_api.Contracts;
using team1_backend_csharp_quiz_api.Repository;


internal class Program
{
    private static void Main(string[] args)
    {

      
        var builder = WebApplication.CreateBuilder(args);

        AddQuizDatabaseContext(builder);
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<ITriviaQuizRepository, TriviaQuizRepository>();
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped<IQuestionsRepository, QuestionsRepository>();
        builder.Services.AddScoped<IAnswersRepository, AnswersRepository>();


        //// Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //}

        var config = builder.Configuration;

        ConfigureSwagger(builder.Services);

        builder.Services.AddResponseCompression();
        var app = builder.Build();
        app = ConfigureAppBuilder(app);
        app.Run();

        IServiceCollection ConfigureSwagger(IServiceCollection service)
        {
            service.AddEndpointsApiExplorer();

            service.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });
            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Title = "Quiz - V1",
                            Version = "v1",
                            Description = "V1 of the quiz app",
                            TermsOfService = new Uri("http://toSomewhere.com"),
                            Contact = new OpenApiContact
                            {
                                Name = "Please don't contact me",
                                Email = "Nope@tempuri.org"
                            },
                            License = new OpenApiLicense
                            {
                                Name = "Apache 2.0",
                                Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
                            }
                        });
                options.SwaggerDoc("v2", new OpenApiInfo { Title = "Quiz V2", Description = "Here we go v2 of the api now even better!!!", Version = "v2" });

                //xml comments
                //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            return service;
        }

        WebApplication ConfigureAppBuilder(WebApplication app)
        {
            app.UseResponseCompression();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

                app.UseSwagger(c =>
                {
                    //c.RouteTemplate = "api-docs/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(options =>
                {
                    options.RoutePrefix = "swagger";
                    options.SwaggerEndpoint("v1/swagger.json", "V1");
                    options.SwaggerEndpoint("v2/swagger.json", "V2");

                    //custom css and html
                    //options.InjectStylesheet("/swagger-ui/custom.css");
                    //options.IndexStream = () => GetType().Assembly
                    //    .GetManifestResourceStream("ITHS.Webapi.Swagger.index.html");

                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.MapControllers();

            return app;
        }


        // Lägg till DB context

        static void AddQuizDatabaseContext(WebApplicationBuilder builder)
        {


            //var ConnectionString = builder.Configuration.GetConnectionString("ITHSDatabase");
            //if (ConnectionString == null)
            //    Console.WriteLine("no connectionString");
            //else Console.WriteLine(ConnectionString);

            builder.Services​
            .AddDbContext<QuizDatabaseContext>(options =>
            options.
            UseSqlite("Data Source=quiz.db"),

                    ServiceLifetime.Scoped
                );

        }
    }
}


