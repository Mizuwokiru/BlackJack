using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundPlayerCardRepository : IRepository<RoundPlayerCard>
    {
        IEnumerable<RoundPlayerCard> GetRoundPlayerCardsByPlayer(int roundPlayerId);
    }
}
