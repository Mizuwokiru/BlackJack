using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.ViewModels.Game
{
    public class RoundInfoViewModel
    {
        public IEnumerable<PlayerStateViewModel> Players { get; set; }
    }

    public class PlayerStateViewModel
    {
        public string PlayerName { get; set; }

        public List<int> Cards { get; set; }

        public RoundState State { get; set; }

        public int Score { get; set; }
    }
}
