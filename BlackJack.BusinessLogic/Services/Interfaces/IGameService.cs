namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IGameService
    {
        int CreateGame(int playerId, int botCount);

        //List<CardViewModel> CreateRound(int gameId);
    }
}
