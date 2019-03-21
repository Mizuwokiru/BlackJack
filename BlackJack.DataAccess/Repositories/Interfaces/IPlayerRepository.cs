using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player GetPlayerOfGamePlayer(int gamePlayerId);

        Player GetPlayerOfRoundPlayer(int roundPlayerId);

        IEnumerable<Player> GetPlayers();

        Player GetOrCreatePlayer(string name);

        IEnumerable<Player> GetOrCreateBots(int botCount);
    }
}
