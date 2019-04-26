using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IRoundRepository : IRepository<Round>
    {
        IEnumerable<RoundInfoModel> GetLastRoundsInfo(long gameId);
        StepInfoModel GetStepInfo(long userId, long gameId);
        void UpdateLastRoundInfo(IEnumerable<RoundInfoModel> roundInfoModels);
        IEnumerable<RoundState> GetRoundStates(long userId, int gameSkipCount);
        IEnumerable<RoundInfoModel> GetRoundInfo(long userId, long gameId, int roundSkipCount);
    }
}
