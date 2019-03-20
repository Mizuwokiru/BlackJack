using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameCreationService
    {
        IEnumerable<PlayerModel> GetPlayables();

        int MakeGame(string playerName, int botCount); // возвращать Id игры или выделить отдельный класс под игру?
    }
}
