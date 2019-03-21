using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlackJack.DataAccess.EntityFramework.Repositories
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Round GetRoundOfRoundPlayer(int roundPlayerId) => 
            _dbContext.Set<RoundPlayer>().Find(roundPlayerId).Round;

        public IEnumerable<Round> GetRounds(int gameId) => _dbContext.Set<Game>().Find(gameId).Rounds;
    }
}
