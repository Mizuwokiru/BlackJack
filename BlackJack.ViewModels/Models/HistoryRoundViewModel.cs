using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.ViewModels.Models
{
    public class HistoryRoundViewModel
    {
        public string PlayerName { get; set; }

        public IEnumerable<CardViewModel> Cards { get; set; }

        public RoundState State { get; set; }
    }
}
