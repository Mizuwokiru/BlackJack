using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Models
{
    public class PlayerCardsViewModel
    {
        public PlayerViewModel Player { get; set; }

        public List<CardViewModel> Cards { get; set; }
    }
}
