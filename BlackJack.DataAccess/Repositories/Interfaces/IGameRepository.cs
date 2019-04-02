using BlackJack.DataAccess.Entities;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        void FinishAllGames(long userId);
        Game GetUnfinishedGame(long userId);
        bool HasUnfinishedGames(long userId);
    }
}
