using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        IEnumerable<Card> GetLastRoundCards(long gameId);
        IEnumerable<Card> GetLastRoundPlayerCards(long playerId, long gameId);
        void FillRoundPlayersCards(IEnumerable<RoundPlayer> roundPlayers);
    }
}
