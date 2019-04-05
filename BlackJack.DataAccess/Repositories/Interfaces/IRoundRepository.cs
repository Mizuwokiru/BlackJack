using BlackJack.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundRepository : IRepository<Round>
    {
        Task<List<Round>> GetLastRounds(long gameId);

        Task<Round> GetLastRound(long gameId, long playerId);

        Task<IEnumerable<IGrouping<DateTime, Round>>> GetRounds(long gameId);
    }
}
