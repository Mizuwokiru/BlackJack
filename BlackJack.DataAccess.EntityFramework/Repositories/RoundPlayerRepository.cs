using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlackJack.DataAccess.EntityFramework.Repositories
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
