using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.Shared.Models
{
    public class FinishRoundViewModel
    {
        public RoundState PlayerState { get; set; }

        public IEnumerable<FinishRoundBotViewModel> Bots { get; set; }

        public IEnumerable<CardViewModel> DealerCards { get; set; }
    }
}
