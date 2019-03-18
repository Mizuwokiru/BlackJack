using BlackJack.DataAccess.Entities;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRepository
    {
        Player GetPlayerOfGamePlayer(int gamePlayerId);

        Player GetPlayerOfRoundPlayer(int roundPlayerId);
    }
}
