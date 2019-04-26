using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.ResponseModels;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Game GetUnfinishedGame(long userId);
        int GetPlayerCount(long gameId);
        IEnumerable<GamesHistoryInfoModel> GetGamesHistory(long userId);
        long GetGameIdBySkipCount(long userId, int gameSkipCount);
    }
}
