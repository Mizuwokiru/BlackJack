using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundCardRepository : BaseRepository<RoundCard>, IRoundCardRepository
    {
        public RoundCardRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<RoundCard> GetCardsByRound(int roundId)
        {
            return _dbContext.RoundCards
                .Where(roundCard => roundCard.RoundId == roundId);
        }

        public bool IsCardsHandedOut(int roundId)
        {
            return _dbContext.Rounds
                .Find(roundId)
                .Cards.Count != 0;
        }
    }
}
