using BlackJack.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        Task<List<Card>> GetCards(long roundId);
    }
}
