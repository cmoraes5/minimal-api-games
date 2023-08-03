namespace MinimalGameApi
{
    public interface IGameService
    {
        List<Game> GetAllGames();
        Game GetGameById(int id);
        IEnumerable<Game> GetGamesByTitle(string title);
        void AddGame(Game game);
        void UpdateGame(Game updateGame);
        void DeleteGame(int id);
    }
}
