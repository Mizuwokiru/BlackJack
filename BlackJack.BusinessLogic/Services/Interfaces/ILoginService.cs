using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface ILoginService
    {
        IEnumerable<PlayerViewModel> GetPlayers();
        PlayerViewModel GetOrCreatePlayer(string playerName);
        PlayerViewModel GetPlayer(int playerId);
    }
}
