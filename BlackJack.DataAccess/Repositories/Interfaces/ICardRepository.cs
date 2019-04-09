using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        List<Card> GetCards(IEnumerable<Round> rounds);
        List<Card> GetCards(long roundId);
    }
}
