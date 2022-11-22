using SeaBattle.Application.Services;
using SeaBattle.Application.Services.Intefaces;
using SeaBattle.infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IPlayerModelService, PlayerModelService>();
//builder.Services.AddSingleton<IPlayerDtoRepository, PlayerDtoRepository>();

//builder.Services.AddSingleton<INewSessionModelService, NewSessionModelService>();
//builder.Services.AddSingleton<ISessionRepository, SessionRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
