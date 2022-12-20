using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace team1_backend_csharp_quiz_api.Swagger;

public static class SwaggerConfigExtension
{
    static string PathToXMLComments => Path.Combine(AppContext.BaseDirectory, XmlFileNameFromExecutedAssembly);

    static string XmlFileNameFromExecutedAssembly => $"{Assembly.GetEntryAssembly().GetName().Name}.xml";

    public static IServiceCollection AddSwaggerConfigurations(this IServiceCollection service)
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
            options.SwaggerDoc("v1", V1);
            options.SwaggerDoc("v2", V2);

            //Fixa varför den inte hittar XML
            //options.IncludeXmlComments(PathToXMLComments);

        });

        return service;
    }

    public static WebApplication UseSwaggerConfigurations(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = "swagger";
            options.SwaggerEndpoint("v1/swagger.json", "Quiz Game");
            options.SwaggerEndpoint("v2/swagger.json", "CRUD for Quiz");

        });
        return app;
    }

    static OpenApiInfo V1 => new OpenApiInfo {
        Title = "Quiz",
        Version = "v1",
        Description = "Get random questions from TriviaApi or add your own questions from V2.",
    };

    static OpenApiInfo V2 => new OpenApiInfo
    {
        Title = "CRUD",
        Description = "Crud implementation for Quiz API.",
        Version = "v2"
    };

}

