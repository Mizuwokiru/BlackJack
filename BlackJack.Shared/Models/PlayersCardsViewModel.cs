using System.Collections.Generic;

namespace BlackJack.Shared.Models
{
    public class PlayersCardsViewModel
    {
        public bool CanToTakeMore { get; set; }

        public IEnumerable<PlayerCardsViewModel> PlayersCards { get; set; }
    }
}
