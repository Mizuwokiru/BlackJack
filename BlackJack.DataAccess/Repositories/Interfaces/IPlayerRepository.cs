using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        int GetBotCount();
        List<Player> GetBots(int botCount);
        Player GetDealer();
        Player GetPlayer(long roundId);
        Player GetUser(string userName);
        List<string> GetUserNames();
    }
}
