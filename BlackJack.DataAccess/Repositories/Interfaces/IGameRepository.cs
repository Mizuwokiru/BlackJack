using BlackJack.DataAccess.Entities;
using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Game GetContinueableGame(long userId);
        int GetBotCount(long gameId);
        IEnumerable<Game> GetGamesHistory(long userId);
        IEnumerable<RoundPlayerState> GetGameInfo(long userId, int gameSkipCount);
        long GetGameIdBySkipCount(long userId, int gameSkipCount);
    }
}
