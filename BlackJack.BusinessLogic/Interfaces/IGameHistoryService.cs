using BlackJack.BusinessLogic.DTO;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameHistoryService
    {
        IEnumerable<GameDTO> GetAllGames();

        IEnumerable<RoundDTO> GetRoundsByGame(int gameId);

        IEnumerable<GamePlayerDTO> GetPlayersByGame(int gameId);

        IEnumerable<RoundPlayerDTO> GetPlayersByRound(int roundId);

        IEnumerable<RoundPlayerCardDTO> GetCardsByPlayer(int roundPlayerId);
    }
}
