using System;

namespace BlackJack.ViewModels.Models
{
    public class HistoryGameViewModel
    {
        public int RoundCount { get; set; }

        public int PlayerCount { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
