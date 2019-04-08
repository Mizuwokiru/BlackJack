namespace BlackJack.Services.Services.Interfaces
{
    public interface IGameService
    {
        void NewGame(int botCount);
        void ContinueGame();
        void Step();
        void Skip();
        void NextRound();
        void EndGame();
    }
}
