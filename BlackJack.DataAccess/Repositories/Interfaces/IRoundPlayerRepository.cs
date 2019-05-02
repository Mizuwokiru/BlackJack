using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundPlayerRepository : IRepository<RoundPlayer>
    {
        IEnumerable<RoundPlayer> GetLastRoundInfo(long gameId);
        RoundPlayer GetLastRoundPlayerInfo(long gameId, long playerId);
        IEnumerable<RoundPlayer> GetRoundInfo(long gameId, int roundSkipCount);
    }
}
