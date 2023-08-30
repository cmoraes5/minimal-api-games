namespace MinimalGameApi.Interface
{
    public interface IGameService
    {
        List<Game> GetAllGames();
        Game GetGameById(Guid id);
        IEnumerable<Game> GetGamesByTitle(string title);
        Game UpdateField(Guid id, UpdateFieldRequest updateField);
        void AddGame(Game addedGame);
        void UpdateGame(Game updateGame);
        void DeleteGame(Guid id);
        bool DoesGameWithTitleExist(string titulo);
    }
}
