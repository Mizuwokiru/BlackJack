using BlackJack.Shared.Models;
using System.Collections.Generic;

namespace BlackJack.Services.Services.Interfaces
{
    public interface ILoginService
    {
        PlayerViewModel GetPlayer(string playerName);
        IEnumerable<string> GetPlayerNames();
    }
}
