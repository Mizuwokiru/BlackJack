using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<Card> GetCardsByRound(int roundId)
        {
            return _dbContext.RoundCards
                .Where(roundCard => roundCard.RoundId == roundId)
                .Select(roundCard => roundCard.Card);
        }
    }
}
