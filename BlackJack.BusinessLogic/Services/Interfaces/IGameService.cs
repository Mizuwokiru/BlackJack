using BlackJack.BusinessLogic.Models;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IGameService
    {
        CreateGameViewModel CreateGame(int playerId, int botCount);
    }
}
