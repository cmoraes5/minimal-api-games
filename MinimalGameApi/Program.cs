
using Microsoft.AspNetCore.Mvc;
using MinimalGameApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddScoped<IGameService, GameService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.MapGet("/game", ([FromServices] IGameService gameService) =>
{
    return gameService.GetAllGames();
});

app.MapGet("/game/{id}", (int id, [FromServices] IGameService gameService) =>
{
    var game = gameService.GetGameById(id);
    if (gameService is null)
        return Results.NotFound("Desculpe, esse jogo não consta em nosso sistema :( ");

    return Results.Ok(game);
});

app.MapGet("/game/{title}", (string title, [FromServices] IGameService gameService) =>
{
    var game = gameService.GetGamesByTitle(title);
    if (game is null)
        return Results.NotFound("Desculpe, esse jogo não consta em nosso sistema :( ");

    return Results.Ok(game);
});

app.MapPost("/game", (Game game, [FromServices] IGameService gameService) =>
{
    gameService.AddGame(game);
    return gameService.GetAllGames();
});

app.MapPut("/game/{id}", (Game updateGame, int id, [FromServices] IGameService gameService) =>
{
    var game = gameService.GetGameById(id);
    if (game is null)
        return Results.NotFound("Desculpe, esse jogo não consta em nosso sistema :( ");

    game.Titulo = updateGame.Titulo;
    game.Descricao = updateGame.Descricao;
    game.Modo = updateGame.Modo;
    game.Desenvolvedores = updateGame.Desenvolvedores;

    return Results.Ok(gameService.GetAllGames());
});

app.MapDelete("/game/{id}", (int id, [FromServices] IGameService gameService) =>
{
    var game = gameService.GetGameById(id);
    if (game is null)
        return Results.NotFound("Desculpe, esse jogo não consta em nosso sistema :( ");

    return Results.Ok(gameService.GetAllGames());
});

app.Run();
