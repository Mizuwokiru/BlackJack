using BlackJack.DataAccess.Entities;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Game GetGameOfGamePlayer(int gamePlayerId);

        Game GetGameOfRound(int roundId);
    }
}
