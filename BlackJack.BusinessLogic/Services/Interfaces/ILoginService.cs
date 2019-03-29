using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface ILoginService
    {
        IEnumerable<string> GetPlayersNames();
        IEnumerable<PlayerViewModel> GetPlayers(); // возможно не нужен
        PlayerViewModel GetOrCreatePlayer(string playerName);
        PlayerViewModel GetPlayer(int playerId);
    }
}
