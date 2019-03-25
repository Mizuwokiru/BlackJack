using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundPlayerBotRepository : IRepository<RoundPlayerBot>
    {
        IEnumerable<RoundPlayerBot> GetRoundPlayerBotsByRound(int roundId);
    }
}
