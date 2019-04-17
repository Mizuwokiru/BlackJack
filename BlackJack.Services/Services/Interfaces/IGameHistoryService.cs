using BlackJack.ViewModels.Models.Game;
using BlackJack.ViewModels.Models.History;
using System.Collections.Generic;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IGameHistoryService
    {
        IEnumerable<HistoryGameViewModel> GetGamesHistory();

        HistoryRoundsViewModel GetRoundsHistory(int gameSkipCount);

        IEnumerable<RoundViewModel> GetRoundInfo(int gameSkipCount, int roundSkipCount);
    }
}
