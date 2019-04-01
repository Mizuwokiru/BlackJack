using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Models
{
    public class PlayerCardsViewModel
    {
        public int PlayerId { get; set; }

        public List<CardViewModel> PlayerCards { get; set; }
    }
}
