using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IGameService
    {
        RoundCreationViewModel CreateRound(int gameId);

        IEnumerable<CardViewModel> GetShuffledCards();
    }
}
