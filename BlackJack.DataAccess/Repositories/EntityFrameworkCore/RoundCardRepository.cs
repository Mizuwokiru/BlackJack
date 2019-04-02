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
            throw new System.NotImplementedException();
        }

        public bool HasAnyCard(long gameId)
        {
            IEnumerable<RoundCard> round = _dbContext.Rounds
                .Where(tmpRound => tmpRound.GameId == gameId)
                .First().Cards;
            return round.Count() != 0;
        }
    }
}
