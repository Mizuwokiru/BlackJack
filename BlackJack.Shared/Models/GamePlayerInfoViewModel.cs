using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.Shared.Models
{
    public class GamePlayerInfoViewModel
    {
        public string Name { get; set; }

        public List<int> Cards { get; set; }

        public RoundState State { get; set; }
    }
}
