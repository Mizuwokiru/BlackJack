using BlackJack.DataAccess.Entities;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundRepository : IRepository<Round>
    {
        Round GetLastRound(long userId);
        List<Round> GetLastRounds(long gameId);
    }
}
