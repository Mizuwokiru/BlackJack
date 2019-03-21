using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Models
{
    public class RoundCreationViewModel
    {
        public int RoundId { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }
    }
}
