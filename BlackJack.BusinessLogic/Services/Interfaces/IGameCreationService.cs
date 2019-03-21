using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IGameCreationService
    {
        IEnumerable<PlayerViewModel> GetPlayables();

        GameCreationViewModel CreateGame(string playerName, int botCount);
    }
}
