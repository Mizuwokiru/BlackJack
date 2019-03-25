using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IBotRepository : IRepository<Bot>
    {
        IEnumerable<Bot> GetOrCreateBots(int botCount);

        IEnumerable<Bot> GetBotsWithIds(IEnumerable<int> botsIds);
    }
}
