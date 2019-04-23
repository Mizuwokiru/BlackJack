using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.History;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IHistoryService
    {
        GamesHistoryViewModel GetGamesHistory();

        RoundsHistoryViewModel GetRoundsHistory(int gameSkipCount);

        RoundInfoViewModel GetRoundInfo(int gameSkipCount, int roundSkipCount);
    }
}
