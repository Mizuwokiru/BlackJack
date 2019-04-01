using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IGameService
    {
        GameViewModel CreateGame(int playerId, int botCount);
        GameViewModel ContinueGame(int playerId);
        List<PlayerCardsViewModel> GetRound(int gameId);
    }
}
