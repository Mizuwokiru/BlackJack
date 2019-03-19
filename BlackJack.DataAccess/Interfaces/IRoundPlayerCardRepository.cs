using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IRoundPlayerCardRepository : IRepository<RoundPlayerCard>
    {
        IEnumerable<RoundPlayerCard> GetRoundPlayerCards(int roundPlayerId);
    }
}
