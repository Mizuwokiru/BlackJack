using System.Collections.Generic;

namespace BlackJack.Shared.Models
{
    public class GameViewModel
    {
        public long GameId { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }
    }
}
