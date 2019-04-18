using System.Collections.Generic;

namespace BlackJack.ViewModels.Models.Game
{
    public class RoundInfoViewModel
    {
        public RoundViewModel User { get; set; }

        public IEnumerable<RoundViewModel> Bots { get; set; }

        public RoundViewModel Dealer { get; set; }
    }
}
