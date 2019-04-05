using BlackJack.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<List<Player>> GetBots(int botCount);
        Task<Player> GetDealer();
        Task<Player> GetPlayer(string userName);
        Task<Player> GetPlayer(long roundId);
        Task<IEnumerable<string>> GetUserNames();
    }
}
