using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Models
{
    public class RoundViewModel
    {
        public int Number { get; set; }

        public PlayerCardsViewModel UserCards { get; set; }

        public List<PlayerCardsViewModel> BotsCards { get; set; }

        public List<CardViewModel> DealerCards { get; set; }
    }
}
