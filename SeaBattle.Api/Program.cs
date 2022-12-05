using SeaBattle.Api.Controllers;
using SeaBattle.Application.Services;
using SeaBattle.Application.Services.Intefaces;
using SeaBattle.Application.Services.Interfaces;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISessionRepository, SessionRepository>();
builder.Services.AddSingleton<IPlayerService, PlayerService>();
builder.Services.AddSingleton<IPlayerRepository, PlayerRepository>();
builder.Services.AddSingleton<ISessionService, SessionService>();
builder.Services.AddSingleton<ISeaBattleGameRepository, SeaBattleGameRepositoty>();
builder.Services.AddSingleton<ISeaBattleGameService, SeaBattleGameService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
