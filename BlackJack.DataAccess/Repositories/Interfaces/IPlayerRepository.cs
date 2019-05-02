using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        IEnumerable<string> GetUserNames();
        int GetBotCount();
        IEnumerable<Player> GetBots(int neededCount);

    }
}
