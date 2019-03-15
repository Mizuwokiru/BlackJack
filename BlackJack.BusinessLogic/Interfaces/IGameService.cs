using BlackJack.BusinessLogic.DTO;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        void MakeGame(GameDTO game);

        void MakePlayer(PlayerDTO player);

        void MakeRound(RoundDTO round, int gameId);

        void MakeGamePlayer(GamePlayerDTO gamePlayer, int gameId);

        void MakeRoundPlayer(RoundPlayerDTO roundPlayer, int roundId);

        void MakeRoundPlayerCard(RoundPlayerCardDTO roundPlayerCard, int roundPlayerId);
    }
}
