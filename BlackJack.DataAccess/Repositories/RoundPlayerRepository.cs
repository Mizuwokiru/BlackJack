using System.Collections.Generic;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class RoundPlayerRepository : BaseRepository<RoundPlayer>, IRoundPlayerRepository
    {
        public RoundPlayerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<RoundPlayer> GetRoundPlayers(int roundId)
        {
            return _dbContext.Set<Round>().Find(roundId).Players;
        }
    }
}
