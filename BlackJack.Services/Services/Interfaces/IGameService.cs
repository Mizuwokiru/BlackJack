using BlackJack.ViewModels.Game;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IGameService
    {
        MenuViewModel GetMenu();
        GameViewModel GetRoundInfo();
        void NewGame(int neededBotCount);
        void Step();
        void Skip();
        void NextRound();
        void EndGame();
    }
}
