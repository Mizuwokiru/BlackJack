using BlackJack.ViewModels.Models;
using System.Collections.Generic;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IGameHistoryService
    {
        IEnumerable<HistoryGameViewModel> GetGamesHistory();

        IEnumerable<HistoryRoundsViewModel> GetRoundsHistory(int gameOrder);
    }
}
