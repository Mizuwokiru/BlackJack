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

        public IEnumerable<RoundCard> GetCards(long roundId)
        {
            List<RoundCard> cards = _dbContext.RoundCards
                .Where(card => card.RoundId == roundId)
                .ToList();
            return cards;
        }

        public bool HasCards(long roundId)
        {
            RoundCard roundCard = _dbContext.RoundCards
                .FirstOrDefault(card => card.RoundId == roundId);
            return roundCard != null;
        }
    }
}
