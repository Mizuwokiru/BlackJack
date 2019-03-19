using BlackJack.BusinessLogic.DTO;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IPlayerService
    {
        IEnumerable<PlayerDTO> GetPlayableList();

        IEnumerable<PlayerDTO> GetBotList();

        void MakePlayer(PlayerDTO playerDto);
    }
}
