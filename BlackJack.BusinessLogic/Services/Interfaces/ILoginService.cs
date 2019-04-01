using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface ILoginService
    {
        List<string> GetPlayersNames();
        PlayerViewModel GetOrCreatePlayer(string playerName);
    }
}
