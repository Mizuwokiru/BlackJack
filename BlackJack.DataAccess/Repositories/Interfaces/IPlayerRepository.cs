using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        IEnumerable<Player> GetBots(int botCount);
        Player GetDealer();
        Player GetPlayer(string name);
        Player GetPlayer(long roundId);
        IEnumerable<string> GetPlayerNames();
        IEnumerable<Player> GetPlayersForGame(long gameId);
    }
}
