using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player GetPlayerByName(string userName);
        IEnumerable<Player> GetPlayers();
        IEnumerable<Player> GetBots();
        IEnumerable<Player> GetOrCreateBots(int botCount);
    }
}
