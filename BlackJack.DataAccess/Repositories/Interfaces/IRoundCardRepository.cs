using BlackJack.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundCardRepository : IRepository<RoundCard>
    {
        Task<IEnumerable<RoundCard>> GetCards(long roundId);
        Task<bool> HasCards(long roundId);
    }
}
