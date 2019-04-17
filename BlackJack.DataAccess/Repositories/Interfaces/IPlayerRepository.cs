using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        IEnumerable<string> GetUsers();
        Player GetUser(string name);
        int GetBotCount();
        IEnumerable<Player> GetBots(int count);
    }
}
