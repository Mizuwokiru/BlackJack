using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundCardRepository : IRepository<RoundCard>
    {
        IEnumerable<RoundCard> GetCardsByRound(int roundId);

        bool IsCardsHandedOut(int roundId);
    }
}
