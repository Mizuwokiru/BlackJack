using System;
using System.Collections.Generic;

namespace BlackJack.ViewModels.History
{
    public class GamesHistoryViewModel
    {
        public IEnumerable<GameGamesHistoryViewModel> Games { get; set; }
    }

    public class GameGamesHistoryViewModel
    {
        public int RoundCount { get; set; }

        public int PlayerCount { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
