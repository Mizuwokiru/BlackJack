using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.Shared.Models
{
    public class GetBotResultsViewModel
    {
        public long Id { get; set; }

        public IEnumerable<CardViewModel> Cards { get; set; }

        public RoundState State { get; set; }
    }
}
