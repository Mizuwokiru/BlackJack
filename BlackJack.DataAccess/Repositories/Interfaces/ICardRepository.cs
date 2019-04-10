using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        List<Card> GetCardsByGame(long gameId);
        List<Card> GetCardByRound(long roundId);
    }
}
