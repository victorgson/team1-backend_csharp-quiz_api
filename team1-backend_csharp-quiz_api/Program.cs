
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
using team1_backend_csharp_quiz_api.Configurations;
using team1_backend_csharp_quiz_api.Services;
using team1_backend_csharp_quiz_api.Swagger;


internal class Program
{
    private static void Main(string[] args)
    {

      
        var builder = WebApplication.CreateBuilder(args);
        var config = builder.Configuration;

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDependencies(config);

        builder.Services.AddContextUsingSQLLite();

        builder.Services.AddSwaggerConfigurations();
        builder.Services.AddResponseCompression();
        builder.Services.AddAutoMapper(typeof(MapperConfig));

        RunWebApplication(builder);

        static void RunWebApplication(WebApplicationBuilder builder)
        {
            var app = builder.Build();
            app.UseResponseCompression();
            app.UseSwaggerConfigurations();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.MapControllers();
            app.Run();
        };

    }
}


