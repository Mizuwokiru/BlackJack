using BlackJack.DataAccess.Entities;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IGameRepository
    {
        Game GetGameOfGamePlayer(int gamePlayerId);

        Game GetGameOfRound(int roundId);
    }
}
