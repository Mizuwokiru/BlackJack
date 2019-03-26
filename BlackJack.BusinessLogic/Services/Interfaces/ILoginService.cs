using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface ILoginService
    {
        IEnumerable<PlayerModel> GetPlayers();
        PlayerModel GetOrCreatePlayer(string userName);
        PlayerModel GetPlayer(int userId);
    }
}
