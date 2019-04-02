using System.Collections.Generic;

namespace BlackJack.Shared.Models
{
    public class PlayerCardsViewModel
    {
        public long PlayerId { get; set; }

        public IEnumerable<CardViewModel> Cards { get; set; }
    }
}
