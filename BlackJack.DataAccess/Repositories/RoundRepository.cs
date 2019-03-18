using System.Collections.Generic;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Round GetRoundOfRoundPlayer(int roundPlayerId)
        {
            return _dbContext.Set<RoundPlayer>().Find(roundPlayerId).Round;
        }

        public IEnumerable<Round> GetRounds(int gameId)
        {
            return _dbContext.Set<Game>().Find(gameId).Rounds;
        }
    }
}
