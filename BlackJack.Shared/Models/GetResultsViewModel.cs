using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.Shared.Models
{
    public class GetResultsViewModel
    {
        public RoundState PlayerState { get; set; }

        public List<GetBotResultsViewModel> Bots { get; set; }

        public IEnumerable<CardViewModel> DealerCards { get; set; }
    }
}
