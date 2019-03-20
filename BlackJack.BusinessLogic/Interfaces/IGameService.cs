using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        IEnumerable<CardModel> GetShuffledCards();


    }
}
