using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.ViewModels.Models.History
{
    public class GameRoundsViewModel
    {
        public IEnumerable<RoundState> RoundStates { get; set; }
    }
}
