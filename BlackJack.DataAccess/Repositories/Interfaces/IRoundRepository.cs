using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.ResponseModels;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundRepository : IRepository<Round>
    {
        Round GetLastRound(long userId);
        List<Round> GetLastRounds(long gameId);
        IEnumerable<RoundInfoModel> GetLastRoundInfo(long gameId);
        void UpdateLastRoundInfo(IEnumerable<RoundInfoModel> roundInfoModels);
    }
}
