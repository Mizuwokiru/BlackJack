using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface ICardService
    {
        IEnumerable<CardViewModel> GetShuffledCards();
        IEnumerable<int> GetShuffledCardIds();
    }
}
