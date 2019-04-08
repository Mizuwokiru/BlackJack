using BlackJack.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundRepository : IRepository<Round>
    {
        Round GetLastRound(long gameId, long userId);
        List<Round> GetLastRounds(long gameId);
    }
}
