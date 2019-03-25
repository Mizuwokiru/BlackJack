using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IGameService
    {
        IEnumerable<BotModel> CreateBots(int botCount);

        GameModel CreateGame(int userId);

        RoundModel CreateRound(int gameId);
    }
}
