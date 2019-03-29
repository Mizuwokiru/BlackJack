using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Common;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundPlayerRepository : BaseRepository<RoundPlayer>, IRoundPlayerRepository
    {
        public RoundPlayerRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<RoundPlayer> GetRoundPlayers(int roundId)
        {
            return _dbContext.Set<Round>().Find(roundId).Players;
        }
    }
}
