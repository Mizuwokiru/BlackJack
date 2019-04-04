using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundRepository : IRepository<Round>
    {
        Round GetLastRound(long gameId);

        IEnumerable<Round> GetLastRounds(long gameId);

        IEnumerable<Round> GetRounds(long gameId);
    }
}
