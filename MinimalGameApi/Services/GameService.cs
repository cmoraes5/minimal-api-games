using MinimalGameApi;
using MinimalGameApi.Interface;

public class GameService : IGameService
{
    private readonly ApplicationDbContext _context;

    public GameService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Game> GetAllGames() 
    {
        var _context = new ApplicationDbContext();
        return _context.Games.ToList();
    }

    public Game GetGameById(Guid id)
    {
        var _context = new ApplicationDbContext();
        var gameById = _context.Games.SingleOrDefault(game => game.Id == id);

        return gameById;
    }

    public IEnumerable<Game> GetGamesByTitle(string title)
    {
        return _context.Games.Where(game => game.Titulo.Contains(title, StringComparison.OrdinalIgnoreCase));
    }

    public void AddGame(Game addedGame)
    {
        var context = new ApplicationDbContext();
        context.Games.Add(addedGame);

        context.SaveChanges();
    }

    public void UpdateGame(Game updateGame)
    {
        var _context = new ApplicationDbContext();

        var game = _context.Games.SingleOrDefault(game => game.Id == updateGame.Id);

        if (game != null)
        {
            game.Titulo = updateGame.Titulo;
            game.Descricao = updateGame.Descricao;
            game.Modo = updateGame.Modo;
            game.Desenvolvedores = updateGame.Desenvolvedores;

            _context.SaveChanges();
        }
    }

    public Game UpdateField(Guid id, UpdateFieldRequest updateField)
    {
        var game = GetGameById(id);
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

        _context.SaveChanges();

        return game;
    }

    public void DeleteGame(Guid id)
    {
        var _context = new ApplicationDbContext();

        var game = GetGameById(id);
        if (game != null)
        {
            _context.Games.Remove(game);

            _context.SaveChanges();
        }
    }
}
