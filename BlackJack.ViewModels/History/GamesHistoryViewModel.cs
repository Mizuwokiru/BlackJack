using System;
using System.Collections.Generic;

namespace BlackJack.ViewModels.History
{
    public class GamesHistoryViewModel
    {
        public IEnumerable<GameViewModel> Games { get; set; }
    }

    public class GameViewModel
    {
        public int RoundCount { get; set; }

        public int PlayerCount { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
