using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundRepository : IRepository<Round>
    {
        IEnumerable<Round> GetRounds(int gameId);

        Round GetRoundOfRoundPlayer(int roundPlayerId);
    }
}
