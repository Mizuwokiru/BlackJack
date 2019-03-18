using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IRoundRepository
    {
        IEnumerable<Round> GetRounds(int gameId);

        Round GetRoundOfRoundPlayer(int roundPlayerId);
    }
}
