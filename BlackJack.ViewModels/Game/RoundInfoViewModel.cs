using System.Collections.Generic;

namespace BlackJack.ViewModels.Models.Game
{
    public class RoundInfoViewModel
    {
        public PlayerStateViewModel User { get; set; }

        public IEnumerable<PlayerStateViewModel> Bots { get; set; }

        public PlayerStateViewModel Dealer { get; set; }
    }
}
