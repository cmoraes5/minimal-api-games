using Microsoft.AspNetCore.Mvc;
using MinimalGameApi;
using MinimalGameApi.Interface;
using MinimalGameApi.Services;

public class GameService : IGameService
{
    private readonly GameList _games;

    public GameService(GameList gameList)
    {
        _games = gameList;
    }

    public List<Game> GetAllGames() 
    {
        var context = new ApplicationDbContext();
        return context.Games.ToList();
    }

    public Game GetGameById(Guid id)
    {
        return _games.Games.Find(game => game.Id == id);
    }

    public IEnumerable<Game> GetGamesByTitle(string title)
    {
        return _games.Games.Where(game => game.Titulo.Contains(title, StringComparison.OrdinalIgnoreCase));
    }

    public void AddGame(Game addedGame)
    {
        var context = new ApplicationDbContext();
        context.Games.Add(addedGame);

        context.SaveChanges();
    }

    public void UpdateGame(Game updateGame)
    {
        var game = _games.Games.Find(game => game.Id == updateGame.Id);
        if (game != null)
        {
            game.Titulo = updateGame.Titulo;
            game.Descricao = updateGame.Descricao;
            game.Modo = updateGame.Modo;
            game.Desenvolvedores = updateGame.Desenvolvedores;
        }
    }

    public Game UpdateField(Guid id, UpdateFieldRequest updateField)
    {
        var game = _games.Games.Find(game => game.Id == id);
        if (game == null)
        {
            return null;
        }

        switch (updateField.Field)
        {
            case "Titulo":
                game.Titulo = updateField.NewFieldValue;
                break;

            case "Descricao":
                game.Descricao = updateField.NewFieldValue;
                break;


            default: 
                return null;
        }

        return game;
    }

    public void DeleteGame(Guid id)
    {
        var game = GetGameById(id);
        if (game != null)
        {
            _games.Games.Remove(game);
        }
    }
}
