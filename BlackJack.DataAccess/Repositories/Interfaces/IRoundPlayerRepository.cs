using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundPlayerRepository : IRepository<RoundPlayer>
    {
        IEnumerable<RoundPlayer> GetRoundPlayers(int roundId);
    }
}
