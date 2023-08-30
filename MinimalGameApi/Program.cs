
using Microsoft.AspNetCore.Mvc;
using MinimalGameApi;
using MinimalGameApi.Exceptions;
using MinimalGameApi.Interface;
using MinimalGameApi.Middlewares;
using MinimalGameApi.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));
// app.UseHttpsRedirection();

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

app.MapGet("/game/{id}", (Guid id, [FromServices] IGameService gameService) =>
{
    var game = gameService.GetGameById(id);

    if (game is null)
    {
        throw new NotFoundException("Jogo nao encontrado");
    }

    return Results.Ok(game);
});

//app.MapGet("/game/search", ([FromQuery] string title, [FromServices] IGameService gameService) =>
//{
//    var filteredGames = gameService.GetGamesByTitle(title);

//    if (filteredGames.Count() == 0)
//        return Results.NotFound($"Desculpe, o jogo com titulo '{title}' não consta em nosso sistema :( ");

//    return Results.Ok(filteredGames);
//});

app.MapPost("/game", (GameDTO addedGame, [FromServices] IGameService gameService) =>
{
    var validator = new GameDTOValidator();
    var validationResult = validator.Validate(addedGame);

    if (!validationResult.IsValid)
    {
        var errorMessages = validationResult.Errors
            .Select(error => error.ErrorMessage)
            .ToList();

        throw new BadRequestException(string.Join("\n", errorMessages));
    }

    if (gameService.DoesGameWithTitleExist(addedGame.Titulo))
    {
        throw new BadRequestException("Ja existe um jogo com esse mesmo titulo");
    }

    var gameToAdd = new Game
    {
        Titulo = addedGame.Titulo,
        Modo = addedGame.Modo,
        Descricao = addedGame.Descricao,
        Desenvolvedores = addedGame.Desenvolvedores
    };

    gameService.AddGame(gameToAdd);
    return Results.Created($"/game/{gameToAdd.Id}", gameToAdd);
});

app.MapPut("/game/{id}", (GameDTO updateGameDTO, Guid id, [FromServices] IGameService gameService) =>
{
    var existingGame = gameService.GetGameById(id);

    if (existingGame is null)
    {
        throw new NotFoundException("Jogo nao encontrado");
    }

    var updateGame = new Game
    {
        Id = id,
        Titulo = updateGameDTO.Titulo,
        Modo = updateGameDTO.Modo,
        Descricao = updateGameDTO.Descricao,
        Desenvolvedores = updateGameDTO.Desenvolvedores
    };

    var validator = new GameDTOValidator();
    var validationResult = validator.Validate(updateGameDTO);

    if (!validationResult.IsValid)
    {
        var errorMessages = validationResult.Errors
            .Select(error => error.ErrorMessage)
            .ToList();

        throw new BadRequestException(string.Join("\n", errorMessages));
    }

    if (updateGameDTO.Titulo == existingGame.Titulo)
    {
        throw new BadRequestException("O novo titulo deve ser diferente do atual");
    }

    if (gameService.DoesGameWithTitleExist(updateGameDTO.Titulo))
    {
        throw new BadRequestException("Ja existe um jogo com esse mesmo titulo");
    }

    gameService.UpdateGame(updateGame);
    return Results.Ok(updateGame);
});

//app.MapPatch("/game/{id}", (Guid id, [FromBody] UpdateFieldRequest updateField, [FromServices] IGameService gameService) =>
//{
//    var updateGame = gameService.UpdateField(id, updateField);
//    if (updateGame is null)
//    {
//        return Results.NotFound("Desculpe, esse jogo não consta em nosso sistema :( ");
//    }

//    return Results.Ok(updateGame);
//});


app.MapDelete("/game/{id}", (Guid id, [FromServices] IGameService gameService) =>
{
    var gameToDelete = gameService.GetGameById(id);

    if (gameToDelete is null)
    {
        throw new NotFoundException("Jogo nao encontrado");
    }

    gameService.DeleteGame(id);
    return Results.NoContent();
});

app.Run();
