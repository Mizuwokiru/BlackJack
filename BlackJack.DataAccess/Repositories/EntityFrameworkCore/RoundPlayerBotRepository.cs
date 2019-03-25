using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundPlayerBotRepository : BaseRepository<RoundPlayerBot>, IRoundPlayerBotRepository
    {
        public RoundPlayerBotRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<RoundPlayerBot> GetRoundPlayerBotsByRound(int roundId) =>
            _dbContext.Set<RoundPlayerBot>().Where(roundPlayerBot => roundPlayerBot.Round.Id == roundId);
    }
}
