using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IRoundPlayerRepository
    {
        IEnumerable<RoundPlayer> GetRoundPlayers(int roundId);
    }
}
