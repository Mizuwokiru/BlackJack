using BlackJack.Shared.Models;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IGameService
    {
        GameViewModel ContinueGame(long userId);
        GameViewModel CreateGame(long userId, int botCount);
        void FinishGame(long gameId);
        FinishRoundViewModel FinishRound(long gameId);
        GetCardViewModel GetCard(long gameId);
        PlayersCardsViewModel GetRound(long gameId);
        bool HasUnfinishedGames(long userId);
    }
}
