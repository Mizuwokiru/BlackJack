using BlackJack.BusinessLogic.DTO;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface ICardService
    {
        IEnumerable<CardDTO> GetCardList();
    }
}
