using BlackJack.ViewModels.Models;
using System.Collections.Generic;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IRoundService
    {
        List<RoundViewModel> GetRoundsInfo();
        void CreateRound();
        void Step();
        void Skip();
        void NextRound();
    }
}
