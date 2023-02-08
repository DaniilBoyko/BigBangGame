using System.Reflection;
using BigBangGame.Server.Services;
using BigBangGame.Server.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BigBangGame.Server;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Services.AddFluentValidationAutoValidation();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<IChoiceStorage, ChoiceStorage>();
        builder.Services.AddSingleton<IPlayService, PlayService>();
        builder.Services.AddSingleton<IScoreboardService, ScoreboardService>();
        builder.Services.AddSingleton<IChoiceSelector, ChoiceSelector>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
