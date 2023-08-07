namespace MinimalGameApi.Interface
{
    public interface IGameService
    {
        List<Game> GetAllGames();
        Game GetGameById(int id);
        IEnumerable<Game> GetGamesByTitle(string title);
        Game UpdateField(int id, UpdateFieldRequest updateField);
        void AddGame(Game addedGame);
        void UpdateGame(Game updateGame);
        void DeleteGame(int id);
    }
}
