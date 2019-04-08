using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        List<Player> GetBots();
        Player GetDealer();
        Player GetUser(string userName);
        List<string> GetUserNames();
    }
}
