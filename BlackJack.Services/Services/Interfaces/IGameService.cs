using BlackJack.Shared.Models;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IGameService
    {
        GameViewModel ContinueGame(long userId);
        GameViewModel CreateGame(long userId, int botCount);
        void EndGame(long gameId);
        GetResultsViewModel GetResults(long gameId);
        GetCardViewModel GetCard(long gameId);
        PlayersCardsViewModel GetRound(long gameId);
        bool HasUnfinishedGames(long userId);
    }
}
