﻿using BlackJack.ViewModels.Models;
using System.Collections.Generic;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IGameHistoryService
    {
        IEnumerable<HistoryGameViewModel> GetGamesHistory();

        IEnumerable<IEnumerable<HistoryRoundViewModel>> GetRoundsHistory(int gameOrder);
    }
}
