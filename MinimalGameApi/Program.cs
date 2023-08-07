
using Microsoft.AspNetCore.Mvc;
using MinimalGameApi.Interface;
using MinimalGameApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddSingleton<GameList>();

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
    var games = gameService.GetAllGames();
    return games;
});

app.MapGet("/game/{id}", (int id, [FromServices] IGameService gameService) =>
{
    var game = gameService.GetGameById(id);
    if (game is null)
        return Results.NotFound("Desculpe, esse jogo não consta em nosso sistema :( ");

    return Results.Ok(game);
});

app.MapGet("/game/search", ([FromQuery] string title, [FromServices] IGameService gameService) =>
{
    var filteredGames = gameService.GetGamesByTitle(title);

    if (filteredGames.Count() == 0)
        return Results.NotFound($"Desculpe, o jogo com titulo '{title}' não consta em nosso sistema :( ");

    return Results.Ok(filteredGames);
});

app.MapPost("/game", (Game addedGame, [FromServices] IGameService gameService) =>
{
    gameService.AddGame(addedGame);
    return Results.Created($"/game/{addedGame.Id}", addedGame);
});

app.MapPut("/game/{id}", (Game updateGame, int id, [FromServices] IGameService gameService) =>
{
    updateGame.Id = id;
    gameService.UpdateGame(updateGame);

    return Results.Ok(updateGame);
});

app.MapPatch("/game/{id}", (int id, [FromBody] UpdateFieldRequest updateField, [FromServices] IGameService gameService) =>
{
    var updateGame = gameService.UpdateField(id, updateField);
    if (updateGame is null)
    {
        return Results.NotFound("Desculpe, esse jogo não consta em nosso sistema :( ");
    }

    return Results.Ok(updateGame);
});


app.MapDelete("/game/{id}", (int id, [FromServices] IGameService gameService) =>
{
    var gameToDelete = gameService.GetGameById(id);
    if (gameToDelete is null)
    {
        return Results.NotFound("Desculpe, esse jogo não consta em nosso sistema :( ");
    }

    gameService.DeleteGame(id);
    return Results.NoContent();
});

app.Run();
