using BlackJack.BusinessLogic.Models;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IGameService
    {
        CreateGameViewModel CreateGame(int userId, int botCount);

        RoundViewModel CreateRound(int gameId);

        void FinishRound(int gameId);
    }
}
