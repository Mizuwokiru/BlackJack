using BlackJack.Shared.Models;
using System.Collections.Generic;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IGameService
    {
        GameViewModel ContinueGame(long userId);
        GameViewModel CreateGame(long userId, int botCount);
        FinishRoundViewModel FinishGame(long gameId);
        FinishRoundViewModel FinishRound(long gameId);
        GetCardViewModel GetCard(long gameId);
        IEnumerable<PlayerCardsViewModel> GetRound(long gameId);
        bool HasUnfinishedGames(long userId);
    }
}
