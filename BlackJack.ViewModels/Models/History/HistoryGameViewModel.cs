using System;

namespace BlackJack.ViewModels.Models.History
{
    public class HistoryGameViewModel
    {
        public int RoundCount { get; set; }

        public int PlayerCount { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
