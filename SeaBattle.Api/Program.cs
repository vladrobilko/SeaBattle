using Microsoft.EntityFrameworkCore;
using SeaBattle.Api.Controllers;
using SeaBattle.Application.Services;
using SeaBattle.Application.Services.Intefaces;
using SeaBattle.Application.Services.Interfaces;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.DataManagement.Models;
using SeaBattle.DataManagement.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ISeaBattleGameService, SeaBattleGameService>();
builder.Services.AddScoped<ISeaBattleGameRepository, SeaBattleGameRepositoty>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SeabattleContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("SeabattleContext")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
