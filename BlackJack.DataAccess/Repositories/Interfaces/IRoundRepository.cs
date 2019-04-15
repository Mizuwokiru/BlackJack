using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.ResponseModels;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundRepository : IRepository<Round>
    {
        IEnumerable<RoundInfoModel> GetLastRoundsInfo(long gameId);
        StepInfoModel GetStepInfo(long userId, long gameId);
        void UpdateLastRoundInfo(IEnumerable<RoundInfoModel> roundInfoModels);
        IEnumerable<IEnumerable<RoundInfoModel>> GetHistoryRoundsInfo(long userId, int skipCount);
    }
}
