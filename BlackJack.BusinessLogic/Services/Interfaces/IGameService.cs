namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IGameService
    {
        int CreateGame(int userId, int botCount);

        int CreateRound(int gameId);

        void FinishRound(int roundId);
    }
}
